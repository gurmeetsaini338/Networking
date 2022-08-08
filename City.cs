using System;
using System.Collections.Generic;

#nullable disable

namespace Network.Db_Context
{
    public partial class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Stateid { get; set; }

        public virtual State State { get; set; }
    }
}
