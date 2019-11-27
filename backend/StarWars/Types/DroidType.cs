using GraphQL.Types;
using System.Collections.Generic;

namespace StarWars.Types
{
    public class DroidType : ObjectGraphType<Droid>
    {
        public DroidType(StarWarsData data)
        {
            Name = "Droid";
            Description = "A mechanical creature in the Star Wars universe.";

            Field(d => d.Id).Description("The id of the droid.");
            Field(d => d.Name, nullable: true).Description("The name of the droid.");

            Field<ListGraphType<CharacterInterface>>(
                "friends",
                resolve: context => data.GetFriends(context.Source)
            );
            Field<ListGraphType<EpisodeEnum>>("appearsIn", "Which movie they appear in.");
            Field(d => d.PrimaryFunction, nullable: true).Description("The primary function of the droid.");

            Field(d => d.Age).Description("The age of the droid.");

            Interface<CharacterInterface>();
        }
    }

    public class DroidList : ObjectGraphType<List<Droid>>
    {
        public DroidList(StarWarsData data)
        {
            Name = "DroidList";

            Field<ListGraphType<CharacterInterface>>(
                "droids",
                resolve: context => data.GetAllDroids()
            );

            // Interface<CharacterInterface>();
        }
    }
}
