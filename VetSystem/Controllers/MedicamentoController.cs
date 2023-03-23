using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using VetSystem.Comum.Modelo;
using VetSystem.Comum.Servico;
using VetSystem.Models.Models;

namespace VetSystem.Controllers
{
    [Authorize(Roles = "administrador")]
    public class MedicamentoController : Controller
    {
        private readonly IOptions<DadosBase> _dadosBase;
        private readonly HttpClient _httpClient;
        private readonly IOptions<LoginRespostaModel> _loginRespostaModel;
        private readonly IApiToken _apiToken;

        public MedicamentoController(IOptions<DadosBase> dadosBase, HttpClient httpClient, IOptions<LoginRespostaModel> loginRespostaModel, IApiToken apiToken)
        {
            _dadosBase = dadosBase;
            _httpClient = httpClient;
            _loginRespostaModel = loginRespostaModel;
            _apiToken = apiToken;
        }

        public async Task<ActionResult> Index()
        {
            
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

            HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}/Medicamento/ObterTodosMedicamentos");

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<List<MedicamentoModel>>(conteudo));
            }
            else
            {
                throw new Exception("Erro ao tentar obter o medicamento!");
            }
        }

        public ActionResult Create()
        {
            ViewBag.ListaDeEspecies = CarregarListaDeEspecies().Result;


            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] MedicamentoModel medicamentoModel)
        {

            try
            {

                if (ModelState.IsValid)
                {


                    _httpClient.DefaultRequestHeaders.Accept.Clear();
                    _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

                    HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}/Medicamento", medicamentoModel);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index), new { mensagem = "Registro cadastraado!", sucesso = true });

                    }
                    else
                    {
                        throw new Exception("Erro ao Cadastrar o Medicamento!");
                    }


                }
                else
                {
                    TempData["erro"] = "Algum campo deve estar faltando preenchimento";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["erro"] = "Algum erro aconteceu - " + ex.Message;
                return View();
            }
        }

        public async Task<ActionResult> Edit(string valor)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
            HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}/Medicamento/ObterDadosMedicamento?id={valor}");

            if (response.IsSuccessStatusCode)
            {
                ViewBag.ListaDeEspecies = CarregarListaDeEspecies().Result;


                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<MedicamentoModel>(conteudo));
            }
            else
            {
                throw new Exception("Erro ao tentar editar um Medicamento!!");
            }
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit([FromForm] MedicamentoModel medicamentoModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
                    HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}/Medicamento", medicamentoModel);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index), new { mensagem = "Registro Editado!", sucesso = true });

                    }
                    else
                    {
                        throw new Exception("Erro ao tentar editar um Medicamento!!");
                    }


                }
                else
                {
                    TempData["erro"] = "Algum campo deve estar faltando preenchimento";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["erro"] = "Algum erro aconteceu - " + ex.Message;
                return View();
            }
        }

        public async Task<ActionResult> Delete(string valor)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
                HttpResponseMessage response = await _httpClient.DeleteAsync($"{_dadosBase.Value.API_URL_BASE}/Medicamento?id={valor}");

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    throw new Exception("Erro ao deletar Medicamento!");
                }

            }
            catch
            {
                return View();
            }
        }

        private async Task<List<SelectListItem>> CarregarListaDeEspecies()
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
            List<SelectListItem> lista = new List<SelectListItem>();
            HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}/Especie/ObterTodasEspecies");


            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                List<EspecieModel> categorias = JsonConvert.DeserializeObject<List<EspecieModel>>(conteudo);

                foreach (var linha in categorias)
                {
                    lista.Add(new SelectListItem()
                    {
                        Text = linha.Tipo,
                        Selected = false,
                    });
                }

                return lista;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
