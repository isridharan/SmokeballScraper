using Client;
using Domain.Query;
using Domain.Query.Handler;
using Moq;
using NUnit.Framework;
using System;
using Common;
using Client.Request;
using System.Threading.Tasks;


namespace ScrappingTest
{
    public class Test
    {
        IQueryHandler<SearchMatchQuery, SearchMatchResponse> _queryHandler;
        Mock<IScraperClient> _client;

        [SetUp]
        public void Setup()
        {            
            //Mock client to pass your own data and check on the Scrapping Logic.
            _client = new Mock<IScraperClient>();
            _queryHandler = new SearchMatchQueryHandler(_client.Object);
        }

        [Test]
        public void TestSearchInput_WhenContainsInteger_ThrowsExcception()
        {
            try
            {
                //Arrange
                string searchInput = "121232132";
                string url = "www.smokeball.com.au";

                //Act
                var searchQuery = new SearchMatchQuery(searchInput, url);

            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsTrue(ex is InvalidSearchStringException);
            }
        }

        [Test]
        public void TestSearchUrl_WhenNotInUrlFormat_ThrowsExcception()
        {
            try
            {
                //Arrange
                string searchInput = "adssad asdsadsad";
                string url = "addsa adasdsad asd %$&@**@";

                //Act
                var searchQuery = new SearchMatchQuery(searchInput, url);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsTrue(ex is InvalidUrlFormatException);
            }
        }     

        [Test]
        public void TestSearchUrl_WhenNotInUrlFormat_ThrowsException()
        {
            try
            {
                //Arrange
                string searchInput = "adssad asdsadsad";
                string url = "addsa adasdsad asd %$&@**@";

                //Act
                var searchQuery = new SearchMatchQuery(searchInput, url);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsTrue(ex is InvalidUrlFormatException);
            }
        }


        [Test]
        public async Task Test_SearchResult_ShouldReturnCountOfURL()
        {
            //Arrange
            string searchInput = "conveyancing software";
            string url = "www.smokeball.com.au";
            string content = "<div class=\"kCrYT\"><a href=\"/url?q=https://www.smokeball.com.au/practice-area/conveyancing-software&amp;sa=U&amp;ved=2ahUKEwiowdyB1cfzAhWppZUCHbk1BGUQFnoECDgQAg&amp;usg=AOvVaw2Yqbc2l1x5gzhKFFx0mIGn\"><h3 class=\"zBAuLc l97dzf\"><div class=\"BNeawe vvjwJb AP7Wnd\">Best Conveyancing Matter Management Software - Smokeball</div></h3><div class=\"BNeawe UPmit AP7Wnd\">www.smokeball.com.au &#8250; practice-area &#8250; conveyancing-software</div></a></div><div class=\"x54gtf\"></div><div class=\"kCrYT\"><div><div class=\"BNeawe s3v9rd AP7Wnd\"><div><div><div class=\"BNeawe s3v9rd AP7Wnd\">Conveyancing Software Matter Type Detail Screen ... Smokeball keeps your clients' details in one easy-to-manage and secure place, with all relevant documents, ...</div>"; ;                        
            _client.Setup(x => x.GetContentAsync(It.IsAny<ClientRequest>())).ReturnsAsync(content);            

            //Act
            var searchQuery = new SearchMatchQuery(searchInput, url);
            var result = await _queryHandler.HandleAsync(searchQuery);

            //Assert
            Assert.IsTrue(result.CountOfMatches.Equals(1));
        }

        [Test]
        public async Task Test_AdResult_ShouldReturnCountOfURLInAds()
        {
            //Arrange
            string searchInput = "conveyancing software";
            string url = "www.smokeball.com.au";
            
            string content = "<div class=\"BNeawe vvjwJb AP7Wnd\">Best Conveyancing Matter Management Software - Smokeball</div></h3><div class=\"BNeawe UPmit AP7Wnd\">www.smokeball.com.au &#8250; practice-area &#8250; conveyancing-software</div></a></div><div class=\"x54gtf\"></div><div class=\"kCrYT\"><span class=\"jpu5Q VqFMTc NceN9e\">Ad</span><span class=\"Zu0yb qzEoUe\">www.smokeball.com.au\"</span><div><div class=\"BNeawe s3v9rd AP7Wnd\"><div><div><div class=\"BNeawe s3v9rd AP7Wnd\">Conveyancing Software Matter Type Detail Screen ... Smokeball keeps your clients' details in one easy-to-manage and secure place, with all relevant documents, ...</div>";
            _client.Setup(x => x.GetContentAsync(It.IsAny<ClientRequest>())).ReturnsAsync(content);

            //Act
            var searchQuery = new SearchMatchQuery(searchInput, url);
            var result = await _queryHandler.HandleAsync(searchQuery);

            //Assert
            Assert.IsTrue(result.CountOfMatches.Equals(1));
        }

        [Test]
        public async Task Test_AdResult_ShouldReturnCountOfURLInSearchResultAndAds()
        {
            //Arrange
            string searchInput = "conveyancing software";
            string url = "www.smokeball.com.au";
            
            string content = "<div class=\"kCrYT\"><a href=\"/url?q=https://www.smokeball.com.au/practice-area/conveyancing-software&amp;sa=U&amp;ved=2ahUKEwiowdyB1cfzAhWppZUCHbk1BGUQFnoECDgQAg&amp;usg=AOvVaw2Yqbc2l1x5gzhKFFx0mIGn\"><h3 class=\"zBAuLc l97dzf\"><div class=\"BNeawe vvjwJb AP7Wnd\">Best Conveyancing Matter Management Software - Smokeball</div></h3><div class=\"BNeawe UPmit AP7Wnd\">www.smokeball.com.au &#8250; practice-area &#8250; conveyancing-software</div></a></div><div class=\"x54gtf\"></div><div class=\"kCrYT\"><span class=\"jpu5Q VqFMTc NceN9e\">Ad</span><span class=\"Zu0yb qzEoUe\">www.smokeball.com.au\"</span><div><div class=\"BNeawe s3v9rd AP7Wnd\"><div><div><div class=\"BNeawe s3v9rd AP7Wnd\">Conveyancing Software Matter Type Detail Screen ... Smokeball keeps your clients' details in one easy-to-manage and secure place, with all relevant documents, ...</div>";
            _client.Setup(x => x.GetContentAsync(It.IsAny<ClientRequest>())).ReturnsAsync(content);

            //Act
            var searchQuery = new SearchMatchQuery(searchInput, url);
            var result = await _queryHandler.HandleAsync(searchQuery);

            //Assert
            Assert.IsTrue(result.CountOfMatches.Equals(2));
        }

        [Test]
        public async Task Test_ShouldReturn_0_WhenNoMatchIdFound()
        {
            //Arrange
            string searchInput = "conveyancing software";
            string url = "adhsak.adasd.asd.asd";
            string content = "<div class=\"kCrYT\"><a href=\"/url?q=https://www.smokeball.com.au/practice-area/conveyancing-software&amp;sa=U&amp;ved=2ahUKEwiowdyB1cfzAhWppZUCHbk1BGUQFnoECDgQAg&amp;usg=AOvVaw2Yqbc2l1x5gzhKFFx0mIGn\"><h3 class=\"zBAuLc l97dzf\"><div class=\"BNeawe vvjwJb AP7Wnd\">Best Conveyancing Matter Management Software - Smokeball</div></h3><div class=\"BNeawe UPmit AP7Wnd\">www.smokeball.com.au &#8250; practice-area &#8250; conveyancing-software</div></a></div><div class=\"x54gtf\"></div><div class=\"kCrYT\"><span class=\"jpu5Q VqFMTc NceN9e\">Ad</span><span class=\"Zu0yb qzEoUe\">www.smokeball.com.au\"</span><div><div class=\"BNeawe s3v9rd AP7Wnd\"><div><div><div class=\"BNeawe s3v9rd AP7Wnd\">Conveyancing Software Matter Type Detail Screen ... Smokeball keeps your clients' details in one easy-to-manage and secure place, with all relevant documents, ...</div>"; 
            _client.Setup(x => x.GetContentAsync(It.IsAny<ClientRequest>())).ReturnsAsync(content);

            //Act
            var searchQuery = new SearchMatchQuery(searchInput, url);
            var result = await _queryHandler.HandleAsync(searchQuery);

            //Assert
            Assert.IsTrue(result.CountOfMatches.Equals(0));
        }

    }
}
