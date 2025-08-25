using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Dtos;
using MoviesAPI.Models;
using MoviesAPI.Serves;
using System.Security.AccessControl;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieServes _movieServes;
        private readonly IGenreServes _GenreServes;


        public MoviesController(IMovieServes movieServes, IGenreServes genreServes)
        {
            _movieServes = movieServes;
            _GenreServes = genreServes;
        }

        // get all Movies 
        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movieServes.GetAll();
            return Ok(movies);
        }

         // get Movies by genreId 
         [HttpGet("{id}")]
         public async Task<IActionResult> GetMovieByGenreId(int id)
         {
             if (!await _GenreServes.IsExist(id))
                 return NotFound($"This Genre id={id} Not found!");
        
             var movies = await _movieServes.GetByGenreId(id);
        
             return Ok(movies);
         }

        // create Movie 
        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromForm] MovieDto dto)
        {
            if (!await _GenreServes.IsExist(dto.GenreId))
                return NotFound($"No Genre with id = {dto.GenreId}");

            var movie = await _movieServes.CreateMovie(dto);

            return Ok(movie);
        }


        // update Movie 
        [HttpPut("{movieId}")]
        public async Task<IActionResult> UpdateMovie([FromForm] MovieDto dto, int movieId)
        {
            if (!await _GenreServes.IsExist(dto.GenreId))
                return NotFound($"No Genre with id = {dto.GenreId}");

            if (!await _movieServes.IsExist(movieId))
                return NotFound($"No Movie with id = {movieId}");

            var movie = await _movieServes.UpdateMovie(dto, movieId);

            return Ok(movie);
        }


        // delete Movie 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (!await _movieServes.IsExist(id))
                return NotFound($"No Movie with id = {id}");

            var movie = await _movieServes.DeleteMovie(id);

            return Ok(movie);
        }
    }
}
