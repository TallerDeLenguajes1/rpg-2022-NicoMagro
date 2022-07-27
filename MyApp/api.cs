// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Datum
    {
        public List<string> films { get; set; }
        public List<string> shortFilms { get; set; }
        public List<string> tvShows { get; set; }
        public List<string> videoGames { get; set; }
        public List<string> parkAttractions { get; set; }
        public List<object> allies { get; set; }
        public List<object> enemies { get; set; }
        public int _id { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }
        public string url { get; set; }
    }

    public class rere
    {
        public List<Datum> data { get; set; }
        public int count { get; set; }
        public int totalPages { get; set; }
        public string nextPage { get; set; }
    }