using ApiCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCRUD.Context
{
    public class DbArticuloContext : DbContext
    {
        public DbArticuloContext(DbContextOptions<DbArticuloContext> opciones): base(opciones)
        {
        } 

        public DbSet<Articulo> Articulos {get; set;}
    }
}