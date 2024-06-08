using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web_api.core.Dtos
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public List<int> booksList { get; set; }
        public string PhoneNumber { get; set; }
        public bool HasBook { get; set; }
        public int BranchId { get; set; }
    }
}
