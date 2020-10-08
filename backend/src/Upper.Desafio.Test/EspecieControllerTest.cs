using FluentAssertions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Upper.Desafio.Application;
using Upper.Desafio.Application.Contracts.V1;
using Upper.Desafio.Domain.Entities;
using Upper.Desafio.Domain.ViewModel;
using Upper.Desafio.Test.Base;
using Xunit;

namespace Upper.Desafio.Test
{
    public class EspecieControllerTest : IntegrationTest
    {
        [Fact]
        public async Task GetEspecies_RetornaListaExistente()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync(ApiRoutes.UpperDesafio.Especie);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var result = await response.Content.ReadAsStringAsync();
            result.Should().NotBeNullOrEmpty();
        }
        [Fact]
        public async Task Post_IncluirNovaEspecie()
        {
            // Arrange
            var novaEspecie = new EspecieViewModel();
            novaEspecie.Descricao = "Teste";
            var jsonObject = JsonConvert.SerializeObject(novaEspecie);

            // Act
            var response = await _client.PostAsync(ApiRoutes.UpperDesafio.Especie, new StringContent(jsonObject, Encoding.UTF8, "application/json"));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
