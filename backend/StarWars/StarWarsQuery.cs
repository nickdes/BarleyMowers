using System;
using GraphQL.Types;
using StarWars.Types;

namespace StarWars
{
    public class StarWarsQuery : ObjectGraphType<object>
    {
        public StarWarsQuery(StarWarsData data)
        {
            Name = "Query";

            Field<CharacterInterface>("hero", resolve: context => data.GetDroidByIdAsync("3"));
            Field<HumanType>(
                "human",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the human" }
                ),
                resolve: context => data.GetHumanByIdAsync(context.GetArgument<string>("id"))
            );

            Field<HumanList>("allhumans",
               resolve: context => data.GetAllHumans()
            );
            
            Func<ResolveFieldContext, string, object> func = (context, id) => data.GetDroidByIdAsync(id);

            FieldDelegate<DroidType>(
                "droid",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the droid" }
                ),
                resolve: func
            );

            Field<DroidList>("alldroids",
               resolve: context => data.GetAllDroids()
            );

        }
    }
}
