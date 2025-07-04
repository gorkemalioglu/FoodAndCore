using System.ComponentModel.DataAnnotations;

namespace FoodAndCore.Data.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(20)]
        public string Password { get; set; }

        [StringLength(20)]

        public string AdminRole { get; set; }


    }
}
