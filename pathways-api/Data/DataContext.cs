using Microsoft.EntityFrameworkCore;
using pathways_api.Data.Entities;

namespace pathways_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<RoleType> RoleTypes { get; set; }
        public virtual DbSet<UserSkill> UserSkills { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSkill>()
                .HasKey(e => new { e.UserId, e.SkillTypeId });
            modelBuilder.Entity<UserSkill>()
                .HasOne(e => e.User)
                .WithMany(e => e.UserSkills)
                .HasForeignKey(e => new {e.UserId});
            
            modelBuilder.Entity<RoleLevelRules>()
                .HasKey(e => new { e.RoleTypeId, e.RoleLevelId, e.SkillTypeId, e.SkillLevelId });
        }
    }
}