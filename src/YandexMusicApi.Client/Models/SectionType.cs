namespace YandexMusicApi.Client;

public enum SectionType
{
    All,
    Track,
    Artist,
    Playlist,
    Album,
    User,
}

public static class SectionTypeExtensions
{
    public static string GetName(this SectionType sectionType)
    {
        return sectionType.ToString().ToLower();
    }
}