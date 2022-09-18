using System.ComponentModel.DataAnnotations;

namespace BoardGameVoter.Models.Enums
{
    public enum Difficulty
    {
        [Display(Name = "Easy - (QuickPlay)")]
        Easy = 0,
        [Display(Name = "Medium - (Some Learning Required)")]
        Medium = 1,
        [Display(Name = "Hard - (Complex Rule System)")]
        Hard = 2
    }
}
