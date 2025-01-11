using Microsoft.EntityFrameworkCore;
using MODEL_FIRST.Models;

namespace MODEL_FIRST.Data
{
    public class DbContextModel : DbContext
    {
        public DbContextModel( DbContextOptions <DbContextModel> options): base (options)
        { }

        //mapeamento dos modelos de banco de dados
        public DbSet< Users> Users { get; set; }

        public DbSet< Orders> Orders { get; set; }


    }
}
