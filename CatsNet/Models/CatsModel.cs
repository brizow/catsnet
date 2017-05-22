using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatsNet.Models
{
    public class CatsModel
    {
        public int Id { get; set; }
        public string CatName { get; set; }
        public string CatImage { get; set; }
        public string Type { get; set; }
        public int MoneyToGive { get; set; }
    }
}