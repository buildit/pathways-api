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

        public virtual DbSet<RoleLevelRule> RoleLevelRules { get; set; }

        public virtual DbSet<UserSkill> UserSkills { get; set; }

        public virtual DbSet<SkillLevel> SkillLevels { get; set; }

        public virtual DbSet<SkillType> SkillTypes { get; set; }

        public virtual DbSet<SkillTypeLevel> SkillTypeLevels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSkill>()
                .HasIndex(e => new { e.UserId, e.SkillTypeId })
                .IsUnique();

            modelBuilder.Entity<UserSkill>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<UserSkill>()
                .HasOne(e => e.User)
                .WithMany(e => e.UserSkills)
                .HasForeignKey(e => new { e.UserId });

            modelBuilder.Entity<RoleLevelRule>()
                .HasIndex(e => new { e.RoleTypeId, e.RoleLevelId, e.SkillTypeId, e.SkillLevelId })
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(e => e.DomoIdentifier)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(e => e.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<RoleLevelRule>()
                .HasKey(e => e.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
    }
}