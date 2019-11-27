using GraphQL.Types;
using StarWars.Types;

namespace StarWars
{
    public class DroidInputType : InputObjectGraphType<Droid>
    {
        public DroidInputType()
        {
            Name = "DroidInput";
            Field(x => x.Name);
            Field(x => x.PrimaryFunction, nullable: true);
        }
    }
}