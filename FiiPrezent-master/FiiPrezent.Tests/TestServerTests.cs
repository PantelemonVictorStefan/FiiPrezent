using System;
using System.IO;
using System.Net.Http;
using FiiPrezent.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.PlatformAbstractions;
using Shouldly;
using Xunit;

namespace FiiPrezent.Tests
{
    public class TestServerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public TestServerTests()
        {
            string webContentRoot = Path.GetFullPath( "../../../../FiiPrezent");
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>()
                .UseContentRoot(webContentRoot));
            _client = _server.CreateClient();
        }

        [Fact(Skip = "razor compilation doesnt work yet.. perhaps in 2.1")]
        public async void GetHomepageReturnsSuccess()
        {
            HttpResponseMessage response = await _client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            string homepage = await response.Content.ReadAsStringAsync();
            homepage.ShouldContain("Fii Prezent");
        }
    }
}
