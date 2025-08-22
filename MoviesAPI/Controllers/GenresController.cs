using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Dtos;
using MoviesAPI.Serves;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreServes _serves;

        public GenresController(IGenreServes serves)
        {
            _serves = serves;
        }

        // get all Genres
        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            return Ok(await _serves.GetAll());
        }

        // get genre by id 
        [HttpGet("{id}")] 
        public async Task<IActionResult> GetGenreByID(int id)
        {
            var genre = await _serves.GetById(id);
            
            if(genre == null) 
                return NotFound($"Genre id={id} not found!");

            return Ok(genre);
        }

        // create genre
        [HttpPost]
        public async Task<IActionResult> CreateGenre(GenreDto dto)
        {
            var genre = await _serves.Create(dto);
            return Ok(genre);
        }

        // update genre
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(int id , GenreDto dto)
        {
            var genre = await _serves.Update(id, dto);
            
            if (genre == null)
                return NotFound($"Genre id={id} not found!");

            return Ok(genre);
        }


        // delete genre
        [HttpDelete("{id}")]
        public async Task<IActionResult> DelertGenre(int id)
        {
            var genre = await _serves.Delete(id);

            if (genre == null)
                return NotFound($"Genre id={id} not found!");

            return Ok(genre);
        }
    }
}
