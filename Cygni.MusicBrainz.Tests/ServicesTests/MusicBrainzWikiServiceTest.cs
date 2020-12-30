using Cygni.MusicBrainz.BL.MusicBrainzWikiService;
using Cygni.MusicBrainz.Facade;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Cygni.MusicBrainz.Tests.ServicesTests
{
    class MusicBrainzWikiServiceTest
    {
        public TestContext testContext { get; set; }

        [Test]
        public void GetArtistIntoTest_RetOK()
        {
            var myConfig = new Dictionary<string, string> 
            {
                {"ClientUrls:MusicBrainzUrl", "http://musicbrainz.org/ws/2/artist/{0}?&fmt=json&inc=url-rels+release-groups" },
                {"ClientUrls:WikiDataUrl", "https://www.wikidata.org/w/api.php?action=wbgetentities&ids={0}&format=json&props=sitelinks" },
                {"ClientUrls:WikiPediaUrl", "https://en.wikipedia.org/w/api.php?action=query&format=json&prop=extracts&exintro=true&redirects=true&titles={0}" },
                {"ClientUrls:CoverArtUrl", "http://coverartarchive.org/release-group/{0}" },
            };

            var lista = new List<string> { "sdf", "sdfasfsdf" };

            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfig)                
                .Build();

            IMusicBrainzWikiServiceHelper helper;
            var mock = new Mock<IMusicBrainzWikiServiceHelper>();
            mock.Setup(x => x.GetWikipediaDescription(It.IsAny<string>())).Returns("result_string");

            var httpMock = new Mock<IGenericHttpClientHandler>();
            httpMock.Setup(x => x.createHttpResponse(It.IsAny<string>())).ReturnsAsync("ret");

            var service = new MusicBrainzWikiService(config, mock.Object, httpMock.Object);
            service.GetArtistInfo("5b11f4ce-a62d-471e-81fc-a69a8278c7da");


        }

    }
}
