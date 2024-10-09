namespace api.models;

public class Podcast {

    public int Id { get; set; }
    public string Name { get; set; }
    public List<Episode>? Episodes { get; set; }
}


