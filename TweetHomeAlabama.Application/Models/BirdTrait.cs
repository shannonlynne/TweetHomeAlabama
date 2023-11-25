using System.ComponentModel.DataAnnotations;

namespace TweetHomeAlabama.Application.Models
{
    public class BirdTrait
    {
        public Season Season { get; set; }
        public List<Color>? Colors { get; set; } = new List<Color>();
        public Shape Shape { get; set; }
        public Size Size { get; set; }
        public Habitat Habitat { get; set; }
    }

    public enum Season
    {
        Winter,
        Spring,
        Summer,
        Fall
    }
    public enum Color
    {
        Red,
        Blue,
        White,
        Gray,
        Black,
        Yellow,
        Brown
    }

    public enum Size
    {
        Tiny,
        Small,
        Medium,
        Large
    }
    public enum Shape
    {
        Tall,
        LongBeak,
        Round,
        [Display(Name = "Pointed Wing")]
        PointedWing,
        [Display(Name = "Long Tail")]
        LongTail,
        Short,
        Squat
    }

    public enum Habitat
    {
        Marsh,
        Lake,
        Pond,
        Bushes,
        Trees,
        Grassland
    }
}
