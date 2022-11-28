using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class ForDisplayingOnly
    {
        public int id { get; set; }
        public string fname { get; set; }
        public string mname { get; set; }
        public string lname { get; set; }
        public string email { get; set; }
        public long phone { get; set; }
        public string Pname { get; set; }
        public int QTY { get; set; }
        public int price { get; set; }
    }
}
