using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DBA_CRUD_ASP.NET_MVC.Models
{
    public class Memo
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Title { get; set; }

        public string Body { get; set; }
    }
}