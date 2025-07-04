using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace FoodAndCore.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Name Not Empty")]
        [StringLength(20,ErrorMessage ="Please only enter 4-20 length characters",MinimumLength =4)]
        public string Name { get; set; }

        public string? Description { get; set; }

        public bool Status { get; set; }

        public List<Food> Foods { get; set; }
    }
}
