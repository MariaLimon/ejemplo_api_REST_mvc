using Microsoft.AspNetCore.Mvc;
using ejemplo_api_mvc.Models;

namespace ejemplo_api_mvc.Controllers
{

    public class CountryController : Controller
    {
        // Otros métodos del controlador...

        public async Task<IActionResult> Search(string countryName)
        {
            // URL del endpoint para buscar por nombre de país
            string baseUrl = "https://restcountries.com/v3.1/name/";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(baseUrl + countryName);

                    if (response.IsSuccessStatusCode)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        return View("ContryInfo", data);
                    }
                    else
                    {
                        ViewBag.ErrorMessage = $"Error: {response.StatusCode}";
                        return View("Error");
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = $"Error: {ex.Message}";
                    return View("Error");
                }
            }
        }
    }


}
