using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCorePostgres.Models
{
    public class Foo
    {

        public int FooId { get; set; }
        public string Name { get; set; }
        public DateTime DateJoined { get; set; }

        public List<Bar> Bars { get; set; }
    }
}
