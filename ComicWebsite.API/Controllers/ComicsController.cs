using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ComicWebsite.API.Data;
using ComicWebsite.API.Dtos;
using ComicWebsite.API.Models;
using ComicWebsite.API;
using AutoMapper;

namespace ComicWebsite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicsController : ControllerBase
    {
        private readonly IComicRepository _repo;
        private readonly IMapper _mapper;

        public ComicsController(IComicRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetComics()
        {
            var comics = await _repo.GetComics();
            var returnComics = _mapper.Map<IEnumerable<ComicDto>>(comics);

            return Ok(returnComics);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComic(int id)
        {
            var comic = await _repo.GetComic(id);
            var returnComic = _mapper.Map<ComicDetailsDto>(comic);

            return Ok(returnComic);
        }
    }
}