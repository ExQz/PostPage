using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataObjects;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {

        private IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<PostObject>> GetAll(int limit = 15)
        {
            var posts = await _postService.GetAllPosts(limit);
            var postObjectList = new List<PostObject>();

            foreach (var post in posts)
            {
                var postObject = new PostObject()
                {
                    Id = post.Id,
                    Author = post.Author,
                    CreateDate = post.CreateDate,
                    Text = post.Text,
                    Title = post.Title,
                    CommentCount = post.Comments.Count
                };
                postObjectList.Add(postObject);
            }

            return postObjectList;
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetPost")]
        public async Task<PostObject> Get(int id)
        {
            var postObject = new PostObject();
            var post = await _postService.GetPost(id);

            if (post != null)
            {
                postObject.Id = post.Id;
                postObject.Author = post.Author;
                postObject.CommentCount = post.Comments.Count;
                postObject.CreateDate = post.CreateDate;
                postObject.Text = post.Text;
                postObject.Title = post.Title;
            }
            else
            {
                postObject.Id = -1;
            }

            return postObject;
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostObject postObject)
        {
            var id = await _postService.CreatePost(postObject);
            postObject.Id = id;
            return CreatedAtRoute("GetPost", new {id}, postObject);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute]int id, [FromBody]PostObject postObject)
        {
            var updatedId = await  _postService.UpdatePost(postObject, id);
           
            if (updatedId == -1)
            {
                return NotFound();
            }

            return Ok(updatedId);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var callback = await _postService.DeletePost(id);
            if (callback == -1)
            {
                return NotFound();
            }

            return Ok();
            
        }
    }
}
