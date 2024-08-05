using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetCore.Infra.Common.Interfaces;

namespace App.Infra.Data.Context
{
    public class ContextBase : DbContext, IContextInfraBase
    {
        private readonly Guid TenantId;
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
            Database.Migrate();
        }

        public DbContext ContextRun()
        {
            return this;
        }
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseLoggerFactory(MyLoggerFactory);
            }
            base.OnConfiguring(optionsBuilder);
        }

        // public DbSet<TenantEntity> Tenants { get; set; }
        // public DbSet<EmpresaEntity> Empresas { get; set; }
        // public DbSet<LojaEntity> Lojas { get; set; }
        // public DbSet<ClienteEntity> ClienteEntities { get; set; }
        // public DbSet<EnderecoEntity> EnderecoEntities { get; set; }
        // public DbSet<PessoaEntity> PessoaEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>(e => e.Property(m => m.Name).HasMaxLength(256));
            builder.Entity<IdentityRole>(e => e.Property(m => m.NormalizedName).HasMaxLength(256));
            // builder.ApplyConfiguration(new ApplicationUserTypeConfiguration());

            // builder.ApplyConfiguration(new EmpresaEntityTypeConfiguration());
            // builder.ApplyConfiguration(new LojaEntityTypeConfiguration());
            // builder.ApplyConfiguration(new ClienteEntityTypeConfiguration());
            // builder.ApplyConfiguration(new ConvenioEntityTypeConfiguration());
            // builder.ApplyConfiguration(new EnderecoEntityTypeConfiguration());
            // builder.ApplyConfiguration(new PessoaEntityTypeConfiguration());

            base.OnModelCreating(builder);
        }
    }
}