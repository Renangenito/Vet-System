using Microsoft.Extensions.Options;
using VetSystem.Comum.Modelo;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using VetSystem.Models.Models;
using Newtonsoft.Json;

namespace VetSystem.Comum.Servico
{
    public class ApiToken : IApiToken
    {
        private readonly IOptions<DadosBase> _dadosBase;
        private readonly IOptions<LoginRespostaModel> _loginRespostaModel;
        public ApiToken(IOptions<DadosBase> dadosbase, IOptions<LoginRespostaModel> loginRespostaModel)
        {
            _dadosBase = dadosbase;
            _loginRespostaModel = loginRespostaModel;
        }
        private async Task ObterToken()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            LoginRequisicaoModel loginRequisicaoModel = new LoginRequisicaoModel();
            loginRequisicaoModel.Usuario = "UsuarioVetSystem"; 
            loginRequisicaoModel.Senha = "SenhaVetSystem";                                                         
            HttpResponseMessage response = await client.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}/Login", loginRequisicaoModel);

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                LoginRespostaModel loginRespostaModel = JsonConvert.DeserializeObject<LoginRespostaModel>(conteudo);

                if (loginRespostaModel.Autenticado == true)
                {
                    _loginRespostaModel.Value.Autenticado = loginRespostaModel.Autenticado;
                    _loginRespostaModel.Value.Usuario = loginRespostaModel.Usuario;
                    _loginRespostaModel.Value.DataExpiracao = loginRespostaModel.DataExpiracao;
                    _loginRespostaModel.Value.Token = loginRespostaModel.Token;

                }

            }
            else
            {
                throw new Exception("Erro ao tentar Autenticar com a API!!");
            }

        }

        public async Task<string> Obter()
        {
            if (_loginRespostaModel.Value.Autenticado == false)
            {
               await ObterToken();
            }
            else
            {
                if (DateTime.Now >= _loginRespostaModel.Value.DataExpiracao)
                {
                    await ObterToken();
                }
            }
            return _loginRespostaModel.Value.Token;
        }

       
    }
}
