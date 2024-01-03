using FrontendUsers.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UsersAPI.Services.Interface;

namespace FrontendUsers.Controllers
{
    public class UserController : Controller
    {
        public UserController()
        {
        }
        public async Task<IActionResult> Index()
        {
            string endpointUrl = "https://localhost:44394/api/Users/GetAllUsers";
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(endpointUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string conteudoResposta = await response.Content.ReadAsStringAsync();

                        List<User> usuarios = JsonConvert.DeserializeObject<List<User>>(conteudoResposta);

                        return View(usuarios);
                    }
                    else
                        Console.WriteLine("Erro na requisição. Código do status: " + response.StatusCode);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocorreu um erro: " + ex.Message);
                }
            }
            return View();
        }
    }
}
