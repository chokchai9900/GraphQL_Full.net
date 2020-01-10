using GraphQL;
using GraphQL.Types;
using GraphQL_Full.net.GraphQL.GraphQLTypes;
using GraphQL_Full.net.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Full.net.GraphQL.GraphQLQueries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(DBService dBService)
        {
            //work
            Field<ListGraphType<UserType>>(
                "GetUser",
                resolve: context => dBService.GetAllUser()
                );

            Field<UserType>(
                name: "GetUserByID",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");
                    var getdata = dBService.GetUserByID(id);

                    if (getdata == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find user in db."));
                        return null;
                    }
                    else
                    {
                        return getdata;
                    }
                    
                }
            );

            Field<ListGraphType<CompanyType>>(
                name: "GetAllCompany",
                resolve: context => dBService.GetAllCompany());

            Field<CompanyType>(
                name: "GetCompanyByID",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");
                    return dBService.GetCompanyByID(id);
                }
            );
        }
    }
}
