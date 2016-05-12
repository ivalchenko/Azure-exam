using System.Data;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace HelloWorld.Models
{
    public class Post
    {
        [Required]
        public int PostId { get; set; }

        [Required(ErrorMessage = "Заголовок статьи не может быть пустым!")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Заголовок статьи должен содержать не менее 5 символов!")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Описание статьи не может быть пустым!")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Описание статьи должно содержать не менее 5 символов!")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PostDate { get; set; }

        public List<Tag> Tags { get; set; }
        
        public List<Comment> Comments { get; set; }
        public int CommentsNumber { get; set; }

        public int LikesNumber { get; set; }  
        public List<ApplicationUser> LikeUser { get; set; }
    }

    public class CreatePostView
    {
        [Required(ErrorMessage = "Заголовок статьи не может быть пустым!")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Заголовок статьи должен содержать не менее 5 символов!")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Описание статьи не может быть пустым!")]
        [StringLength(1000, MinimumLength = 5, ErrorMessage = "Описание статьи должно содержать не менее 5 символов!")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Tags")]
        public string SelectedTag { get; set; }
        public SelectList TagList { get; set; }

        [Required]
        public int PostId { get; set; }
    }

    public class EditPostView
    {
        [Required(ErrorMessage = "Заголовок статьи не может быть пустым!")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Заголовок статьи должен содержать не менее 5 символов!")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Описание статьи не может быть пустым!")]
        [StringLength(1000, MinimumLength = 5, ErrorMessage = "Описание статьи должно содержать не менее 5 символов!")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Tags")]
        public string SelectedTag { get; set; }
        public SelectList TagList { get; set; }

        [Required]
        public int PostId { get; set; }

        public List<Comment> Comments { get; set; }
        public int CommentsNumber { get; set; }

        public int LikesNumber { get; set; }
    }
}