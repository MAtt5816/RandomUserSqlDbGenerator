using RandomUserSqlDbGenerator;

string url = "https://randomuser.me/api/";
var user = await ApiService.GetUserAsync(url);
