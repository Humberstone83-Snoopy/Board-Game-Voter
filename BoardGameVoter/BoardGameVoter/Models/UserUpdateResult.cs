namespace BoardGameVoter.Models
{
    public class UserUpdateResult
    {
        public bool Succeeded { get; set; }
        public IEnumerable<object> Errors { get; internal set; }
    }
}