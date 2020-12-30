using Cygni.MusicBrainz.Models.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Cygni.MusicBrainz.Facade;
using Cygni.MusicBrainz.Models.DataModel;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System;

namespace Cygni.MusicBrainz.BL.MusicBrainzWikiService
{
    public class MusicBrainzWikiService : IMusicBrainzWikiService
    {
        private readonly IMusicBrainzWikiServiceHelper _helper;
        private readonly IGenericHttpClientHandler _httpClientHandler;
        private readonly IConfiguration _configuration;
        
        private object locker;

        public MusicBrainzWikiService(IConfiguration configuration, IMusicBrainzWikiServiceHelper helper, IGenericHttpClientHandler httpClientHandler)
        {
            _configuration = configuration;
            _helper = helper;
            _httpClientHandler = httpClientHandler;
        }

        /// <summary>
        /// Get Artist information by using various APIs
        /// </summary>
        /// <param name="mbId"></param>
        /// <returns></returns>
        public async Task<ArtistModel> GetArtistInfo(string mbId)
        {
            //ClientUrlsOptions clientUrls = 
            //    (ClientUrlsOptions.ClientUrls).Get<ClientUrlsOptions>();

            //var myConfig = new Dictionary<string, string>
            //{
            //    {"ClientUrls:MusicBrainzUrl", "http://musicbrainz.org/ws/2/artist/{0}?&fmt=json&inc=url-rels+release-groups" },
            //    {"ClientUrls:WikiDataUrl", "https://www.wikidata.org/w/api.php?action=wbgetentities&ids={0}&format=json&props=sitelinks" },
            //    {"ClientUrls:WikiPediaUrl", "https://en.wikipedia.org/w/api.php?action=query&format=json&prop=extracts&exintro=true&redirects=true&titles={0}" },
            //    {"ClientUrls:CoverArtUrl", "http://coverartarchive.org/release-group/{0}" },
            //};

            ClientUrlsOptions clientUrls = _configuration.GetSection(ClientUrlsOptions.ClientUrls).Get<ClientUrlsOptions>();
            
            string url = string.Format(clientUrls.MusicBrainzUrl, mbId);

            // GetArtistByIdAsync
            var stringResponse = await _httpClientHandler.createHttpResponse(url);
            var artist = JsonConvert.DeserializeObject<Artist>(stringResponse);

            var urlToWikiData = artist.Relations.FirstOrDefault(x => x.Type == "wikidata");
            var urlToWikipedia = artist.Relations.FirstOrDefault(x => x.Type == "wikipedia");

            string artistName="";

            if (urlToWikipedia != null)
            {
                artistName = urlToWikipedia.Url.Resource.ToString().Split('/').LastOrDefault<string>();
            }
            else
            {
                string wikidataID = urlToWikiData.Url.Resource.ToString().Split('/').LastOrDefault<string>();

                var wikidataUrl = string.Format(clientUrls.WikiDataUrl, wikidataID);

                var wikiDataRet = await _httpClientHandler.createHttpResponse(wikidataUrl);

                IDictionary<string, JToken> Jsondata = JObject.Parse(wikiDataRet);
                artistName = Jsondata["entities"][wikidataID]["sitelinks"]["enwiki"]["title"].ToString();
            }

            string wikipediaUrl = string.Format(clientUrls.WikiPediaUrl, artistName);
            var wikipediaRet = await _httpClientHandler.createHttpResponse(wikipediaUrl);

            string description = _helper.GetWikipediaDescription(wikipediaRet);

            ConcurrentBag<MusicAlbumModel> musicAlbum = new ConcurrentBag<MusicAlbumModel>();

            //var Albums = artist.ReleaseGroup.Where(x => x.Type == "Album");

            //var taskret = Albums.Select( x => GetAlbumAsync(x));

            //await Task.WhenAll(taskret);

            //var resp = taskret.Select(x => x.Result );

            //foreach (var item in resp)
            //{
            //    musicAlbum.Add(item);
            //}



            return new ArtistModel() 
            {
                MbId = mbId,
                Albums = musicAlbum.ToList(),
                ArtistName = artistName,
                Description = description
            };
        }

        public async Task<MusicAlbumModel> GetAlbumAsync(ReleaseGroup x)
        {
            ClientUrlsOptions clientUrls = _configuration.GetSection(ClientUrlsOptions.ClientUrls).Get<ClientUrlsOptions>();

            List<string> albumImages = null;
            try
            {

                string artUrl = string.Format(clientUrls.CoverArtUrl, x.CoverArtId);
                var coverArtRet = await _httpClientHandler.createHttpResponse(artUrl);

                albumImages = _helper.GetCoverArtImages(coverArtRet) ?? new List<string>();
            }
            catch (Exception ex)
            {
                if(!ex.Message.Contains("404")) //some images doesnt exist
                    throw;
            }

            return new MusicAlbumModel() { CoverArtId = x.CoverArtId, Title = x.Title, ImageUrls = albumImages };

        }
    }
}
