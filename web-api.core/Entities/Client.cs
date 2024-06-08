

namespace web_api.Core.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public List<int> booksList { get; set; }
        public string PhoneNumber { get; set; }
        public bool HasBook { get; set; }
        public int BranchId { get; set; }
        public Client()
        {

        }
    }
}
