using DictionaryWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DictionaryWebAPI.Controllers
{
    public class DictionaryController : ApiController
    {
        private DictionaryContext _db = new DictionaryContext();

        public IHttpActionResult GetWordInfo(string word)
        {
            if(string.IsNullOrEmpty(word))
            {
                return BadRequest();
            }
            var wordInfo = _db.Words.Where(w => w.word == word)?.Include(w => w.Definitions);
            if(wordInfo == null)
            {
                return NotFound();
            }
            return Ok(wordInfo);
        }
    }
}
