using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatsNet.Models
{
    public class FoodModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public string Type { get; set; }
        public bool FoodIsOut { get; set; }
        public int Duration { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeFinish { get; set; }
    }
}