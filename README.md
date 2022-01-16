# PowerUtils.Security
Helpers, extensions and utilities to work with security

![CI](https://github.com/TechNobre/PowerUtils.Security/actions/workflows/test-project.yml/badge.svg)
[![NuGet](https://img.shields.io/nuget/v/PowerUtils.Security.svg)](https://www.nuget.org/packages/PowerUtils.Security)
[![Nuget](https://img.shields.io/nuget/dt/PowerUtils.Security.svg)](https://www.nuget.org/packages/PowerUtils.Security)
[![Quality gate](https://sonarcloud.io/api/project_badges/quality_gate?project=TechNobre_PowerUtils.Security)](https://sonarcloud.io/summary/new_code?id=TechNobre_PowerUtils.Security)



## Support to
- .NET 3.1 or more
- .NET Framework 4.6.2 or more
- .NET Standard 2.0 or more



## Features

- [HashExtensions](#HashExtensions)
  - [string.ToMD5](#string.ToMD5)
  - [string.ToSHA1](#string.ToSHA1)
  - [string.ToSHA256](#string.ToSHA256)
  - [string.ToSHA384](#string.ToSHA384)
  - [string.ToSHA512](#string.ToSHA512)



## Documentation

### How to use

#### Install NuGet package
This package is available through Nuget Packages: https://www.nuget.org/packages/PowerUtils.Security

**Nuget**
```bash
Install-Package PowerUtils.Security
```

**.NET CLI**
```
dotnet add package PowerUtils.Security
```

### HashExtensions <a name="HashExtensions"></a>

#### string.ToMD5(); <a name="string.ToMD5"></a>
Convert a text to hash MD5

```csharp
// result = "dc483e80a7a0bd9ef71d8cf973673924"
var result = "a123456".ToMD5();
```

#### string.ToSHA1(); <a name="string.ToSHA1"></a>
Convert a text to hash SHA1

```csharp
// result = "895b317c76b8e504c2fb32dbb4420178f60ce321"
var result = "a123456".ToSHA1();
```

#### string.ToSHA256(); <a name="string.ToSHA256"></a>
Convert a text to hash SHA256

```csharp
// result = "20f645c703944a0027acf6fad92ec465247842450605c5406b50676ff0dcd5ea"
var result = "a123456".ToSHA256();
```

#### string.ToSHA384(); <a name="string.ToSHA384"></a>
Convert a text to hash SHA384

```csharp
// result = "fec1bb0e04ed484a4e5e37e585c9d15f863db7e7f5585e047a1be80e269d50abb177e61c264f6c0443e4d8e26b235d8e"
var result = "a123456".ToSHA384();
```

#### string.ToSHA512(); <a name="string.ToSHA512"></a>
Convert a text to hash SHA512

```csharp
// result = "410752b9f6fef035ccb2b469bcc473d7d43e93a108332bc1eb3208412d599bb4478eea687c69f962d7670410b06deaeac77578452f7c2454f3100d017a802b7e"
var result = "a123456".ToSHA512();
```



## Contribution

*Help me to help others*



## LICENSE

[MIT](https://github.com/TechNobre/PowerUtils.Security/blob/main/LICENSE)



## Release Notes


### v1.0.0 - 2022/01/16

- Start project
