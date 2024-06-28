using RandomUserSqlDbGenerator.Models;
using System.Text.Json;

namespace RandomUserSqlDbGenerator
{
    internal static class ApiService
    {
        private static readonly HttpClient client = new();

        internal static async Task<User?> GetUserAsync(string path)
        {
            User? user = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var json = await response.Content.ReadAsStringAsync();
                var users = JsonSerializer.Deserialize<ApiResult>(json, options);
                user = users?.Results.FirstOrDefault();
            }
            return user;
        }
    }
}
