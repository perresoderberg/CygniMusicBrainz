using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Cygni.MusicBrainz.Facade;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit;
using NUnit.Framework;

namespace Cygni.MusicBrainz.Tests.FacadeTests
{
    [TestFixture]
    class WikidataClientTest
    {
        string baseurl = "https://www.wikidata.org";
        string requesturl = "/w/api.php";
        string parameters = "action=wbgetentities&format=json&props=sitelinks";

        string wikidataIdentifier = "Q11649";
        //[SetUp]
        //public void SetUp()
        //{

        //}


        //[Test]
        //public async Task CallToWikiDataClient_TitleExists()
        //{

        //    WikiDataClient client = new WikiDataClient(baseurl, requesturl, parameters);
            
        //    var ret = await client.GetEntitiesByIdAsync(wikidataIdentifier);
            
        //    string title;
        //    try
        //    {
        //        IDictionary<string, JToken> Jsondata = JObject.Parse(ret);
        //        title = Jsondata["entities"][wikidataIdentifier]["sitelinks"]["enwiki"]["title"].ToString();
        //        string titleEncoded = HttpUtility.UrlPathEncode(title);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new JsonException("Unable to cast WikiData " + ex.Message);
        //    }

            
        //    Assert.IsNotNull(ret);
        //    Assert.IsNotNull(title);
        //    Assert.IsFalse(string.IsNullOrWhiteSpace(title));            
        //}
    }
}
