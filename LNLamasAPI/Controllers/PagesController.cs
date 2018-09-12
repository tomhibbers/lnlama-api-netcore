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

namespace LNLamasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController : ControllerBase
    {
        public readonly IMongoRepository _repo;

        public PagesController(IMongoRepository repo)
        {
            _repo = repo;
        }
        // GET: api/Pages
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repo.GetPagesAsync();
            return Ok(result);
        }
        [Route("ByChapter/{chapterUri}")]
        [HttpGet]
        public async Task<IActionResult> ByChapter(string chapterUri)
        {
            var result = await _repo.GetPagesByChapterUri(chapterUri);
            return Ok(result);
        }
        // GET: api/Pages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }
        // POST: api/Pages
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // PUT: api/Pages/5
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