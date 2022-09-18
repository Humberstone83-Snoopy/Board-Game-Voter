namespace BoardGameVoter.Models
{
    public class SignInResult
    {
        public bool Succeeded { get; set; }
        public bool IsLockedOut { get; set; }
    }
}