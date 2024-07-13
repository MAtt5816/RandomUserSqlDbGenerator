using RandomUserSqlDbGenerator.Models;
using System.Text.Json;

namespace RandomUserSqlDbGenerator
{
    internal static class ApiService
    {
        private static readonly HttpClient client = new();

        internal static async Task<List<User>> GetUsersAsync(string path)
        {
            List<User> userList = [];
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var json = await response.Content.ReadAsStringAsync();
                var formattedJson = ProtectSingleQuotes(json);
                var result = JsonSerializer.Deserialize<ApiResult>(formattedJson, options);
                userList = result?.Results ?? [];
            }
            return userList;
        }
        
        private static string ProtectSingleQuotes(string json)
        {
            return json.Replace("'", "''");
        }
    }
}
