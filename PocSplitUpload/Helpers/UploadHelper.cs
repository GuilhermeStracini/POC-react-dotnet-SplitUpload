using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PocSplitUpload.UI.Helpers
{
    public static class UploadHelper
    {
        private static readonly FormOptions DefaultFormOptions = new FormOptions();

        public static async Task Process(HttpRequest request)
        {
            if (!MultipartRequestHelper.IsMultipartContentType(request.ContentType))
                throw new InvalidOperationException($"Expected a multipart request, but got {request.ContentType}");
            var boundary = MultipartRequestHelper.GetBoundary(
                MediaTypeHeaderValue.Parse(request.ContentType),
                DefaultFormOptions.MultipartBoundaryLengthLimit);
            var reader = new MultipartReader(boundary, request.Body);
            var section = await reader.ReadNextSectionAsync();
            while (section != null)
            {
                await Upload(section);
                section = await reader.ReadNextSectionAsync();
            }
        }

        private static async Task Upload(MultipartSection section)
        {
            var hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(section.ContentDisposition, out var contentDisposition);
            if (!hasContentDispositionHeader || !MultipartRequestHelper.HasFileContentDisposition(contentDisposition))
                return;
            var targetFilePath = Path.GetTempFileName();
            using (var targetStream = File.Create(targetFilePath))
                await section.Body.CopyToAsync(targetStream);
        }
    }
}
