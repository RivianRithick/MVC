using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class user
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string password { get; set; }
    }
}
