using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo4.Graphql.Base;

namespace Demo4.Graphql.Queries
{
    [ExtendObjectType("Query")]
    public class CustomerQueries : QueryBase
    {
        public string hello => "hello from query";
    }
}