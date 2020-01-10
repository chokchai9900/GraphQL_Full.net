using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Full.net.GraphQL.GraphQLTypes
{
    public class UserInputType : InputObjectGraphType
    {
        public UserInputType()
        {
            Name = "userInput";
            Field<NonNullGraphType<IntGraphType>>("index");
            Field<NonNullGraphType<StringGraphType>>("guid");
            Field<NonNullGraphType<BooleanGraphType>>("isActive");
            Field<NonNullGraphType<StringGraphType>>("balance");
            Field<NonNullGraphType<StringGraphType>>("picture");
            Field<NonNullGraphType<IntGraphType>>("age");
            Field<NonNullGraphType<StringGraphType>>("eyeColor");
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("subname");
            Field<NonNullGraphType<StringGraphType>>("company");
            Field<NonNullGraphType<StringGraphType>>("email");
            Field<NonNullGraphType<StringGraphType>>("phone");
            Field<NonNullGraphType<StringGraphType>>("address");
            Field<NonNullGraphType<StringGraphType>>("registered");
            Field<NonNullGraphType<StringGraphType>>("latitude");
            Field<NonNullGraphType<StringGraphType>>("longitude");
            Field<NonNullGraphType<StringGraphType>>("greeting");
            Field<NonNullGraphType<StringGraphType>>("favoriteFruit");
        }
    }
}
