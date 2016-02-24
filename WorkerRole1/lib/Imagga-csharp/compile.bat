SET CSCPATH=%SYSTEMROOT%\Microsoft.NET\Framework\v4.0.30319
%CSCPATH%\csc /reference:bin/Newtonsoft.Json.dll;bin/RestSharp.dll /target:library /out:bin/Com.Imagga.Api.Imagga.dll /recurse:src\*.cs /doc:bin/Com.Imagga.Api.Imagga.xml

