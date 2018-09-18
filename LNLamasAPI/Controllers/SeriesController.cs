using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNLamasAPI.Models;
using LNLamasAPI.Repository;
using LNLamaScrape.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;


namespace LNLamasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        readonly IMongoRepository _repo;

        public SeriesController(IMongoRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repo.GetSeriesAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _repo.GetSeriesAsync(id);
            return Ok(result);
        }

        [HttpPut("{title}")]
        public async Task<IActionResult> Put(string title, [FromBody]List<SeriesDto> series)
        {
            try
            {
                await _repo.PutSeriesAsync(series);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{title}")]
        public async Task<IActionResult> Delete(string title)
        {
            try
            {
                await _repo.DeleteSeriesAsync(title);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
