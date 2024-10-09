// using Microsoft.AspNetCore.Mvc;
// using api.models;
// using api.data;

// namespace api.Controllers;

// [ApiController]
// [Route("[controller]")]
// public class PodcastController : ControllerBase
// {

//     private readonly ILogger<PodcastController> _logger;
//     private readonly IPodcastDataSource _podcastDataSource;
//     public PodcastController(ILogger<PodcastController> logger, IPodcastDataSource podcastDataSource)
//     {
//         _logger = logger;
//         _podcastDataSource = podcastDataSource;
//     }

//     [HttpGet(Name = "List Podcast")]
//     [Route("")]
//     public IEnumerable<Podcast> GetAllPodcasts()
//     {
//        return _podcastDataSource.GetAllPodcasts();
//     }


//     [HttpGet(Name = "Get Podcast")]
//     [Route("{id}")]
//     public IActionResult GetPodcast(int id) {
//         Podcast? podcast = _podcastDataSource.GetPodcast(id);
        
//         if (podcast is null) {
//             return NotFound();
//         }
//          else {
//             podcast.Episodes = _podcastDataSource.GetEpisodesForPodcast(id);
//             return Ok(podcast);
//         }
//     }
//     [HttpGet(Name = "Get Episode")]
//     [Route("{id}")]
//     public IActionResult GetEpisode(int id) {
//         Episode? episode = _podcastDataSource.GetEpisode(id);
        
//         if (episode is null) {
//             return NotFound();
//         }
//          else {
//             podcast.Episodes = _podcastDataSource.GetEpisodesForPodcast(id);
//             return Ok(podcast.Episodes);
//         }
//     }

    
    
//     [HttpPost(Name = "Post Podcast")]
//     [Route("")]
//     public IActionResult AddPodcast([FromBody] Podcast podcast) {
//         int id = _podcastDataSource.AddPodcast(podcast);
//         return GetPodcast(id);
//     }

//     public IActionResult AddEpisode([FromBody] Episode episode){
//         int id = _podcastDataSource.AddEpisode(episode);
//         return GetEpisode(id);
//     }
    

// }
using Microsoft.AspNetCore.Mvc;
using api.models;
using api.data;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class PodcastController : ControllerBase
{
    private readonly ILogger<PodcastController> _logger;
    private readonly IPodcastDataSource _podcastDataSource;

    public PodcastController(ILogger<PodcastController> logger, IPodcastDataSource podcastDataSource)
    {
        _logger = logger;
        _podcastDataSource = podcastDataSource;
    }

    [HttpGet(Name = "List Podcast")]
    [Route("")]
    public IEnumerable<Podcast> GetAllPodcasts()
    {
        return _podcastDataSource.GetAllPodcasts();
    }

    [HttpGet(Name = "Get Podcast")]
    [Route("{id}")]
    public IActionResult GetPodcast(int id)
    {
        Podcast? podcast = _podcastDataSource.GetPodcast(id);

        if (podcast is null)
        {
            return NotFound();
        }
        else
        {
            podcast.Episodes = _podcastDataSource.GetEpisodesForPodcast(id);
            return Ok(podcast);
        }
    }

    [HttpGet(Name = "Get Episode")]
    [Route("episode/{id}")]
    public IActionResult GetEpisode(int id)
    {
        Episode? episode = _podcastDataSource.GetEpisode(id);

        if (episode is null)
        {
            return NotFound();
        }
        else
        {
            return Ok(episode);
        }
    }

    [HttpPost(Name = "Post Podcast")]
    [Route("")]
    public IActionResult AddPodcast([FromBody] Podcast podcast)
    {
        int id = _podcastDataSource.AddPodcast(podcast);
        return GetPodcast(id);
    }

    [HttpPost(Name = "Post Episode")]
    [Route("episode")]
    public IActionResult AddEpisode(int podcastId, [FromBody] Episode episode)
    {
        int id = _podcastDataSource.AddEpisode(podcastId, episode);
        return GetEpisode(id);
    }
}
