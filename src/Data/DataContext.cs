using System.Data.Entity;
using Data.Models.General;
using Data.Models.User;

namespace Data
{
    public class DataContext : DbContext
    {

        public DbSet<Country> Countries { get; set; }
        public DbSet<Lang> Langs { get; set; }
        public DbSet<LocalizedCountry> LocalizedCountries { get; set; }
        public DbSet<LocalizedLang> LocalizedLangs { get; set; }
        public DbSet<SpecialText> SpecialTexts { get; set; }
        public DbSet<LocalizedSpecialText> LocalizedSpecialTexts { get; set; }
        public DbSet<PasswordAnswer> PasswordAnswers { get; set; }
        public DbSet<PasswordQuestion> PasswordQuestions { get; set; }
        public DbSet<LocalizedPasswordAnswer> LocalizedPasswordAnswers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }


        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
