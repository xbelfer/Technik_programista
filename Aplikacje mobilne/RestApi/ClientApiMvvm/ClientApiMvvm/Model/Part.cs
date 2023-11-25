using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApiMvvm.Model
{
    public class Part
    {
        public string PartID { get; set; }
        public string PartName { get; set; }
        public string TheSuppliers { get; set; }
        public string PartType { get; set; }
        public List<string> Suppliers { get; set; }
        public DateTime PartAvailableDate { get; set; }

        public string SupplierString
        {
            get
            {
                string result = String.Empty;
                foreach (string supplier in Suppliers)
                {
                    result += $"{supplier}, ";
                }
                result = result.Trim(',', ' ');
                return result;
            }
        }
    }
}
