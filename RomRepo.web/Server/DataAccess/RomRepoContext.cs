using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RomRepo.web.Server.Models;
using System.Configuration;
using System.Diagnostics;

namespace RomRepo.web.Server.DataAccess
{
    public class RomRepoContext : DbContext
    {
        /// <summary>
        /// Magic string.
        /// </summary>
        public static readonly string RowVersion = nameof(RowVersion);

        /// <summary>
        /// Magic strings.
        /// </summary>
        public static readonly string RomRepoDb = nameof(RomRepoDb).ToLower();

        /// <summary>
        /// Inject options.
        /// </summary>
        /// <param name="options">The <see cref="DbContextOptions{RomRepoContext}"/>
        /// for the context
        /// </param>
        public RomRepoContext(DbContextOptions<RomRepoContext> options)
            : base(options)
        {
            Debug.WriteLine($"{ContextId} context created.");
        }

        /// <summary>
        /// List of <see cref="Core"/>.
        /// </summary>
        public DbSet<Core> Cores { get; set; }

        /// <summary>
        /// List of <see cref="Rom"/>.
        /// </summary>
        public DbSet<Rom> Roms { get; set; }

        /// <summary>
        /// Define the model.
        /// </summary>
        /// <param name="modelBuilder">The <see cref="ModelBuilder"/>.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // this property isn't on the C# class
            // so we set it up as a "shadow" property and use it for concurrency
            modelBuilder.Entity<Core>()
                .Property<byte[]>(RowVersion)
                .IsRowVersion();

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Dispose pattern.
        /// </summary>
        public override void Dispose()
        {
            Debug.WriteLine($"{ContextId} context disposed.");
            base.Dispose();
        }

        /// <summary>
        /// Dispose pattern.
        /// </summary>
        /// <returns>A <see cref="ValueTask"/></returns>
        public override ValueTask DisposeAsync()
        {
            Debug.WriteLine($"{ContextId} context disposed async.");
            return base.DisposeAsync();
        }
    }
}
