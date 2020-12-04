using System;
using System.Collections.Generic;

namespace AmiiboPedia.Model
{
    public class Amiibo
    {
        public string amiiboSeries { get; set; }
        public string character { get; set; }
        public string gameSeries { get; set; }
        public string head { get; set; }
        public string image { get; set; }
        public string name { get; set; }
        public Release release { get; set; }
        public string tail { get; set; }
        public string type { get; set; }
    }

    public class Amiibos
    {
        public List<Amiibo> amiibo { get; set; }
    }

}
