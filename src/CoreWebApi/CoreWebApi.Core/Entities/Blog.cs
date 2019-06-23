using CoreWebApi.Core.Shared;
using System.Collections.Generic;

namespace CoreWebApi.Core.Entities
{
    public class Blog : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Entry> Entries{ get; set; }
    }
}