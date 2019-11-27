using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;
using StarWars.Types;

namespace StarWars.Mutations
{
    public class EditCharacterMutation : ObjectGraphType
    {/*
        public EditCharacterMutation(StarWarsData data)
        {
            Name = "editCharacter";

            Field<HumanType>(
                "editCharacter",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CharacterInputType<StarWarsCharacter>>> { Name = "creature" }
                ),
                resolve: context =>
                {
                    var creatureToHandle = context.GetArgument<CharacterInputType<StarWarsCharacter>>("creature");
                    throw new NotImplementedException();
                   // context.
                //    return data.AddHuman(human);
                });
        }*/
    }
}
