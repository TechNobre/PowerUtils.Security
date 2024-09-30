# PowerUtils.Security

# :warning: DEPRECATED

This package has been discontinued because it never evolved, and the current code does not justify its continuation. .NET has evolved significantly, and most of the features provided by this library are now built into the framework with better security and performance.

![Logo](https://raw.githubusercontent.com/TechNobre/PowerUtils.Security/main/assets/logo/logo_128x128.png)

***Helpers, extensions and utilities to work with security***


- [Support to ](#support-to-)
- [How to use ](#how-to-use-)
  - [Install NuGet package ](#install-nuget-package-)
  - [HashExtensions ](#hashextensions-)
    - [string.ToMD5(); ](#stringtomd5-)
    - [string.ToSHA1(); ](#stringtosha1-)
    - [string.ToSHA256(); ](#stringtosha256-)
    - [string.ToSHA384(); ](#stringtosha384-)
    - [string.ToSHA512(); ](#stringtosha512-)
  - [EncodeExtensions ](#encodeextensions-)
    - [string.ToBase64(); ](#stringtobase64-)
    - [string.FromBase64(); ](#stringfrombase64-)
  - [EncryptExtensions ](#encryptextensions-)
    - [string.Encrypt(passPhrase); ](#stringencryptpassphrase-)
    - [string.Decrypt(passPhrase); ](#stringdecryptpassphrase-)
  - [AnonymizationExtensions ](#anonymizationextensions-)
    - [string.Anonymize(); ](#stringanonymize-)
  - [UtilsAuth ](#utilsauth-)
    - [UtilsAuth.ToBasicAuth(username, password); ](#utilsauthtobasicauthusername-password-)
    - [string.FromBasicAuth(); ](#stringfrombasicauth-)
- [Contribution](#contribution)



## Support to <a name="support-to"></a>
- .NET 3.1 or more
- .NET Framework 4.6.2 or more
- .NET Standard 2.0 or more



## How to use <a name="how-to-use"></a>

### Install NuGet package <a name="installation"></a>
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


### EncodeExtensions <a name="EncodeExtensions"></a>

#### string.ToBase64(); <a name="string.ToBase64"></a>
Encode text to base64

```csharp
// result = "SGVsbG9Xb3JsZA=="
var result = "HelloWorld".ToBase64();
```

#### string.FromBase64(); <a name="string.FromBase64"></a>
Decode base64 to original text

```csharp
// result = "HelloWorld"
var result = "SGVsbG9Xb3JsZA==".FromBase64();
```


### EncryptExtensions <a name="EncryptExtensions"></a>

#### string.Encrypt(passPhrase); <a name="string.Encrypt"></a>
Encrypt text based in passPhrase

```csharp
var passPhrase = "fssdf4523543dfd";

// result = "zhwH2dmpqUebzikGD4UHnw=="
var result = "HelloWorld".Encrypt();
```

#### string.Decrypt(passPhrase); <a name="string.Decrypt"></a>
Decrypt cipher text

```csharp
var passPhrase = "fssdf4523543dfd";

// result = "HelloWorld"
var result = "zhwH2dmpqUebzikGD4UHnw==".Decrypt();
```


### AnonymizationExtensions <a name="AnonymizationExtensions"></a>

#### string.Anonymize(); <a name="string.Anonymize"></a>
Anonymize sensitive information

```csharp
// result = "N****e"
var result = "Nelson Nobre".Anonymize();
```


### UtilsAuth <a name="UtilsAuth"></a>

#### UtilsAuth.ToBasicAuth(username, password); <a name="UtilsAuth.ToBasicAuth"></a>
Encode username and password to basic authentication (btoa) [Beautiful to Awful]

```csharp
var username = "jon";
var password = "a123456";

// result = "am9uOmExMjM0NTY="
var result = UtilsAuth.ToBasicAuth(username, password);
```

#### string.FromBasicAuth(); <a name="string.FromBasicAuth"></a>
Decode from basic authentication (atob) [Awful to Beautiful]

```csharp
// username = "jon" | password = "a123456"
var result = "am9uOmExMjM0NTY=".FromBasicAuth();
```



## Contribution<a name="contribution"></a>

If you have any questions, comments, or suggestions, please open an [issue](https://github.com/TechNobre/PowerUtils.Security/issues/new/choose) or create a [pull request](https://github.com/TechNobre/PowerUtils.Security/compare)
