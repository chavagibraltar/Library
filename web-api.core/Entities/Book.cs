namespace web_api.Core.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool StatusIsRented { get; set; }
        public int BranchId { get; set; }

        public Book()
        {

        }
        //public Book(int id, string name, bool statusIsRented, int branchId)
        //{
        //    this.id = id;
        //    this.name = name;
        //    this.statusIsRented = statusIsRented;
        //    this.branchId = branchId;
        //}
        //id = 1, name = "aaa", statusIsRented = true, branchId = 1 
    }
}
