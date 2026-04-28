namespace LokaleBookingRazor.Models
{
    public class Lokale
    {
        public int Id { get; set; }
        public string Name { get; set;  }

    public Lokale()

        {
            Id = 0;
            Name = ""; 
        }

        public Lokale (int id, string name)
        {
            Id = id;
            Name = name;
        }

    }

}
