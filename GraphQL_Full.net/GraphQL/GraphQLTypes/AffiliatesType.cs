using GraphQL.Types;
using GraphQL_Full.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Full.net.GraphQL.GraphQLTypes
{
    public class AffiliatesType : ObjectGraphType<AffiliateModel>
    {
        public AffiliatesType()
        {
            Field(x => x.address);
            Field(x => x.AffiliatesName);
        }
    }
}
