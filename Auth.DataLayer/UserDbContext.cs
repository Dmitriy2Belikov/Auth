using Auth.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Auth.DataLayer
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>()
                .HasKey(p => new { p.RoleId, p.WorkingEntityOperationId });

            modelBuilder.Entity<UserRoleLink>()
                .HasKey(u => new { u.UserId, u.RoleId });

            modelBuilder.Entity<RoleSystemModuleLink>()
                .HasKey(r => new { r.RoleId, r.SystemModuleId });

            modelBuilder.Entity<OrganizationDistrictLink>()
                .HasKey(o => new { o.OrganizationId, o.DistrictId});
        }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationDistrictLink> OrganizationDistrictLinks { get; set; }
        public DbSet<OrganizationType> OrganizationTypes { get; set; }
        public DbSet<OrganizationRequisite> OrganizationRequisites { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoleLink> UserRoleLinks { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RoleSystemModuleLink> RoleSystemModuleLinks { get; set; }
        public DbSet<SystemModule> SystemModules { get; set; }
        public DbSet<WorkingEntity> WorkingEntities { get; set; }
        public DbSet<WorkingEntityOperation> WorkingEntityOperations { get; set; }
        public DbSet<RefreshSession> RefreshSessions { get; set; }
    }
}
