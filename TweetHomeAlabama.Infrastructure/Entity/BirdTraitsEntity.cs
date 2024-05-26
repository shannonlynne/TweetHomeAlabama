namespace TweetHomeAlabama.Data.Entity
{
    public class BirdTraitsEntity
    {
        #region Properties
        public int Id { get; set; }
        public int BirdId { get; set; }
        public string Color { get; set; }
        public string SecondaryColor { get; set; }
        public string Size { get; set; }
        public string Shape { get; set; }
        public string Habitat {  get; set; }
        #endregion

        #region Constructors
        public BirdTraitsEntity(int id, string color, string secondaryColor, string size, string shape, string habitat)
        {
            BirdId = id;
            Color = color;
            SecondaryColor = secondaryColor;
            Size = size;
            Shape = shape;
            Habitat = habitat;
        }
        #endregion

    }
}
