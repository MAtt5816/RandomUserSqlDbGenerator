using RandomUserSqlDbGenerator;

int howMany = 1;

if (args.Length > 0)
{
    string arg = args[0];
    if (int.TryParse(arg, out int numInt))
        howMany = numInt;
}

string url = $"https://randomuser.me/api/?results={howMany}";

var users = await ApiService.GetUsersAsync(url);

string createDbSql = File.ReadAllText("user_data.sql");
string insertionSql = SqlGenerator.GenerateSql(users);

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine(createDbSql + "\n" + insertionSql);
