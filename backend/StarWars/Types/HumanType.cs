using GraphQL.Types;
using System.Collections.Generic;

namespace StarWars.Types
{
    public class HumanType : ObjectGraphType<Human>
    {
        public HumanType(StarWarsData data)
        {
            Name = "Human";

            Field(h => h.Id).Description("The id of the human.");
            Field(h => h.Name, nullable: true).Description("The name of the human.");

            Field<ListGraphType<CharacterInterface>>(
                "friends",
                resolve: context => data.GetFriends(context.Source)
            );
            Field<ListGraphType<EpisodeEnum>>("appearsIn", "Which movie they appear in.");

            Field(h => h.HomePlanet, nullable: true).Description("The home planet of the human.");

            Field(h => h.Age, nullable: true).Description("The age of the human.");

            Interface<CharacterInterface>();
        }
    }

    public class HumanList : ObjectGraphType<List<Human>>
    {
        public HumanList(StarWarsData data)
        {
            Name = "HumanList";

            Field<ListGraphType<CharacterInterface>>(
                "humans",
                resolve: context => data.GetAll()
            );

            // Interface<CharacterInterface>();
        }
    }
}
