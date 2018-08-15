using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCore1.Models
{
    public class Download
    {
        public int Id { get; set; }
        public string File { get; set; }
        public DateTime Modified { get; set; }
        public int SizeKb { get; set; }
        public string ProductName { get; set; }
    }
}
