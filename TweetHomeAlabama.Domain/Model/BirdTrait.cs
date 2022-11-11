namespace TweetHomeAlabama.Domain.Model
{
    #region Properties
    public class BirdTrait
    {
        public string Season { get; set; }
        public string Shape { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int Habitat { get; set; }
        #endregion

        #region Constructors
        public BirdTrait(string season, string shape, string size, string color, int habitat)
        {
            Season = season;
            Shape = shape;
            Size = size;
            Color = color;
            Habitat = habitat;
        }
        #endregion
    }
}
