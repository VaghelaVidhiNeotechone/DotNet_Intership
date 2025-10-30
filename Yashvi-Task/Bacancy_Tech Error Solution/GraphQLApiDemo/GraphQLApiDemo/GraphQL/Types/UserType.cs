using GraphQL.Types;
using GraphQLApiDemo.Models;
using YourProjectName.Models;

public class UserType : ObjectGraphType<User>
{
    public UserType()
    {
        Field(x => x.Id).Description("User ID");
        Field(x => x.Name).Description("User Name");
    }
}
