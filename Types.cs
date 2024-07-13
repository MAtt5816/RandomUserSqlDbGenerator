namespace RandomUserSqlDbGenerator
{
    internal struct Name
    {
        public string Title { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
    }

    internal struct Street
    {
        public int Number { get; set; }
        public string Name { get; set; }
    }

    internal struct Coordinates
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }

    internal struct Timezone
    {
        public string Offset { get; set; }
        public string Description { get; set; }
    }

    internal struct DateAge
    {
        private string _date;

        public string Date
        {
            get => _date;
            set
            {
                var date = value.Replace("T", " ");
                _date = date.Remove(date.IndexOf('.'));
            }
        }
        public int Age { get; set; }
    }

    internal struct Id
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    internal struct Picture
    {
        public string Large { get; set; }
        public string Medium { get; set; }
        public string Thumbnail { get; set; }
    }
}
