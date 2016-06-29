using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Epam.Password.Server;
using Epam.Password.Server.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Xunit;

namespace Epam.Password.Tests
{
    public class TestExample : IDisposable
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        private readonly Db _db;

        public TestExample()
        {
            //TODO: extract to other core class for sharing with other tests
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>().UseEnvironment("Test"));
            _db = (Db) _server.Host.Services.GetService(typeof(Db));
            _client = _server.CreateClient();
        }

        public void Dispose()
        {
            _server.Dispose();
        }

        [Fact]
        public async void PassingTest()
        {
            var account = new Account() {Email = "vasya@epam.com", VerificationType = VerificationType.Sms};
            _db.Accounts.Add(account);
            _db.SaveChanges();

            var r = await _client.GetAsync("/api/info/vasya@epam.com");
            r.EnsureSuccessStatusCode();
            var returnAccount = JsonConvert.DeserializeObject<Account>(await r.Content.ReadAsStringAsync());

            Assert.Equal(account.VerificationType, returnAccount.VerificationType);
            Assert.Equal(account.Email, returnAccount.Email);
        }
    }
}
