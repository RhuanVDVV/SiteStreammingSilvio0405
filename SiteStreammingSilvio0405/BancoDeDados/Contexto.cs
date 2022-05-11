using Microsoft.EntityFrameworkCore;
using SiteStreammingSilvio0405.Models;

namespace SiteStreammingSilvio0405.BancoDeDados
{
    public class Contexto:DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {


        }
        public DbSet<Streamming> Streammings { get; set; }
    }
}
