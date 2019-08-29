# POC-SplitUpload
**Proof of Concept** *(POC)* of a upload splited from **React** app to **C# .NET Core** backend then to a **C# .NET Core** BFI (*Backend For Integration*)

[![Build status](https://ci.appveyor.com/api/projects/status/97s6mf6kp99woyo7?svg=true)](https://ci.appveyor.com/project/guibranco/poc-splitupload)


This POC is based on a .NET Core API & React project.


UI project:
```bash
dotnet new React POCSplitUpload.UI
```

BFI project:
```bash
dotnet new Webapi POCSplitUpload.API
```