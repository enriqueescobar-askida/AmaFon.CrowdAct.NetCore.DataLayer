namespace Console.DataLayer.Contexts
{
    using Microsoft.EntityFrameworkCore.Design;

    /// <summary>
    /// Defines the <see cref="CrowdActDbContextFactory" />
    /// </summary>
    public class CrowdActDbContextFactory : IDesignTimeDbContextFactory<CrowdActDbContext> // IDbContextFactory<CrowdActDbContext>
    {
        /// <summary>
        /// The CreateDbContext
        /// </summary>
        /// <param name="args">The args<see cref="string[]"/></param>
        /// <returns>The <see cref="CrowdActDbContext"/></returns>
        public CrowdActDbContext CreateDbContext(string[] args)
        {
            return new CrowdActDbContext();
        }
    }
}
