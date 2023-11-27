namespace TweetHomeAlabama.Application.Models
{
    public class Bird
    {
        public int Name { get; set; }
        public string? Info { get; set; }
        public string? ImageUrl { get; set; }
        public List<string> BirdTraits { get; set; } = new List<string>();
    }
}
