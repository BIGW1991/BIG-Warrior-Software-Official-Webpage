using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIG_Warrior_Software_Official_Webpage.Models
{
    public class BlogEntry
    {
        public Guid ID { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifyingDate { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public Guid AdminID { get; set; }
        public string AdminName { get; set; }
        public List<Tags> TagsList { get; set; }
    }
}
