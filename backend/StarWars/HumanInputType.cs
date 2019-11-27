using GraphQL.Types;
using StarWars.Types;

namespace StarWars
{
    public class HumanInputType : CharacterInputType<Human>
    {
        public HumanInputType():base()
        {
            Name = "HumanInput";
            
            Field(x => x.HomePlanet, nullable: true);
            Field(x => x.Age, nullable: true);
            Field(x => x.Id, nullable: false);
        }


    }

    public class CharacterInputType<T> : InputObjectGraphType<T> where T:StarWarsCharacter
    {
        

        public CharacterInputType()
        {
            Name = "CharacterInput";
            Field(x => x.Name);
        }
    }

    public class DroidInputType : CharacterInputType<Droid>
    {
        public DroidInputType():base()
        {
            Field(x => x.PrimaryFunction);
        }
    }
}
