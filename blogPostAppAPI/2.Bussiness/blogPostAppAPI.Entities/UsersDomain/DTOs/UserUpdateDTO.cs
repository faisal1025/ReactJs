﻿using blogPostAppAPI.DataAccess.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace blogPostAppAPI.Entities.UsersDomain.DTOs
{
    public class UserUpdateDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public string Gender { get; set; }
        public string Role { get; set; } = "User";
#nullable enable
        public string? Designation { get; set; }
        public string? Country { get; set; }
#nullable disable
        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<UserPostLiked> PostsLiked { get; set; }
    }
}
