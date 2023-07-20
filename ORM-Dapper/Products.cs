using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.Mozilla;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace ORM_Dapper
{
    internal class Products
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; } 
        public int OnSale { get; set; }
        public int StockLevel { get; set; }
    }
}
