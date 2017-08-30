using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VideoAppUI.VideoAppDAL.Entities;

namespace VideoAppDAL.Context
{
    class InMemoryContext : DbContext
    {
        static DbContextOptions<InMemoryContext> options = new DbContextOptionsBuilder<InMemoryContext>()
            .UseInMemoryDatabase("TheDB")
            .Options;

        //what we want in the memoryDb
        public InMemoryContext() : base(options)
        {

        }

        public DbSet<Video> Videos { get; set; }
    }
}
