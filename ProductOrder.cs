using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSVPos
{
    class ProductOrder
    {
       
        private string barcode;
        private string po_productName;
        private int po_productPrice;
        private int po_ea;
        public ProductOrder(string barcode, string po_productName, int po_productPrice, int po_ea)
        {
            this.Barcode = barcode;
            this.Po_productName = po_productName;
            this.Po_productPrice = po_productPrice;
            this.Po_ea = po_ea;
        }

        public string Barcode { get => barcode; set => barcode = value; }
        public string Po_productName { get => po_productName; set => po_productName = value; }
        public int Po_productPrice { get => po_productPrice; set => po_productPrice = value; }
        public int Po_ea { get => po_ea; set => po_ea = value; }
    }
}
