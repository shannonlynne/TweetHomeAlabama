namespace TweetHomeAlabama.Domain.Model
{
    public class Bird
    {
        #region Properties
        public string Name { get; set; }
        public string Image { get; set; }
        public string Info { get; set; }
        #endregion

        #region Constructors
        public Bird(string name, string image, string info)
        {
            Name = name;
            Image = image;
            Info = info;
        }
        #endregion
    }
}
