using GraphQL;
using GraphQL.Types;
using GraphQL_Full.net.GraphQL.GraphQLTypes;
using GraphQL_Full.net.Models;
using GraphQL_Full.net.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Full.net.GraphQL.GraphQLQueries
{
    public class AppMutation : ObjectGraphType
    {
        public AppMutation(DBService dBService)
        {
            Field<UserType>(
            "createUser",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }),
            resolve: context =>
            {
                var user = context.GetArgument<userModel>("user");
                return dBService.CreateCompany(user);
            }
            );

            Field<UserType>(
            "updateUser",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" },
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "userId" }),
            resolve: context =>
            {
                var user = context.GetArgument<userModel>("user");
                var userId = context.GetArgument<string>("userId");

                var baseUser = dBService.GetUserByID(userId);
                if (baseUser == null)
                {
                    context.Errors.Add(new ExecutionError("Couldn't find user in db."));
                    return null;
                }
                dBService.UpdateUserByID(baseUser, user);
                return user;
                }
            );

            Field<StringGraphType>(
            "deleteUser",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "userId" }),
            resolve: context =>
            {
                var userId = context.GetArgument<string>("userId");
                var user = dBService.GetUserByID(userId);
               if (user == null)
               {
                    context.Errors.Add(new ExecutionError("Couldn't find owner in db."));
                   return null;
               }

                dBService.RemoveUser(user._id);
                return $"The User with the id: {userId} has been successfully deleted from db.";
    }
);
        }
    }
}
