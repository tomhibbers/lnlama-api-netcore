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
    public class PagesController : ControllerBase
    {
        readonly IMongoRepository _repo;

        public PagesController(IMongoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repo.GetPagesAsync();
            return Ok(result);
        }

        [HttpGet("{pageRef}")]
        public async Task<IActionResult> Get(string pageRef)
        {
            var result = await _repo.GetPagesAsync(pageRef);
            return Ok(result);
        }

        [Route("ByChapter/{chapterUri}")]
        [HttpGet]
        public async Task<IActionResult> ByChapter(string chapterUri)
        {
            var result = await _repo.GetPagesByChapter(chapterUri);
            return Ok(result);
        }

        [HttpPut("{pages}")]
        public async Task<IActionResult> Put(int id, [FromBody]List<PageDto> pages)
        {
            try
            {
                await _repo.PutPagesAsync(pages);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{pageRef}")]
        public async Task<IActionResult> Delete(string pageRef)
        {
            try
            {
                await _repo.DeletePageAsync(pageRef);
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}