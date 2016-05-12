using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HelloWorld.Models
{
    public class Tag
    {
        [Required(ErrorMessage = "Имя тега не должно быть пустым!")]
        [StringLength(60, MinimumLength = 1)]
        [RegularExpression(@"[а-яА-Яa-zA-Z0-9]", ErrorMessage = "Использованы недопустимые символы!")]
        [DataType(DataType.MultilineText)]
        public string TagName { get; set; }

        [Required]
        public int TagId { get; set; }

        public List<Post> Posts { get; set; }

        public override string ToString() {
            return TagName;
        }
    }
}