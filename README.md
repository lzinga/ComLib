# ComLib

[![Build status](https://ci.appveyor.com/api/projects/status/l5lfbba6qlimrets?svg=true)](https://ci.appveyor.com/project/lzinga/comlib)

A library that contains useful methods/function/extensions so I don't have to keep re-writing them for every new project like I usually do.

## Unity Library
Since unity is built on an older .net framework version has no connection with `ComLib.Extensions` and should have no connection 
to any other library in this solution unless it supports .net 3.5.

`ComLib.Unity` should be able to run independantly with its only dependancy being .net 3.5 supportable libaries and the unity libaries.


## Unity DLLs
We claim no ownership of the dll files and only provide them for the build process of this library. They should not be included with your unity build
or included in anything but this solution.