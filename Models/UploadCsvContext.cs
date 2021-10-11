using System.Data.Entity;

namespace CVSUpload.Models
{
    public class UploadCsvContext : DbContext
    {
        public UploadCsvContext() : base("ConString")
        {
 
        }
        public DbSet<StudentXLSX> Students { get; set; }
    }
}