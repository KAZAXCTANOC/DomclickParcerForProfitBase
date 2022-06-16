using System;
using System.Collections.Generic;
using System.Text;

namespace DomclickParcer.Entities
{
    public class ResidentialComplexHresf
    {
        public string HrefForTown { get; set; }
        public List<string> HrefsForHouses { get; set; } = new List<string>();
    }
}
