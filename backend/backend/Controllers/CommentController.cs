using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataObjects;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/Comment")]
    public class CommentController : Controller
    {

        private ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // GET: api/Comment
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]long postId, int limit = 15)
        {
            var comments = await _commentService.GetAllComments(limit, postId);
            if (comments.Count == 0) return NotFound();
            return Ok(comments);
        }

        // GET: api/Comment/5
        [HttpGet("{id}", Name = "GetComment")]
        public async Task<IActionResult> Get(int id)
        {
            var comment = await _commentService.GetComment(id);
            if (comment == null) return NotFound();
            return Ok(comment);
        }
        
        // POST: api/Comment
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CommentObject comObj, [FromQuery] long postId)
        {
            var id = await _commentService.CreateComment(comObj, postId);
            if (id == -1) return NotFound();
            return CreatedAtRoute("GetComment", new {id}, comObj);
        }
        
        // PUT: api/Comment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody]CommentObject comObj)
        {
            var updatedId = await _commentService.UpdateComment(comObj, id);
            if (updatedId == -1) return NotFound();
            return Ok(updatedId);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var callback = await _commentService.DeleteComment(id);
            if (callback == -1) return NotFound();
            return Ok();
        }
    }
}
