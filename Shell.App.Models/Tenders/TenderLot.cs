using System.Collections.Generic;

namespace Shell.App.Models.Tenders
{
    public class TenderLot
    {
        public string LotNumber { get; set; }

        public string Item { get; set; }

        public string NumberAndCount { get; set; }

        public string Status { get; set; }

        public List<TenderField> Fields { get; set; }

        public TenderLot()
        {
            Fields = new List<TenderField>();
        }
    }
}
