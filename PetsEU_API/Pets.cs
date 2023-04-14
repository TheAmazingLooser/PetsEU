namespace PetsEU_API
{
    public class Pets
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public List<string> Base64ImageData { get; set; }
    }
}
