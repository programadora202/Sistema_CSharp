// ============================================================
// Data/AppDbContext.cs
// ============================================================

using Microsoft.EntityFrameworkCore;
using MoveisCarrara.Models;

namespace MoveisCarrara.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Pessoa>           Pessoas           { get; set; }
        public DbSet<Cliente>          Clientes          { get; set; }
        public DbSet<Fornecedor>       Fornecedores      { get; set; }
        public DbSet<Funcionario>      Funcionarios      { get; set; }
        public DbSet<Situacao>         Situacoes         { get; set; }
        public DbSet<Lancamento>       Lancamentos       { get; set; }
        public DbSet<Produto>          Produtos          { get; set; }
        public DbSet<Material>         Materiais         { get; set; }
        public DbSet<Venda>            Vendas            { get; set; }
        public DbSet<Compra>           Compras           { get; set; }
        public DbSet<Venda_produto> VendaProdutos { get; set; }
        public DbSet<CompraMaterial> CompraMateriais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.ToTable("Pessoas");
                entity.Property(p => p.Id).HasColumnName("id");
                entity.Property(p => p.Nome).HasColumnName("nome");
                entity.Property(p => p.NomeSocial).HasColumnName("nome_social");
                entity.Property(p => p.TipoPessoa).HasColumnName("tipo_pessoa");
                entity.Property(p => p.Documento).HasColumnName("documento");
                entity.Property(p => p.TipoEndereco).HasColumnName("tipo_endereco");
                entity.Property(p => p.Logradouro).HasColumnName("logradouro");
                entity.Property(p => p.Numero).HasColumnName("numero");
                entity.Property(p => p.Bairro).HasColumnName("bairro");
                entity.Property(p => p.Cidade).HasColumnName("cidade");
                entity.Property(p => p.Cep).HasColumnName("cep");
                entity.Property(p => p.Telefone).HasColumnName("telefone");
                entity.Property(p => p.Email).HasColumnName("email");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.ToTable("Funcionarios");
                entity.Property(f => f.Usuario).HasColumnName("usuario");
                entity.Property(f => f.Senha).HasColumnName("senha");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.Property(s => s.Codigo).HasColumnName("codigo");
                entity.Property(s => s.Descricao).HasColumnName("descricao");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.Property(p => p.Codigo).HasColumnName("codigo");
                entity.Property(p => p.NomeProduto).HasColumnName("nome_produto");
                entity.Property(p => p.Descricao).HasColumnName("descricao");
                entity.Property(p => p.ValorUnitario).HasColumnName("valor_unitario");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.Property(m => m.Codigo).HasColumnName("codigo");
                entity.Property(m => m.NomeMaterial).HasColumnName("nome_material");
                entity.Property(m => m.Preco).HasColumnName("preco");
                entity.Property(m => m.Descricao).HasColumnName("descricao");
            });

            // Chave primária composta: (venda_codigo, item)
            modelBuilder.Entity<Venda_produto>(entity =>
            {
                entity.HasKey(v => new { v.VendaCodigo, v.Item });
                entity.ToTable("vendas_produtos");
            });

            // COMPRAS_MATERIAIS
            modelBuilder.Entity<CompraMaterial>(entity =>
            {
                entity.ToTable("compras_materiais");
                entity.HasKey(c => new{c.CompraCodigo, c.Item});

                entity.Property(c => c.CompraCodigo).HasColumnName("compra_codigo");
                entity.Property(c => c.MaterialCodigo).HasColumnName("material_codigo");
                entity.Property(c => c.Item).HasColumnName("item");
                entity.Property(c => c.Qtd).HasColumnName("qtd");
                entity.Property(c => c.Preco).HasColumnName("preco");
                entity.Property(c => c.Dimensoes).HasColumnName("dimensoes");
                entity.Property(c => c.Descricao).HasColumnName("descricao");
            });
        }
    }
}
