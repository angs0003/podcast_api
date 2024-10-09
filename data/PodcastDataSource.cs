namespace api.data;
using api.models;

public class PodcastDataSource : IPodcastDataSource{

    int AddEpisode(int podcastId, Episode episode);
    private static readonly List<Podcast> _dataSource = 
            new List<Podcast> { new Podcast
        {
            Id = 1,
            Name = "Doesn't matter what we call these",
            Episodes = new List<Episode>
            {
                new Episode
                {
                    Id = 1,
                    GuestAuthor = "Ryan",
                    Name = "Ryan Show",
                    Length = 13.5
                },
                new Episode
                {
                    Id = 2,
                    GuestAuthor = "Me gusta",
                    Name = "Potato",
                    Length = 23.3
                }
            }
        },
        new Podcast
        {
            Id = 2,
            Name = "Never gonna give you up",
            Episodes = new List<Episode>
            {
                new Episode
                {
                    Id = 3,
                    GuestAuthor = "Silly",
                    Name = "Not Vim Friendly",
                    Length = 56.5
                }
            }
        },
        new Podcast
        {
            Id = 3,
            Name = "Let you down",
            Episodes = new List<Episode>()
        },
        new Podcast
        {
            Id = 4,
            Name = "Never gonna turn you around Rick",
            Episodes = new List<Episode>()
        }
    };

    public List<Podcast> GetAllPodcasts() {
        return _dataSource.Select(podcast => new Podcast {Id = podcast.Id, Name = podcast.Name}).ToList();
    }
    public Podcast? GetPodcast(int id){
        return GetAllPodcasts().Where(podcast => podcast.Id == id).FirstOrDefault();
    }
    public List<Episode>? GetEpisodesForPodcast(int podcastId) {
        return _dataSource.Where(podcast => podcast.Id == podcastId).FirstOrDefault()?.Episodes;
    }

    public int AddPodcast(Podcast podcast){

        Podcast newPodcast = new Podcast{
            Name = podcast.Name,
            Id = _dataSource.Select(podcast => podcast.Id).Max()+1
        };
        _dataSource.Add(newPodcast);
        return newPodcast.Id;
    }

    
    public int AddEpisode(int podcastId, Episode episode)
    {
        var podcast = _dataSource.FirstOrDefault(p => p.Id == podcastId);
        if (podcast == null)
        {
            throw new ArgumentException("Podcast not found");
        }

        Episode newEpisode = new Episode
        {
            Name = episode.Name,
            Id = podcast.Episodes.Select(e => e.Id).DefaultIfEmpty(0).Max() + 1,
            GuestAuthor = episode.GuestAuthor
        };
        podcast.Episodes.Add(newEpisode);
        return newEpisode.Id;
    }

    public Episode? GetEpisode(int episodeId)
    {
        return _dataSource.SelectMany(p => p.Episodes).FirstOrDefault(e => e.Id == episodeId);
    }
}   
