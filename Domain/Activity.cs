namespace Domain
{
    public class Activity
    {
        public Guid Id { get; set; }    //Nel database viene automaticamente identificato come primary key, perche' chiamata Id, saranno colonne nel database
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
    }
}