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
    public class SeriesController : ControllerBase
    {

        public readonly IMongoRepository _repo;

        public SeriesController(IMongoRepository repo)
        {
            _repo = repo;
        }
        // GET: api/Series
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repo.GetSeriesAsync();
            return Ok(result);
            //var collection = _repo.Context.Database.GetCollection<Series>("Series");
            //var result = collection.Find(FilterDefinition<Series>.Empty)
            //    .ToEnumerable();
            //var res2 = await collection.Find(d => d.Title.Contains("hack")).ToEnumerable()

            //var collection = Context.Database.GetCollection<BsonDocument>("Series");
            //var result = collection.Find(new BsonDocument()).ToEnumerable().Select(
            //    d => new Series(
            //        string.IsNullOrWhiteSpace(d["seriesPageUri"].ToString()) ? default(Uri) : new Uri(d["seriesPageUri"].ToString()),
            //        string.IsNullOrWhiteSpace(d["title"].ToString()) ? default(string) : d["title"].ToString()
            //        ));
            //return Ok(result);
            //return Ok(result);
        }

        // GET: api/Series/5
        [HttpGet("{title}")]
        public async Task<IActionResult> Get(string title)
        {
            //if (string.IsNullOrEmpty(title))
            //    return BadRequest();
            //var collection = Context.Database.GetCollection<BsonDocument>("Series");
            //var filter = Builders<BsonDocument>.Filter.Eq("title", title);
            //var result = collection.Find(filter).ToEnumerable().Select(
            //    d => new Series(
            //        string.IsNullOrWhiteSpace(d["seriesPageUri"].ToString())
            //            ? default(Uri)
            //            : new Uri(d["seriesPageUri"].ToString()),
            //        string.IsNullOrWhiteSpace(d["title"].ToString()) ? default(string) : d["title"].ToString()
            //    ))?.FirstOrDefault();

            //if (result == null)
            //    return BadRequest();
            //return Ok(result);
            return null;
        }

        // POST: api/Series
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // PUT: api/Series/5
        [HttpPut("{title}")]
        public async Task<IActionResult> Put(string title, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{title}")]
        public async Task<IActionResult> Delete(string title)
        {
            throw new NotImplementedException();
        }
    }
}
