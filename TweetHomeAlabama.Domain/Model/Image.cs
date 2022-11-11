namespace TweetHomeAlabama.Domain.Model
{
    #region Properties
    public class Image  //TODO: Is this in the right place?
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        #endregion

        #region Constructors
        public Image(int id, string imageUrl)
        {
            Id = id;
            ImageUrl = imageUrl;
        }
        #endregion
    }
}