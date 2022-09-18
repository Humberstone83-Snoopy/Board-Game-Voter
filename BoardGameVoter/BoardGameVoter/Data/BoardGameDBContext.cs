using BoardGameVoter.Data.Shared;
using BoardGameVoter.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace BoardGameVoter.Data
{
    public class BoardGameDBContext : DbContextBase<BoardGame>
    {
        public BoardGameDBContext(DbContextOptions<BoardGameDBContext> options) : base(options)
        {
        }
    }
}