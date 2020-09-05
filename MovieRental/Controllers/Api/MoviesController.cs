using AutoMapper;
using MovieRental.Dtos;
using MovieRental.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieRental.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Get api/movies
        [HttpGet]
        public IHttpActionResult GetMovie()
        {
            var movieDto = _context.movies
                .Include(m=>m.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
            return Ok(movieDto);
        }

        //Get api/movies/1
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }
        //Post api/movie
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }
        //PUT api/movie/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movInDb = _context.movies.SingleOrDefault(c => c.Id == id);
            if (movInDb == null)
            {
                return NotFound();
            }
            Mapper.Map(movieDto, movInDb);

            _context.SaveChanges();
            return Ok();
        }
        //Delete api/movies/1
        [HttpDelete]
        public void Delete(int id)
        {
            var movInDb = _context.movies.SingleOrDefault(c => c.Id == id);
            if (movInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.movies.Remove(movInDb);

            _context.SaveChanges();
        }
    }
}
