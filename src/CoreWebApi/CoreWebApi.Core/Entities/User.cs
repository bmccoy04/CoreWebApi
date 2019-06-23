using System;
using System.Collections.Generic;

namespace CoreWebApi.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate{ get; set; }
        public string ProfileImageLink { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Blog> Blogs { get; set; }

    }
}