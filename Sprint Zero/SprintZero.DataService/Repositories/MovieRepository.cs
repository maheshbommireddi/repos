using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZero.Core;
using SprintZero.Core.Entities;

namespace SprintZero.DataService.Repositories
{
    public class MovieRepository
    {

        private List<MovieEntity> _movieListings { get; set; }

        public MovieRepository()
        {
            _movieListings = new List<MovieEntity>
            {
                new MovieEntity
                {



                },

                 new MovieEntity
                {



                },
                  new MovieEntity
                {



                }



            };
        }


        public MovieRepository(List<MovieEntity> MovieListings)
        {
            _movieListings = MovieListings;
        }

        public List<MovieEntity> GetAllMovieEntities()
        {
            return _movieListings;
        }

        public MovieEntity GetMovieEntity(int id)
        {
            return _movieListings.FirstOrDefault(i => i.Id == id);
        }
    }
}
