using System;
using System.Collections.Generic;

namespace appSix.Models
{
    public partial class Cities
    {
        public Cities()
        {
            Projects = new HashSet<Projects>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int CountryId { get; set; }

        public virtual Countries Country { get; set; }
        public virtual ICollection<Projects> Projects { get; set; }
    }
}
