﻿namespace RandomUserSqlDbGenerator.Models
{
    internal record class Location(Street Street, string City, string Country, string Postcode, Coordinates Coordinates, Timezone Timezone);
}