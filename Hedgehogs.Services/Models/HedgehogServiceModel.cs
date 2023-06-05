﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Hedgehogs.Services.Models
{
    public class HedgehogServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SpikeCount { get; set; }


        public double Radius { get; set; }

        public string PictureUrl { get; set; }
        public string Description { get; set; }
    }
}
