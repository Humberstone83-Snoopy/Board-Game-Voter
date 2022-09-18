﻿using BoardGameVoter.Data.Shared;
using BoardGameVoter.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace BoardGameVoter.Data
{
    public class VoteSessionResultDBContext : DbContextBase<VoteSessionResult>
    {
        public VoteSessionResultDBContext(DbContextOptions<VoteSessionResultDBContext> options) : base(options)
        {
        }
    }
}
