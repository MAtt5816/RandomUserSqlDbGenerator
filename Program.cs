using RandomUserSqlDbGenerator;

int howMany = 1;

Console.Write("Type how many users generate: ");
var num = Console.ReadLine() ?? string.Empty;
if (int.TryParse(num, out int numInt))
    howMany = numInt;

string url = $"https://randomuser.me/api/?results={howMany}";

var users = await ApiService.GetUsersAsync(url);

string createDbSql = File.ReadAllText("user_data.sql");
string insertionSql = SqlGenerator.GenerateSql(users);

Console.WriteLine(createDbSql + "\n" + insertionSql);
