using Hedgehogs.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hedgehogs.MVC.ViewModels
{
    public class HedgehogListViewModel
    {
        public ICollection<Hedgehog> Hedgehogs { get; set; }
    }
}
