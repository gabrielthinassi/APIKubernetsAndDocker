using APIKubernetsAndDocker.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using APIKubernetsAndDocker.Models;

namespace APIKubernetsAndDocker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private IBlogPostRepository _blogPostRepository;
        public BlogPostController(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        [ProducesResponseType(typeof(List<BlogPost>), (int)HttpStatusCode.OK)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _blogPostRepository.GetAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(BlogPost), (int)HttpStatusCode.OK)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var blogPost = await _blogPostRepository.GetByIdAsync(id);
                if (blogPost == null)
                {
                    return NotFound();
                }
                return Ok(blogPost);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BlogPost blogPost)
        {
            try
            {
                bool isSuccess = await _blogPostRepository.CreateAsync(blogPost);
                if (isSuccess)
                {
                    return Ok("Post Added!");
                }
                return BadRequest("Post Failed to Add!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] BlogPost blogPost)
        {
            try
            {
                bool isSuccess = await _blogPostRepository.UpdateAsync(blogPost);
                if (isSuccess)
                {
                    return Ok("Post Updated!");
                }
                return BadRequest("Post Failed to Update!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool isSuccess = await _blogPostRepository.DeleteAsync(id);
                if (isSuccess)
                {
                    return Ok("Post Deleted!");
                }
                return BadRequest("Post Failed to Delete!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
