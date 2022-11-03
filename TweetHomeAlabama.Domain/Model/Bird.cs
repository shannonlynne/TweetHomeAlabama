namespace TweetHomeAlabama.Domain.Model
{
    public class Bird
    {
        #region Properties
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageId { get; set; }
        public string? Traits { get; set; }
        public string? Blurb { get; set; }
        #endregion

        #region Constructors
        public Bird()
        {

        }
        #endregion
    }
}
