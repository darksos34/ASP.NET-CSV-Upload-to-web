using System.Data.Entity;

namespace CVSUpload.Models
{
    public class UploadContext : DbContext
    {
        public UploadContext() : base("ConString")
        {
 
        }
        public DbSet<StudentCSV> Students { get; set; }
    }
}