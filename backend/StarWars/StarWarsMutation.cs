using System;
using GraphQL.Types;
using StarWars.Types;

namespace StarWars
{
    /// <example>
    /// This is an example JSON request for a mutation
    /// {
    ///   "query": "mutation ($human:HumanInput!){ createHuman(human: $human) { id name } }",
    ///   "variables": {
    ///     "human": {
    ///       "name": "Boba Fett"
    ///     }
    ///   }
    /// }
    /// </example>
    public class StarWarsMutation : ObjectGraphType
    {
        public StarWarsMutation(StarWarsData data)
        {
            Name = "Mutation";

            Field<HumanType>(
                "createHuman",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<HumanInputType>> {Name = "human"}
                ),
                resolve: context =>
                {
                    var human = context.GetArgument<Human>("human");
                    return data.AddHuman(human);
                });

          /*  Field<HumanType>(
                "editCharacter",
                arguments: new QueryArguments(
                 //   new QueryArgument<NNullGraphType<CharacterInputType<StarWarsCharacter>>> { Name = "character" },
                    new QueryArgument<DroidInputType> { Name = "droid"},
                    new QueryArgument<DroidInputType> { Name = "human" }
                ),
                resolve: context =>
                {

                    var humanToHandle = context.GetArgument<Human>("droid");
                    var droidToHandle = context.GetArgument<Droid>("human");
                    throw new NotImplementedException();
                   // context.
                //    return data.AddHuman(human);
                });*/

            Field<HumanType>(
                "editHuman",
                arguments: new QueryArguments(
                       new QueryArgument<NonNullGraphType<HumanInputType>> { Name = "human" }

                ),
                resolve: context =>
                {

                    var humanToHandle = context.GetArgument<Human>("human");
                    throw new NotImplementedException();
                    // context.
                    //    return data.AddHuman(human);
                });
        }
    }
}
