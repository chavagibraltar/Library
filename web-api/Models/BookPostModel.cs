namespace web_api.Models
{
    public class BookPostModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool StatusIsRented { get; set; }
        public int BranchId { get; set; }
    }
}
