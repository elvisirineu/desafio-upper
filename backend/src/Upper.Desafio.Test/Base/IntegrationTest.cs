using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Upper.Desafio.Application;

namespace Upper.Desafio.Test.Base
{
    public class IntegrationTest
    {
        protected readonly HttpClient _client;
        protected IntegrationTest()
        {
            var app = new WebApplicationFactory<Startup>();
            _client = app.CreateClient();
        }

    }
}
