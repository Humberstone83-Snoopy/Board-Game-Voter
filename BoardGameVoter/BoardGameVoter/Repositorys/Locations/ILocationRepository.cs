namespace BoardGameVoter.Repositorys.Locations
{
    public interface ILocationRepository
    {
        public bool IsPreExisting(string Name);
    }
}
