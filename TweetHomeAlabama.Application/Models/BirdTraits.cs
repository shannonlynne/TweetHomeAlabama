using System.ComponentModel.DataAnnotations;

namespace TweetHomeAlabama.Application.Models
{
    public class BirdTraits
    {
        public Season Season { get; set; }
        public Color Color { get; set; }
        public Shape Shape { get; set; }
        public Size Size { get; set; }
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
        Green,
        Blue,
        White,
        Gray,
        Black,
        Yellow,
        Orange,
        Purple,
        Teal
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
        [Display(Name = "Long Legs")]
        LongLegs,
        [Display(Name = "Long Beak")]
        LongBeak,
        [Display(Name = "Rounded Beak")]
        RoundedBeak,
        Round,
        [Display(Name = "Pointed Wing")]
        PointedWing,
        [Display(Name = "Narrow Tail")]
        NarrowTail,
        [Display(Name = "Long Tail")]
        LongTail,
        Short,
        Squat
    }
}
