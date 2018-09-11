﻿using System;
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
    public class ChapterController : ControllerBase
    {
        public readonly MongoContext Context;

        public ChapterController(MongoContext context)
        {
            Context = context;
        }
        // GET: api/Chapter
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var collection = Context.Database.GetCollection<BsonDocument>("Chapter");
            var result = collection.Find(new BsonDocument()).ToEnumerable().Select(
                d => new Series(
                    string.IsNullOrWhiteSpace(d["seriesPageUri"].ToString()) ? default(Uri) : new Uri(d["seriesPageUri"].ToString()),
                    string.IsNullOrWhiteSpace(d["title"].ToString()) ? default(string) : d["title"].ToString()
                ));
            return Ok(result);
        }
        // GET: api/Chapter/5
        [HttpGet("{title}")]
        public async Task<IActionResult> Get(string title)
        {
            if (string.IsNullOrEmpty(title))
                return BadRequest();
            var collection = Context.Database.GetCollection<BsonDocument>("Chapter");
            var filter = Builders<BsonDocument>.Filter.Eq("title", title);
            var result = collection.Find(filter).ToEnumerable().Select(
                d => new Series(
                    string.IsNullOrWhiteSpace(d["seriesPageUri"].ToString())
                        ? default(Uri)
                        : new Uri(d["seriesPageUri"].ToString()),
                    string.IsNullOrWhiteSpace(d["title"].ToString()) ? default(string) : d["title"].ToString()
                ))?.FirstOrDefault();

            if (result == null)
                return BadRequest();
            return Ok(result);
        }
        // POST: api/Chapter
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            return BadRequest();
        }

        // PUT: api/Chapter/5
        [HttpPut("{title}")]
        public async Task<IActionResult> Put(string title, [FromBody] string value)
        {
            return BadRequest();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{title}")]
        public async Task<IActionResult> Delete(string title)
        {
            return BadRequest();
        }
    }
}