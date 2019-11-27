using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using StarWars.Types;

namespace StarWars
{
    public class StarWarsData
    {
        private readonly List<Human> _humans = new List<Human>();
        private readonly List<Droid> _droids = new List<Droid>();

        public StarWarsData()
        {
            _humans.Add(new Human
            {
                Id = "1",
                Name = "Luke",
                Friends = new[] { "3", "4" },
                AppearsIn = new[] { 4, 5, 6 },
                HomePlanet = "Tatooine",
                Age = 15
            });
            _humans.Add(new Human
            {
                Id = "2",
                Name = "Vader",
                AppearsIn = new[] { 4, 5, 6 },
                HomePlanet = "Tatooine",
                Age = 16
            });

            _droids.Add(new Droid
            {
                Id = "3",
                Name = "R2-D2",
                Friends = new[] { "1", "4" },
                AppearsIn = new[] { 4, 5, 6 },
                PrimaryFunction = "Astromech",
                Age = 17
            });
            _droids.Add(new Droid
            {
                Id = "4",
                Name = "C-3PO",
                AppearsIn = new[] { 4, 5, 6 },
                PrimaryFunction = "Protocol",
                Age = 18
            });
        }

        public IEnumerable<StarWarsCharacter> GetFriends(StarWarsCharacter character)
        {
            if (character == null)
            {
                return null;
            }

            var friends = new List<StarWarsCharacter>();
            var lookup = character.Friends;
            if (lookup != null)
            {
                _humans.Where(h => lookup.Contains(h.Id)).Apply(friends.Add);
                _droids.Where(d => lookup.Contains(d.Id)).Apply(friends.Add);
            }
            return friends;
        }

        public IEnumerable<Human> GetAll()
        {
            return _humans.ToList();
        }

        public Task<Human> GetHumanByIdAsync(string id)
        {
            return Task.FromResult(_humans.FirstOrDefault(h => h.Id == id));
        }

        public Task<Droid> GetDroidByIdAsync(string id)
        {
            return Task.FromResult(_droids.FirstOrDefault(h => h.Id == id));
        }

        public Human AddHuman(Human human)
        {
            human.Id = Guid.NewGuid().ToString();
            _humans.Add(human);
            return human;
        }

        public Human EditHuman(Human human)
        {
          var humanToEdit=  _humans.SingleOrDefault(x => x.Id == human.Id);
          if (!string.IsNullOrWhiteSpace(human.HomePlanet))
          {
              humanToEdit.HomePlanet = human.HomePlanet;
          }

          if (!string.IsNullOrWhiteSpace(human.Name))
          {
              humanToEdit.Name = human.Name;
          }

          return humanToEdit;

          // _humans.Remove()
        }

        public Droid EditDroid(Droid droid)
        {
            var droidToEdit = _droids.SingleOrDefault(x => x.Id == droid.Id);
            if (!string.IsNullOrWhiteSpace(droid.PrimaryFunction))
            {
                droidToEdit.PrimaryFunction = droid.PrimaryFunction;
            }

            if (!string.IsNullOrWhiteSpace(droid.Name))
            {
                droidToEdit.Name = droid.Name;
            }

            return droidToEdit;
        }

        public Droid AddDroid(Droid droid)
        {
            droid.Id = Guid.NewGuid().ToString();
            _droids.Add(droid);
            return droid;
        }
    }
}
