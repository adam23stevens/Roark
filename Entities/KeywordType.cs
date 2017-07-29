using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class KeywordType
    {
        public string Id { get; set; }
        public int Value { get; set; }

        public virtual ICollection<Keyword> Keywords { get; set; }
    }
}
