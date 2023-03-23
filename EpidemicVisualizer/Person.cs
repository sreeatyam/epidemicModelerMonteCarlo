using Arena;
using Arena.GraphicTurns;
using DongUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EpidemicVisualizer
{
    /// <summary>
    /// A basic person in the epidemic
    /// Possible make inherited classes to indicate sick people, etc.
    /// </summary>
    public class Person : MovingObject
    {
        public const double Width = .5;
        public const double Height = .5;
        private const double maxMoveDistance = 1;

        private const double infectionRadius = 5;
        private const double infectionProbability = .01;

        private const int timeToRecoveryOrDeath = 500;
        private const double deathProbability = .1;

        private bool infected = false;
        public bool Infected
        {
            get { return infected; }
            set
            {
                infected = value;
                if (infected)
                { 
                    timer = timeToRecoveryOrDeath;
                }
            }
        }

        private int timer = 0;

        static private int graphicsCode = 1;

        public Person() :
            base(graphicsCode, 1, Width, Height)
        {
            
        }

        public Person(Vector2D position) :
            base(graphicsCode, 1, Width, Height)
        {

            Position = position;
        }


        protected override bool DoTurn(Turn turn)
        {
            return turn.DoTurn();
        }

        protected override void UserDefinedBeginningOfTurn()
        {

        }

        protected override Turn UserDefinedChooseAction()
        {
            return RandomMove();
        }

        /// <summary>
        /// Moves in a random direction, if possible
        /// </summary>
        private Turn RandomMove()
        {
            // Try a bunch of times
            const int maxTries = 10;
            for (int i = 0; i < maxTries; ++i)
            {
                var direction = Vector2D.RandomDirection(maxMoveDistance, ArenaEngine.Random);
                var newPosition = Position + direction;
                if (Arena.IsValidLocation(newPosition)) 
                {
                    return new Move(this, newPosition);
                }
            }
            // If it always fails, just stay where you are
            return new Move(this, Position);
        }

        internal bool IsDead { get; set; } = false;

        public override string Name => "Person";

        protected override void UserDefinedEndOfTurn()
        {
            // Infect people around you
            if (Infected)
            {
                var potentialVictims = Arena.GetNearbyObjects<Person>(Position, infectionRadius);
                foreach (var potentialVictim in potentialVictims)
                {
                    if (!potentialVictim.Infected && ArenaEngine.Random.NextDouble() < infectionProbability)
                    {
                        potentialVictim.Infected = true;
                    }
                }
            }

            // Decrement the timer if you are sick
            if (timer > 0)
            {
                --timer;
                if (timer <= 0)
                {
                    // See if you die
                    if (ArenaEngine.Random.NextDouble() < deathProbability)
                    {
                        IsDead = true;
                    }
                    else
                    {
                        Infected = false;
                        timer = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Use to change the person graphic to a different one.
        /// Assigned by code (must be initialized in the EpidemicEngine.Initialize() function)
        /// </summary>
        private void ChangeGraphic(int newCode)
        {
            Arena.TurnSet.AddCommand(new ChangeObjectGraphic(1, Code, newCode));
        }

        public override bool IsPassable(ArenaObject mover = null)
        {
            return false;
        }
    }
}
