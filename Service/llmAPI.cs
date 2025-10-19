using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GestionEtudiant.Service
{
    public class llmAPI
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public llmAPI()
        {
            // 🔹 Charger la clé depuis appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            _apiKey = config["ApiKeys:Gemini"];

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://generativelanguage.googleapis.com/v1beta/")
            };
        }

        public async Task<string> GenerateAsync(string prompt)
        {
            string model = $"models/gemini-2.0-flash:generateContent?key={_apiKey}";
            string promptComplet = "vous êtes un assistant intélligent qui fournit des chapitres en langue française de differents modules d'enseignements donne moi des chapitres bref et concise concernant le sujet de "+prompt;
            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        role = "user",
                        parts = new[]
                        {
                            new { text = promptComplet }
                        }
                    }
                }
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            Console.WriteLine("🔹 Envoi de la requête à Gemini...");

            var response = await _httpClient.PostAsync(model, content);

            if (!response.IsSuccessStatusCode)
            {
                var err = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"❌ Erreur {response.StatusCode}: {err}");
                return $"Erreur API : {response.StatusCode}";
            }

            var responseString = await response.Content.ReadAsStringAsync();

            using JsonDocument doc = JsonDocument.Parse(responseString);
            var root = doc.RootElement;

            foreach (var candidate in root.GetProperty("candidates").EnumerateArray())
            {
                if (!candidate.TryGetProperty("content", out var contentEl))
                    continue;

                foreach (var part in contentEl.GetProperty("parts").EnumerateArray())
                {
                    if (part.TryGetProperty("text", out var textElement))
                    {
                        return textElement.GetString();
                    }
                }
            }

            return "❌ Aucune réponse textuelle reçue du modèle.";
        }
    }
}
