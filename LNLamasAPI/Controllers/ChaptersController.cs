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
        readonly IMongoRepository _repo;

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

        [HttpGet("{chapterRef}")]
        public async Task<IActionResult> Get(string chapterRef)
        {
            var result = await _repo.GetChaptersAsync(chapterRef);
            return Ok(result);
        }

        [Route("BySeries/{title}")]
        [HttpGet]
        public async Task<IActionResult> BySeries(string title)
        {
            var result = await _repo.GetChaptersBySeriesAsync(title);
            return Ok(result);
        }

        [HttpPut("{chapters}")]
        public async Task<IActionResult> Put(int id, [FromBody]List<Chapter> chapters)
        {
            try
            {
                await _repo.PutChaptersAsync(chapters);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{chapterRef}")]
        public async Task<IActionResult> Delete(string chapterRef)
        {
            try
            {
                await _repo.DeleteChapterAsync(chapterRef);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}