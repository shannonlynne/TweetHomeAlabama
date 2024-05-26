namespace TweetHomeAlabama.Data.Entity
{
    public class BirdEntity
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Info { get; set; } = string.Empty;
        #endregion

        #region Constructors
        public BirdEntity(string name, string imageId, string info)
        {
            Name = name;
            Image = imageId;
            Info = info;
        }

        protected BirdEntity()
        { }
        #endregion
    }
}
