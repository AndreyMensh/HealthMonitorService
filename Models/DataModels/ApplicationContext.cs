using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using HealthMonitorServiceModels;

namespace HealthMonitorService.Models.DataModels
{
    public class ApplicationContext : DbContext
    {
        public DbSet<TableUnitModel> Unit { get; set; }
        public DbSet<TableIncidentModeratorModel> IncidentModerator { get; set; }
        public DbSet<TableIncidentTicketModel> IncidentTicket { get; set; }
        public DbSet<TableRelationUnitModeratorModel> RelationUnitModerator { get; set; }
        public DbSet<TableIncidentTypeModel> IncidentType { get; set; }
        public DbSet<TableNotificationModel> Notification { get; set; }
        public DbSet<TableExecutionModel> Execution { get; set; }
        public DbSet<TableActionModel> Action { get; set; }
        public DbSet<TableActionLogModel> ActionLog  { get; set; }

        //public IConfiguration AppConfiguration { get; set; }

        //public ApplicationContext()
        //{
        //    Database.EnsureCreated();
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var builder = new ConfigurationBuilder().AddJsonFile("connections.json");
        //    AppConfiguration = builder.Build();

        //    IConfigurationSection connStrings = AppConfiguration.GetSection("ConnectionStrings");
        //    string defaultConnection = connStrings.GetSection("DefaultConnection").Value;

        //    optionsBuilder.UseSqlServer(defaultConnection);
        //}

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }


    }
}
