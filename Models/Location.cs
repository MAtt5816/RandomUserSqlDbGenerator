namespace RandomUserSqlDbGenerator.Models
{
    internal record class Location(Street Street, string City, string State, string Country, object Postcode, Coordinates Coordinates, Timezone Timezone);
}
