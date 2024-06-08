namespace web_api.Models
{
    public class ClientPostModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public bool HasBook { get; set; }
        public int BranchId { get; set; }
    }
}
