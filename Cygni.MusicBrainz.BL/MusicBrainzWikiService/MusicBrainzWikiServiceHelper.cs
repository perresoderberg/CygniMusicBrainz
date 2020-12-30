using Cygni.MusicBrainz.Facade;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Cygni.MusicBrainz.BL.MusicBrainzWikiService
{
    public class MusicBrainzWikiServiceHelper : IMusicBrainzWikiServiceHelper
    {

        /// <summary>
        /// Get Description from Wikipedia-object
        /// </summary>
        /// <param name="wikipediaRet"></param>
        /// <returns></returns>
        public string GetWikipediaDescription(string wikipediaRet)
        {
            try
            {
                dynamic test = JObject.Parse(wikipediaRet);

                JObject pages = (JObject)test["query"]["pages"];

                var artistdata = pages.First.ToObject<JProperty>().Value;

                return artistdata["extract"].ToString();

            }
            catch (Exception ex)
            {
                throw new JsonException("Unable to cast Wikipedia Json Object " + ex.Message);
            }
        }
        /// <summary>
        /// Get Cover Art Images from Response
        /// </summary>
        /// <param name="coverArtRet"></param>
        /// <returns></returns>
        public List<string> GetCoverArtImages(string coverArtRet)
        {
            if (string.IsNullOrWhiteSpace(coverArtRet) || coverArtRet.Contains("Not Found"))
                return new List<string>();

            List<string> images = new List<string>();
            try
            {
                IDictionary<string, JToken> Jsondata = JObject.Parse(coverArtRet);
                var imagesJson = Jsondata["images"];

                foreach (var item in Jsondata["images"].Children())
                {
                    images.Add(item["image"].ToString());
                }

            }
            catch (Exception ex)
            {
                throw new JsonException("Unable to cast CoverArt Json Object " + ex.Message);
            }
            return images;
        }
    }
}
