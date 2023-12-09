namespace TweetHomeAlabama.Infrastructure.Entity
{
    public class BirdEntity
    {
        #region Properties
        public int BirdId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageId { get; set; } = string.Empty;
        public string Info { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string SecondaryColor { get; set; } = string.Empty;
        public string Shape { get; set; } = string.Empty;
        public string Season { get; set; } = string.Empty;
        public string Habitat { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        #endregion

        #region Constructors
        public BirdEntity(string name, string imageId, string info, string color, string secondaryColor,
            string shape, string season, string habitat, string size)
        {
            Name = name;
            ImageId = imageId;
            Info = info;
            Color = Color;
            SecondaryColor = secondaryColor;
            Shape = shape;
            Season = season;
            Habitat = habitat;
            Size = size;
        }

        protected BirdEntity()
        { }
        #endregion
    }
}
