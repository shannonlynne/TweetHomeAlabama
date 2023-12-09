namespace TweetHomeAlabama.Infrastructure.Entity
{
    public class BirdEntity
    {
        #region Properties
        public int BirdId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageId { get; set; } = string.Empty;
        public string Traits { get; set; } = string.Empty;
        public string Info { get; set; } = string.Empty;
        #endregion

        #region Constructors
        public BirdEntity(string name, string imageId, string traits, string info)
        {
            Name = name;
            ImageId = imageId;
            Traits = traits;
            Info = info;
        }

        protected BirdEntity()
        { }
        #endregion
    }
}
