using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSVPos
{
    class ProductOrder
    {
        private int po_num;
        private string barcode;
        private string po_productName;
        private int po_productPrice;
        private string po_unit;
        private int po_amount;

        public ProductOrder(int po_num, string barcode, string po_productName, int po_productPrice, string po_unit, int po_amount)
        {
            
            this.po_num = po_num;
            this.barcode = barcode;
            this.po_productName = po_productName;
            this.po_productPrice = po_productPrice;
            this.po_unit = po_unit;
            this.po_amount = po_amount;
            
        }

      
        public int Po_num { get => po_num; set => po_num = value; }
        public string Barcode { get => barcode; set => barcode = value; }
        public string Po_productName { get => po_productName; set => po_productName = value; }
        public int Po_productPrice { get => po_productPrice; set => po_productPrice = value; }
        public string Po_unit { get => po_unit; set => po_unit = value; }
        public int Po_amount { get => po_amount; set => po_amount = value; }
        
    }
}
