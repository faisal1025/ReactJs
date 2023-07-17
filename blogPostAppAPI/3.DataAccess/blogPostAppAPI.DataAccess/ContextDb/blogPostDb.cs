using System;
using System.Collections.Generic;
using System.Text;
using blogPostAppAPI.DataAccess.Domains;
using Microsoft.EntityFrameworkCore;

namespace blogPostAppAPI.DataAccess.ContextDb
{
    public class blogPostDb:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<UserPostLiked> UserPostLiked { get; set; } 

        public blogPostDb(DbContextOptions<blogPostDb> options) : base(options)
        {

        }
    }
}
