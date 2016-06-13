using System.Collections.Generic;

namespace Shell.App.Models.Tenders
{
    public class Tender
    {
        public string OperatorSite { get; set; }

        public string FullName { get; set; }

        public string Name { get; set; }

        public string Year { get; set; }

        public string Id { get; set; }

        public List<TenderDocument> Documents { get; set; }

        public List<TenderEvent> Events { get; set; }

        public List<TenderLot> Lots { get; set; }

        public List<TenderField> Fields { get; set; }

        public Tender()
        {
            Fields = new List<TenderField>();
            Lots = new List<TenderLot>();
            Events = new List<TenderEvent>();
            Documents = new List<TenderDocument>();
        }
    }
}
