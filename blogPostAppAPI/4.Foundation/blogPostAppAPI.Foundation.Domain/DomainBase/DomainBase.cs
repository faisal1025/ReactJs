using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace blogPostAppAPI.Core.Domain
{
    public class DomainBase
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
