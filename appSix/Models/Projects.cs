using System;
using System.Collections.Generic;

namespace appSix.Models
{
    public partial class Projects
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int CityId { get; set; }
        public bool IsActive { get; set; }

        public virtual Cities City { get; set; }
    }
}
