using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hedgehogs.MVC.Models
{
    public class HedgehogPostRequest
    {
        public string Name { get; set; }

        public int SpikeCount { get; set; }

        public double Radius { get; set; }

        public string PictureUrl { get; set; }
        public string Description { get; set; }
    }
}
