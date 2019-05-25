namespace pathways_api.Data
{
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<RoleType> RoleTypes { get; set; }

        public virtual DbSet<RoleLevel> RoleLevels { get; set; }

        public virtual DbSet<UserSkill> UserSkills { get; set; }

        public virtual DbSet<SkillLevel> SkillLevels { get; set; }

        public virtual DbSet<SkillType> SkillTypes { get; set; }

        public virtual DbSet<SkillTypeLevel> SkillTypeLevels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSkill>()
                .HasKey(e => new { e.UserId, e.SkillTypeId });
            modelBuilder.Entity<UserSkill>()
                .HasOne(e => e.User)
                .WithMany(e => e.UserSkills)
                .HasForeignKey(e => new { e.UserId });

            modelBuilder.Entity<RoleLevelRule>()
                .HasKey(e => new { e.RoleTypeId, e.RoleLevelId, e.SkillTypeId, e.SkillLevelId });
        }
    }
}