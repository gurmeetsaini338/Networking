using System;
using System.Collections.Generic;

#nullable disable

namespace Network.Db_Context
{
    public partial class User
    {
        public User()
        {
            InverseAdminReferCodeNavigation = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public long? AddharNo { get; set; }
        public string CreateRefer { get; set; }
        public long? Amount { get; set; }
        public string AdminReferCode { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public long? PhoneNo { get; set; }
        public string Title { get; set; }
        public string ImageData { get; set; }

        public virtual User AdminReferCodeNavigation { get; set; }
        public virtual ICollection<User> InverseAdminReferCodeNavigation { get; set; }
    }
}
