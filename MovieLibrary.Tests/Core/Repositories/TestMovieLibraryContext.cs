using Microsoft.EntityFrameworkCore;
using MovieLibrary.Data;

namespace MovieLibrary.Tests.Core.Repositories
{
    public class TestMovieLibraryContext : MovieLibraryContext
    {
        public static DbContextOptions CreateNewOptions()
        {
            var builder = new DbContextOptionsBuilder<TestMovieLibraryContext>();
            builder.UseInMemoryDatabase("TestMovieLibraryDb");
            return builder.Options;
        }

        public TestMovieLibraryContext() : base(CreateNewOptions())
        {
        }
        public TestMovieLibraryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public override void Dispose()
        {
            this.Database.EnsureDeleted();
            base.Dispose();
        }
    }
}
