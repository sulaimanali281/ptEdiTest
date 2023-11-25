using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ptEdiTest.Models
{

    [Table("tbl_user", Schema ="ptedi")]
    public class User
    {
        public int userid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string fullname { get; set; }
        public string status { get; set; }
    }
}
