using System;
using System.Collections.Generic;


namespace appSix.Models
{
    public class CountriesDTO

    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

    }
}

namespace appSix.Models
{
    public partial class Countries

    {
        public Countries()
        {
            Cities = new HashSet<Cities>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Cities> Cities { get; set; }
    }
}
