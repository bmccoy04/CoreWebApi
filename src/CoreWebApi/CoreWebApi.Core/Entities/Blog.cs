using System.Collections.Generic;

namespace CoreWebApi.Core.Entities
{
    public class Blog
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Entry> Entries{ get; set; }

    }
}