using System.ComponentModel.DataAnnotations;

namespace BoardGameVoter.Models.Enums
{
    public enum Weight
    {
        [Display(Name = "Undefined")]
        Undefined = 0,
        [Display(Name = "Ultra-Light")]
        UltraLight = 1,
        [Display(Name = "Light")]
        Light = 2,
        [Display(Name = "Mid")]
        Mid = 3,
        [Display(Name = "Heavy")]
        Heavy = 4,
        [Display(Name = "Ultra-Heavy")]
        UltraHeavy = 5

    }
}
