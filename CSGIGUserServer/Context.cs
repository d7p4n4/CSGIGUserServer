﻿
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CSGIGUserServer
{
    public class Context : DbContext
    {
        public Context() : base()
        {
            //Database.SetInitializer<Context>(new CreateDatabaseIfNotExists<Context>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Migrations.Configuration>());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=217.144.51.217;Database=UserTeszt;Trusted_Connection=False;uid=SA;pwd=Sycompla9999*;");
}

        public DbSet<User> Userek { get; set; }
        public DbSet<UserToken> Tokenek { get; set; }
        public DbSet<AuthenticationRequest> Requestek { get; set; }
    }
}
