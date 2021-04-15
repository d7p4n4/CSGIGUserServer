
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CSGIGUserServer
{
    public class Context : DbContext
    {

        public string ConnectionStringBuilder(string ip, string databaseName, string username, string password)
        {

            return "Server=" + ip + ";Database=" + databaseName +
                ";Trusted_Connection=false;uid=" + username +
                ";pwd=" + password + ";";

        } // ConnectionStringBuilder

        public Context() : base()
        {
            //Database.SetInitializer<Context>(new CreateDatabaseIfNotExists<Context>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Migrations.Configuration>());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration config = null;

            config = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();

            optionsBuilder.UseSqlServer(ConnectionStringBuilder(
                                                    config["DATABASESERVER"]
                                                    ,
                                                    config["DATABASENAME"]
                                                    ,
                                                    config["DATABASEUSERNAME"]
                                                    ,
                                                    config["DATABASEPASSWORD"]));

        }

        public DbSet<User> Userek { get; set; }
        public DbSet<UserToken> Tokenek { get; set; }
        public DbSet<AuthenticationRequest> Requestek { get; set; }
    }

} // Context

