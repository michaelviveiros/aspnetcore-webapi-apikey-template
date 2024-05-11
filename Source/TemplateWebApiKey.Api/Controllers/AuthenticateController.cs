using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateWebApiKey.Api.Attributes;
using TemplateWebApiKey.Api.Class;

namespace TemplateWebApiKey.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly ILogger<AuthenticateController> _logger;

        public AuthenticateController(ILogger<AuthenticateController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Método para testar a autenticação e autorização da API.
        /// </summary>
        /// <param name="request">Parâmetro de requisição da API</param>
        /// <returns></returns>
        /// <response code="200">Requisição bem sucedida.</response>
        /// <response code="400">Requisição não concluída por informações obrigatórias ausentes.</response>
        /// <response code="401">Acesso não autorizado.</response>
        /// <response code="403">Recurso não autorizado.</response>
        /// <response code="404">Recurso não localizado.</response>
        /// <response code="500">Erro interno no servidor.</response>
        [HttpPost]
        [ApiKey]
        public async Task<IActionResult> Authenticate(string request)
        {
            try
            {
                if (string.IsNullOrEmpty(request))
                    return BadRequest(new ResultResponse<string>("É necessário informar um parâmetro válido."));

                return Ok(new ResultResponse<string>("API Key autenticada com sucesso!", true));
            }

            catch (Exception erro)
            {
                _logger.LogError(erro, $"Um erro ocorreu na API durante o processamento da requisição por meio do parâmetro {request}.", DateTime.UtcNow);
                return BadRequest(new ResultResponse<string>($"Um erro ocorreu durate o processamento das informações no sistema.<br/>Detalhes Técnicos: {erro.Message}."));
            }
        }
    }
}
