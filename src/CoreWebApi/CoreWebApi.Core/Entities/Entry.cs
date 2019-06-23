using System;
using System.Collections.Generic;

namespace CoreWebApi.Core.Entities
{ 
    public class Entry
    {
        public int Id { get; set; }

        public DateTime PublishDate { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        //public int AuthorId { get; set; }
        //public User Author { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set;  }

        //public ICollection<Comment> Comments { get; set; }
    }
}