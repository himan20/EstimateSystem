using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateSystem.BO
{
    public class ScheduleBO
    {
        public int EST_SchID { get; set; }
        public int EST_EditionID { get; set; }
        public int EST_PUBID { get; set; }
        public int EST_ID { get; set; }
        public System.DateTime Scheduled_Date { get; set; }
        public int CaptionID { get; set; }
        public string Language { get; set; }
        public decimal Height { get; set; }
        public decimal Weidth { get; set; }
        public decimal Total_Size { get; set; }
        public decimal Rate { get; set; }
        public int NoOfInsertion { get; set; }
        public decimal Total_Cost { get; set; }
        public decimal Agency_Discount { get; set; }
        public decimal Total_NetCost { get; set; }
    }
}
