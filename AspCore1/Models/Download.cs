using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspCore1.Models
{
    public class Download
    {
        public int Id { get; set; }
        public string File { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name ="Date Modified")]
        public DateTime Modified { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Size")]
        public decimal SizeKb { get; set; }
        [Display(Name ="Product / Package Name")]
        public string ProductName { get; set; }
    }
}
