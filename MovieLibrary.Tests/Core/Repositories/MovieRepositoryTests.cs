using MovieLibrary.Core.Repositories;
using MovieLibrary.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MovieLibrary.Tests.Core.Repositories
{
    public class MovieRepositoryTests
    {
        public static IEnumerable<object[]> FilteringByCategoriesTestData()
        {
            var category1 = new Category
            {
                Id = 1,
                Name = "Test category 1"
            };

            var category2 = new Category
            {
                Id = 2,
                Name = "Test category 2"
            };

            var movie1 = CreateTestMovie(1);
            movie1.MovieCategories.Add(new MovieCategory
            {
                Id = 1,
                Category = category1,
                CategoryId = category1.Id,
                Movie = movie1,
                MovieId = movie1.Id
            });
            movie1.MovieCategories.Add(new MovieCategory
            {
                Id = 2,
                Category = category2,
                CategoryId = category2.Id,
                Movie = movie1,
                MovieId = movie1.Id
            });

            var movie2 = CreateTestMovie(2);
            movie2.MovieCategories.Add(new MovieCategory
            {
                Id = 3,
                Category = category2,
                CategoryId = category2.Id,
                Movie = movie2,
                MovieId = movie2.Id
            });

            return new List<object[]>
            {
                new object[] 
                { 
                    new List<Movie>
                    {
                        movie1,
                        movie2
                    },
                    new List<Category>
                    {
                        category1
                    },
                    new List<Movie>
                    {
                        movie1
                    }
                }
            };
        }

        [Theory]
        [MemberData(nameof(FilteringByCategoriesTestData))]
        public void FilteringByCategoriesReturnsMoviesWithAtLeastOneGivenCategory(List<Movie> movies, List<Category> categories, List<Movie> expectedResult)
        {
            using (var context = new TestMovieLibraryContext())
            {
                context.Movies.AddRange(movies);
                context.SaveChanges();
                MovieRepository movieRepository = new MovieRepository(context);

                var result = movieRepository.FilterByCategories(context.Movies, categories).ToList();

                Assert.Equal(expectedResult.Count, result.Count);
                foreach(var expectedItem in expectedResult )
                {
                    Assert.Contains(result, resultFragment => resultFragment.Id == expectedItem.Id);
                }
            }
        }

        public static Movie CreateTestMovie(int i)
        {
            return new Movie
            {
                Id = i,
                Title = $"Movie {i}",
                Description = $"Movie {i} description",
                ImdbRating = i % 10,
                Year = 1950 + i,
            };
        }

        public static IEnumerable<object[]> MoviesWithDescendingRating =>
        new List<object[]>
        {
            new object[] { new List<Movie>
                {
                    CreateTestMovie(3),
                    CreateTestMovie(2),
                    CreateTestMovie(1),
                }
            },
        };

        [Theory]
        [MemberData(nameof(MoviesWithDescendingRating))]
        public void DefaultFilteringReturnsAllMoviesSortedDescendingByRating(List<Movie> expectedResult)
        {
            using (var context = new TestMovieLibraryContext())
            {
                context.AddRange(expectedResult);
                context.SaveChanges();
                MovieRepository movieRepository = new MovieRepository(context);

                var result = movieRepository.Get(default, default, default, default, default, default).ToList();

                Assert.Equal(expectedResult.Count, result.Count);
                for (var i = 0; i < expectedResult.Count; ++i)
                {
                    Assert.Equal(expectedResult[i].Id, result[i].Id);
                }
            }
        }
    }
}
