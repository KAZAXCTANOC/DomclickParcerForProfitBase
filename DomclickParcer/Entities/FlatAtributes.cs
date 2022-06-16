using System;
using System.Collections.Generic;
using System.Text;

namespace DomclickParcer.Entities
{
    public class FlatAtributes
    {
        public string Href { get; set; }
        public string Name { get; set; }
        public List<Flat> Flats = new List<Flat>();
        public List<string> Hrefs = new List<string>();
    }
}
