using Microsoft.EntityFrameworkCore;
using UtkiPhoto.Models;

namespace UtkiPhoto.Data
{
    public class UtkiPhotoContext : DbContext
    {
        public UtkiPhotoContext(DbContextOptions<UtkiPhotoContext> options)
            : base(options)
        {
        }

        public DbSet<UtkiPhoto.Models.Article> Articles { get; set; }
    }
}
