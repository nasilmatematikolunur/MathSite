using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Helpers;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentsController : ControllerBase
    {
        private IContentService _contentService;

        public ContentsController(IContentService contentService)
        {
            _contentService = contentService;
        }

     

        [HttpPost("add")]
        public IActionResult Add(Content content)
        {
            content.Slug = StringHelper.TitleToSlug(content.Title);
            content.CreatedAt=DateTime.Now;
            var result = _contentService.Add(content);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        

    }
}
