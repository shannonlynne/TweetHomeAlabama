namespace TweetHomeAlabama.Infrastructure.Entity
{
    public class BirdEntity
    {
        #region Properties
        public int BirdId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Info { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string SecondaryColor { get; set; } = string.Empty;
        public string Shape { get; set; } = string.Empty;
        public string Habitat { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        #endregion

        #region Constructors
        protected BirdEntity(string name, string imageId, string info, string color, string secondaryColor,
            string shape, string habitat, string size)
        {
            Name = name;
            Image = imageId;
            Info = info;
            Color = color;
            SecondaryColor = secondaryColor;
            Shape = shape;
            Habitat = habitat;
            Size = size;
        }

        protected BirdEntity()
        { }
        #endregion
    }
}
