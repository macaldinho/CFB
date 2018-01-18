namespace AssessmentCfbPractice
{
    using System.Data.Entity;

    public class AssessmentModel : DbContext
    {
        public AssessmentModel()
            : base("name=AssessmentContext")
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
