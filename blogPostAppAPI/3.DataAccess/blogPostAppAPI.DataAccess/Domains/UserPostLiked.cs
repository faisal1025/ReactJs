using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace blogPostAppAPI.DataAccess.Domains
{
    public class UserPostLiked
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}
