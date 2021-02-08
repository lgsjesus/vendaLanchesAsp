//using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using vendaLanchesAsp.Models;

namespace vendaLanchesAsp.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base (options)
        { }
        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoDetalhe> PedidoDetalhes { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string connectionString = "server=localhost;port=3306;database=SchoolDB;user=root;password=******";
        //    optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new System.Version(8, 0, 22)), mySqlOptions => mySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend));
        //}
    }
}
