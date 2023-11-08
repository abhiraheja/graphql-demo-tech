using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo2.Graphql
{
    [ExtendObjectType("Query")]
    public class InstructorQuery : QueryBase
    {
        public string Introduction => "Hello from instructor";
    }
}