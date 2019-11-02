using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Models
{
    public class Hotel
    {
        public string Name { get; set; }
        public int ClassificationLevel { get; set; }
        public float WeekTaxValueRegularClient { get; set; }
        public float WeekTaxValueFidelityClient { get; set; }
        public float WeekendTaxValueRegularClient { get; set; }
        public float WeekendTaxValueFidelityClient { get; set; }

        public float TotalValueReservation { get; set; }
       
    }
}
