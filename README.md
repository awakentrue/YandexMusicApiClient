<h1 align="center">
    <p align="center">Yandex.Music API client (unofficial)</p>
    <img
      height="200"
      width="200"
      src="https://upload.wikimedia.org/wikipedia/commons/thumb/e/e7/Yandex_Music_icon.svg/2048px-Yandex_Music_icon.svg.png"
      alt="Yandex.Music API client">
</h1>

[![License](https://img.shields.io/github/license/awakentrue/YandexMusicApiClient?style=flat-square)](./LICENSE)
[![NuGet version](https://img.shields.io/nuget/v/YandexMusicApi.Client.svg?style=flat-square)](https://nuget.org/packages/YandexMusicApi.Client)
[![NuGet downloads](https://img.shields.io/nuget/dt/YandexMusicApi.Client.svg?style=flat-square)](https://nuget.org/packages/YandexMusicApi.Client)

Unofficial client for Yandex.Music API written in C#/.NET

## Quick start
You can find package on [NuGet](https://www.nuget.org/packages/YandexMusicApi.Client)

### Install from Package Managers
#### .NET CLI
```dotnet add package YandexMusicApi.Client```

#### Package Manager
```Install-Package YandexMusicApi.Client```

### Creating a client

#### To register it with DI container
```csharp
// with authorization token:
services.AddAuthorizedYandexMusicApiClient("token");
// else
services.AddGuestYandexMusicApiClient();
```

#### Using without DI container
```csharp
// with authorization token:
var client = new YandexMusicClient(RestClient.Authorized("token"));
// else
var client = new YandexMusicClient();
```

### Example
```csharp
using System;
using YandexMusicApi.Client;

class Program
{
    static async Task Main()
    {
        var client = new YandexMusicClient();
        
        var track = await client.Tracks.GetAsync("trackId"); // get track by id
        
        var albums = await client.Albums.SearchAsync("album title"); // search for albums by title
        
        var genres = await client.Genres.GetAsync(); // get all genres
    }
}
```

## Documentation
Coming soon...
