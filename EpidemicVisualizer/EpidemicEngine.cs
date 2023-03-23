using Arena;
using DongUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpidemicVisualizer
{
    public class EpidemicEngine : ArenaEngine
    {

        public EpidemicEngine(double xSize, double ySize, int nPeople = 1, int nInfected = 1) :
            base(xSize, ySize, "concrete.jpg")
        {
            if (nPeople <= 0)
            {
                throw new ArgumentException("Invalid number of people");
            }

            int infectedCounter = 0;
            for (int i = 0; i < nPeople; ++i)
            {
                var newGuy = new Person();
                if (infectedCounter++ < nInfected)
                {
                    newGuy.Infected = true;
                }
                AddObjectRandom(newGuy);
            }

        }

        protected override void UserDefinedEndOfTurn()
        {
            base.UserDefinedEndOfTurn();
            foreach (var person in GetObjectsOfType<Person>())
            {
                if (person.IsDead)
                {
                    RemoveObjectDelay(person);
                }
            }
        }

        public double TotalInfected => GetObjectsOfType<Person>().Count((x)=> x.Infected);

        public double SizeScale { get; set; } = 1;

        public override void Initialize()
        {
            Registry.Initialize(@"EpidemicVisualizer\", @"Images\");

            Registry.AddEntry(new GraphicInfo("person.jpg", Person.Width * SizeScale, Person.Height * SizeScale));
        }
    }
}
