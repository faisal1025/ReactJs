using blogPostAppAPI.DataAccess.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace blogPostAppAPI.Entities.PostsDomain.DTOs
{
    public class PostUpdateDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public virtual User Author { get; set; }
        public virtual ICollection<UserPostLiked> UsersLiked { get; set; }
    }

}

