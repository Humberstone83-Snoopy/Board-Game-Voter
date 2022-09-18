﻿using BoardGameVoter.Data.Shared;
using BoardGameVoter.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace BoardGameVoter.Data
{
    public class VoteSessionDBContext : DbContextBase<VoteSession>
    {
        public VoteSessionDBContext(DbContextOptions<VoteSessionDBContext> options) : base(options)
        {
        }
    }
}
