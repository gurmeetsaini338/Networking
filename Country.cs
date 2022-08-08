using System;
using System.Collections.Generic;

#nullable disable

namespace Network.Db_Context
{
    public partial class Country
    {
        public Country()
        {
            States = new HashSet<State>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<State> States { get; set; }
    }
}
