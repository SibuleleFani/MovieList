using MongoDB.Bson;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieList.Data.Repository.MovieRepository;
using MovieList.Data.Model;


namespace MovieList.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _movieRepository.GetAllAsync());
        }
        [HttpGet("{id:length(24)}", Name = "GetMovie")]
        public async Task<IActionResult> Get(string id)
        {
            if (!ObjectId.TryParse(id, out var mongoId))
            {
                return NotFound();
            }
            return Ok(await _movieRepository.GetByIdAsync(mongoId));
        }

        [HttpPost]
        public async Task <IActionResult> Create(MovieDTO movie)
        {
           await _movieRepository.AddAsync(movie);

            return CreatedAtRoute("GetMovie", new { id = movie.Id.ToString() }, movie);
        }

        [HttpPut("{id:length(24)}")]
        public async Task <IActionResult> Update(string id, MovieDTO movieIn)
        {
            if (!ObjectId.TryParse(id, out var mongoId)||await _movieRepository.GetByIdAsync(mongoId)==null)
            {
                return NotFound();
            }

            await _movieRepository.UpdateAsync(new MovieDTO());

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task <IActionResult> Delete(string id)
        {        
            if (!ObjectId.TryParse(id, out var mongoId) || await _movieRepository.GetByIdAsync(mongoId) == null)
            {
                return NotFound();
            }

            await _movieRepository.RemoveAsync(mongoId);

            return NoContent();
        }
    }
}
    