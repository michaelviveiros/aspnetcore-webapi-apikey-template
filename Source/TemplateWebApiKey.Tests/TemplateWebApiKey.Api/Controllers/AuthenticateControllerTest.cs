using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateWebApiKey.Api.Class;
using TemplateWebApiKey.Api.Controllers;
using Xunit;

namespace TemplateWebApiKey.Tests.TemplateWebApiKey.Api.Controllers
{
    public class AuthenticateControllerTest : IDisposable
    {
        private Mock<ILogger<AuthenticateController>> _logger;

        public AuthenticateControllerTest()
        {
            _logger = new Mock<ILogger<AuthenticateController>>();
        }

        [Fact, Description("Faz o request para o método Authenticate com o parâmetro de [request] null.")]
        public void CallRequestWithParameterNullTest ()
        {
            //Arrange => Inicialização das variáveis, mocks...
            string? requestData = null;
            var authenticateController = new AuthenticateController(_logger.Object);

            //Act => Execução do teste, chamada de funções, métodos...
            var request = authenticateController.Authenticate(requestData);
            var response = (request?.Result as ObjectResult);
            var responseResultEntity = (response?.Value as ResultResponse<string>);

            //Act => Verificação do resultado da operação anterior.
            Assert.NotNull(request);
            Assert.NotNull(response);
            Assert.NotNull(responseResultEntity);
            Assert.Equal(400, response?.StatusCode);
            Assert.IsType<ResultResponse<string>>(responseResultEntity);
            Assert.Equal(1, responseResultEntity?.Errors.Count);
            Assert.False(responseResultEntity?.Success);
            Assert.Equal("É necessário informar um parâmetro válido.", responseResultEntity?.Errors.First());
        }

        [Fact, Description("Faz o request para o método Authenticate com o parâmetro de [request] contendo valor.")]
        public void CallRequestWithDataParameterTest()
        {
            //Arrange => Inicialização das variáveis, mocks...
            string requestData = "Teste request API";
            var authenticateController = new AuthenticateController(_logger.Object);

            //Act => Execução do teste, chamada de funções, métodos...
            var request = authenticateController.Authenticate(requestData);
            var response = (request?.Result as ObjectResult);
            var responseResultEntity = (response?.Value as ResultResponse<string>);

            //Act => Verificação do resultado da operação anterior.
            Assert.NotNull(request);
            Assert.NotNull(response);
            Assert.NotNull(responseResultEntity);
            Assert.Equal(200, response?.StatusCode);
            Assert.IsType<ResultResponse<string>>(responseResultEntity);
            Assert.NotNull(responseResultEntity?.Data);
            Assert.Equal(0, responseResultEntity?.Errors.Count);
            Assert.True(responseResultEntity?.Success);
            Assert.Equal("API Key autenticada com sucesso!", responseResultEntity?.Data);
        }

        public void Dispose()
        {
            _logger = null;
        }
    }
}
