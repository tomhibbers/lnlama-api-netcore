using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNLamasAPI.Models;
using LNLamasAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace LNLamasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChaptersController : ControllerBase
    {
        public readonly IMongoRepository _repo;

        public ChaptersController(IMongoRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repo.GetChaptersAsync();
            return Ok(result);
        }

        // GET: api/Chapters/5
        [Route("BySeries/{title}")]
        [HttpGet]
        public async Task<IActionResult> BySeries(string title)
        {
            var result = await _repo.GetChaptersBySeriesTitleAsync(title);
            return Ok(result);
        }
        //// GET: api/Chapters/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }
        // POST: api/Chapters
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // PUT: api/Chapters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}