namespace api.data;
using api.models;

public interface IPodcastDataSource
{
    List<Podcast> GetAllPodcasts();
    Podcast? GetPodcast(int id);
    List<Episode>? GetEpisodesForPodcast(int podcastId);

    /// <summary>
    /// Adds a new podcast to the Datasource
    /// </summary>
    /// <param name="podcast">Podcast To Insert</param>
    /// <returns>Id of newly inserted Podcast</returns>
    int AddPodcast(Podcast podcast);
    int AddEpisode(int podcastId, Episode episode);
    Episode? GetEpisode(int episodeId);
}
