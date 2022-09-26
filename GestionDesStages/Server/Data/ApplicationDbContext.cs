using Duende.IdentityServer.EntityFramework.Options;
using GestionDesStages.Server.Models;
using GestionDesStages.Shared.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;



namespace GestionDesStages.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<StageStatut> StageStatut { get; set; }
        public DbSet<Stage> Stage{ get; set; }

    }
}