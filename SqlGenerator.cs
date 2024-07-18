using RandomUserSqlDbGenerator.Models;

namespace RandomUserSqlDbGenerator
{
    public static class SqlGenerator
    {
        private const string InsertIntoUsers =
            "INSERT INTO users (gender, title, first_name, last_name, email, dob, registered, phone, cell, id_name, id_value, nat)\nVALUES\n";

        private const string InsertIntoLocations =
            "INSERT INTO locations (user_id, street_number, street_name, city, state, country, postcode, timezone)\nVALUES\n";

        private const string InsertIntoLogins =
            "INSERT INTO logins (user_id, uuid, username, password, salt, md5, sha1, sha256)\nVALUES\n";

        private const string InsertIntoPictures =
            "INSERT INTO pictures (user_id, large, medium, thumbnail)\nVALUES\n";

        internal static string GenerateSql(List<User> users)
        {
            string usersValues = string.Empty;
            string locationsValues = string.Empty;
            string loginsValues = string.Empty;
            string picturesValues = string.Empty;

            bool isFirstLoop = true;

            int i = 1;

            foreach (var user in users)
            {
                if (!isFirstLoop)
                {
                    usersValues += ",\n";
                    locationsValues += ",\n";
                    loginsValues += ",\n";
                    picturesValues += ",\n";
                }
                else
                    isFirstLoop = false;

                usersValues +=
                    $"('{user.Gender}', '{user.Name.Title}', '{user.Name.First}', '{user.Name.Last}', '{user.Email}', " +
                    $"'{user.Dob.Date}', '{user.Registered.Datetime}', '{user.Phone}', '{user.Cell}', " +
                    $"'{user.Id.Name}', '{user.Id.Value}', '{user.Nat}')";

                var location = user.Location;
                locationsValues +=
                    $"({i}, {location.Street.Number}, '{location.Street.Name}', '{location.City}', '{location.State}', " +
                    $"'{location.Country}', '{location.Postcode}', '{location.Timezone.Offset}')";

                var login = user.Login;
                loginsValues +=
                    $"({i}, '{login.Uuid}', '{login.Username}', '{login.Password}', '{login.Salt}', '{login.Md5}', '{login.Sha1}', '{login.Sha256}')";

                var picture = user.Picture;
                picturesValues +=
                    $"({i}, '{picture.Large}', '{picture.Medium}', '{picture.Thumbnail}')";

                i++;
            }

            usersValues += ";\n";
            locationsValues += ";\n";
            loginsValues += ";\n";
            picturesValues += ";\n";

            return InsertIntoUsers + usersValues + "\n"
                   + InsertIntoLocations + locationsValues + "\n"
                   + InsertIntoLogins + loginsValues + "\n"
                   + InsertIntoPictures + picturesValues;
        }
    }
}