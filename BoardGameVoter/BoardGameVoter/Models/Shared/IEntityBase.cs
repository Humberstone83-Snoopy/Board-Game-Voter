namespace BoardGameVoter.Models.Shared
{
    public interface IEntityBase
    {
        int ID { get; set; }
        Guid UID { get; set; }
    }
}
