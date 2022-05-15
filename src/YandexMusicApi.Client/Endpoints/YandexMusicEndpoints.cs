namespace YandexMusicApi.Client;

internal static class YandexMusicEndpoints
{
    private static readonly Uri Api = new Uri("https://api.music.yandex.net");
    
    public static Uri SetLike(SectionType sectionType, string userId, bool like = true) 
    {
        var actionName = like ? "add-multiple" : "remove";

        return new Uri($"{Api}users/{userId}/likes/{sectionType}s/{actionName}");
    }

    public static Uri SetDislike(SectionType sectionType, string userId, bool dislike = true)
    {
        var actionName = dislike ? "add-multiple" : "remove";

        return new Uri($"{Api}users/{userId}/dislikes/{sectionType}s/{actionName}");
    }

    public static Uri Search(SectionType sectionType, string text, int pageIndex, bool textCorrection)
    {
        return QueryUriBuilder.New($"{Api}search")
                              .AddQueryParameter("text", text)
                              .AddQueryParameter("type", sectionType)
                              .AddQueryParameter("page", pageIndex)
                              .AddQueryParameter("nocorrect", !textCorrection)
                              .Build();
    }

    public static Uri Get(SectionType sectionType, IEnumerable<string> ids)
    {
        var idsQuery = string.Join(",", ids);
        
        return new Uri($"{Api}{sectionType}s?{sectionType}-ids={idsQuery}");
    }

    internal static class AccountEndpoints
    {
        public static readonly Uri AccountStatus = new Uri($"{Api}account/status");
        
        public static Uri AccountInfo(string uidOrLogin) => new Uri($"{Api}users/{uidOrLogin}");
    
        public static readonly Uri AccountSettings = new Uri($"{Api}account/settings");
    }
    
    internal static class TracksEndpoints
    {
        public static Uri GetSimilarTracks(string trackId) => new Uri($"{Api}tracks/{trackId}/similar");

        public static Uri GetTrackSupplement(string trackId) => new Uri($"{Api}tracks/{trackId}/supplement");
        
        public static Uri TrackDownloadInfo(string trackId, string albumId) => new Uri($"{Api}tracks/{trackId}:{albumId}/download-info");
    }

    internal static class AlbumsEndpoints
    {
        public static Uri GetWithTracks(string albumId) => new Uri($"{Api}/albums/{albumId}/with-tracks");
    }

    internal static class ArtistsEndpoints
    {
        public static Uri GetTracks(string artistId, int pageIndex, int pageSize)
        {
            return QueryUriBuilder.New($"{Api}artists/{artistId}/tracks")
                                  .AddQueryParameter("page", pageIndex)
                                  .AddQueryParameter("page-size", pageSize)
                                  .Build();
        }

        public static Uri GetAlbums(string artistId, int pageIndex, int pageSize, SortType sortType)
        {
            return QueryUriBuilder.New($"{Api}artists/{artistId}/direct-albums")
                                  .AddQueryParameter("page", pageIndex)
                                  .AddQueryParameter("page-size", pageSize)
                                  .AddQueryParameter("sort-by", sortType)
                                  .Build();
        }

        public static Uri GetBriefInfo(string artistId) => new Uri($"{Api}artists/{artistId}/brief-info");
    }
}