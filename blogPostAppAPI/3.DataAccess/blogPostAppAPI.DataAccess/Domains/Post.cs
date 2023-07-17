using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using blogPostAppAPI.Core.Domain;
namespace blogPostAppAPI.DataAccess.Domains
{
    public class Post:DomainBase
    {
   
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public virtual ICollection<UserPostLiked> PostsLiked { get; set; }


    }
}
