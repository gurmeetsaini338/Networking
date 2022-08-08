using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Models
{
    public class TbLimagModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
       
        [DisplayName("Upload Image")]
        public IFormFile Image { get; set; }
       

       
    }
}
