using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateSystem.BO
{
    public class EstimateBO
    {
        public int EST_ID { get; set; }
        public string EST_NO { get; set; }
        public System.DateTime EST_Date { get; set; }
        public string Campaign { get; set; }
        public string Agency { get; set; }
        public string PO_NO { get; set; }
        public System.DateTime PO_Date { get; set; }
        public int ClientID { get; set; }
        public int BrandID { get; set; }
        public System.DateTime PeriodFrom { get; set; }
        public System.DateTime PeriodTo { get; set; }
        public decimal SAC_PER { get; set; }
        public decimal AAC_PER { get; set; }
        public decimal Gross_Cost { get; set; }
        public decimal Net_Cost { get; set; }
        public int Status { get; set; }
    }
}
