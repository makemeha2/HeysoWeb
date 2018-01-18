using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class QnAModel
    {
        public string YYYY { get; set; }
        public string MM { get; set; }
        public string DD { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string UserId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
