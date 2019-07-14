using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoProject.DTOs;
using VideoProject.Models;

namespace VideoProject.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/movies
        public IHttpActionResult GetMovies()
        {
            var movies = _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDTO>);
            return Ok(movies);
        }

        // GET api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDTO>(movieInDb));
        }

        // POST api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);


            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDTO.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDTO);
        }

        // PUT api/movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
            {
                NotFound();
            }

            Mapper.Map(movieDTO, movieInDb);

            _context.SaveChanges();

            return Ok();
        }
        
        // DELETE api/movies/1
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieToDelete = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieToDelete == null)
            {
                NotFound();
            }

            _context.Movies.Remove(movieToDelete);
            _context.SaveChanges();

            return Ok();
        }
    }
}
