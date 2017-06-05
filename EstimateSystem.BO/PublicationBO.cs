using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateSystem.BO
{
    public class PublicationBO
    {
        public int EST_PUBID { get; set; }
        public string EST_Publication { get; set; }
        public int EST_ID { get; set; }
        public string Pub_Language { get; set; }
        public int Total_Edition { get; set; }
        public decimal Rate { get; set; }
        public int Total_Insertion { get; set; }
        public decimal Total_Cost { get; set; }
        public decimal Agency_Discount { get; set; }
        public decimal Total_NetCost { get; set; }
    }
}
