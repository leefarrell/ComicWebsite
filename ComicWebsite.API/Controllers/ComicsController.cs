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
// using Okta.Sdk;
// using Stripe;

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComic(int id)
        {
            await _repo.DeleteComic(id);

            return StatusCode(201);
        }

        [HttpPost("addcomic")]
        public async Task<IActionResult> AddComic(ComicDetailsDto comicDetailsDto)
        {
          var comicToCreate = new Comic
          {
            Name = comicDetailsDto.Name,
            Description = comicDetailsDto.Description,
            WriterName = comicDetailsDto.WriterName,
            Published = comicDetailsDto.Published,
            PhotoUrl = comicDetailsDto.PhotoUrl
          };

          await _repo.AddComic(comicToCreate);
          return StatusCode(201);

        }
        
 /* 
    [HttpPost("addcomic")]
    public async Task<ActionResult<Comic>> CreateAsync([FromBody] Comic buyComic)
    {

      // ChargeCard(buyComic);
     // var oktaUser = await RegisterUserAsync(buyComic);
     // buyComic.UserId = oktaUser.Id;
     // return Ok(buyComic);
    }

    private async Task<User> RegisterUserAsync(Comic buyComic)
    {
      var client = new OktaClient();
      var user = await client.Users.CreateUserAsync(
        new CreateUserWithPasswordOptions
        {
          Profile = new UserProfile
          {
            FirstName = buyComic.FirstName,
            LastName = buyComic.LastName,
            Email = buyComic.EmailAddress,
            Login = buyComic.EmailAddress,
          },
          Password = buyComic.Password,
          Activate = true
        }
      );

      return user as User;
    }

    private StripeCharge ChargeCard(Comic buyComic)
    {
      StripeConfiguration.SetApiKey("pk_test_JW5ncLtXvbJueeIDyy5aIrGL00AW8Id8Ld");

      var options = new StripeChargeCreateOptions
      {
        Amount = buyComic.Price,
        Currency = "eur",
        SourceTokenOrExistingSourceId = buyComic.Token,
        StatementDescriptor = "Buy Comic"
      };

      var service = new StripeChargeService();
      return service.Create(options);
    }
*/

    }
}