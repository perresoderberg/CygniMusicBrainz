using System;
using System.Threading.Tasks;
using Cygni.MusicBrainz.BL.MusicBrainzWikiService;
using Cygni.MusicBrainz.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace Cygni.MusicBrainz.API.Controllers
{
    [Route("api")]
    public class MusicBrainzWikiController : Controller
    {

        private readonly IMusicBrainzWikiService _musicBrainzWikiService;

        public MusicBrainzWikiController(IMusicBrainzWikiService musicBrainzWikiService)
        {
            _musicBrainzWikiService = musicBrainzWikiService;            
        }



        //   31e7b30b-f960-408f-908b-c8e277308eab
        //   5b11f4ce-a62d-471e-81fc-a69a8278c7da

        [HttpGet("{mbid}")]
        [ResponseCache(Duration = 10)]
        [Produces("application/json")]
        public async Task<IActionResult> GetArtistInfo(string mbId)
        {
            try
            {


                if (string.IsNullOrWhiteSpace(mbId))
                {
                    throw new ArgumentException($"mbid is incorrect input parameter - mbid: {mbId}");
                }

                var musicBrainz = await _musicBrainzWikiService.GetArtistInfo(mbId);
                return Ok(musicBrainz);

            }
            catch (NullReferenceException ex)
            {
                return StatusCode(500, "NullReferenceException");
            }
            catch (InvalidCastException ex)
            {

                return StatusCode(500, "InvalidCastException");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }


        }


    }
}
