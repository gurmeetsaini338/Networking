using System;
using System.Collections.Generic;

#nullable disable

namespace Network.Db_Context
{
    public partial class State
    {
        public State()
        {
            Cities = new HashSet<City>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Countryid { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
