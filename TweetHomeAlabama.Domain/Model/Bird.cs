namespace TweetHomeAlabama.Domain.Model
{
    public class Bird
    {
        #region Properties
        public string Name { get; set; }
        public string ImageId { get; set; }
        public string Traits { get; set; }
        public string Blurb { get; set; }
        #endregion

        #region Constructors
        public Bird(string name, string imageId, string traits, string blurb)
        {
            Name = name;
            ImageId = imageId;
            Traits = traits;
            Blurb = blurb;
        }
        #endregion
    }
}
