using Arena;
using Arena.GraphicTurns;
using DongUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private const double maxMoveDistance = 10;

        private const double infectionRadius = 5;
        private const double infectionProbability = .01;

        private const int timeToRecoveryOrDeath = 100;
        private const double deathProbability = .5;

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


        private bool vaccinated = false;
        public bool Vaccinated
        {
            get { return vaccinated; }
            set
            {
                vaccinated = value;
                if (vaccinated)
                {
                    timer = timeToRecoveryOrDeath;
                }
            }
        }

        private bool masked = false;
        public bool Masked
        {
            get { return masked; }
            set
            {
                masked = value;
                if (masked)
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


        //the random comparison that allow the choice of location that a perosn chooses to be random.
        //Each of the locations are expressed as function calls
        protected override Turn UserDefinedChooseAction()
        {

            if (ArenaEngine.Random.NextDouble() < deathProbability)
            {
                return MainHall();
            }
            
            if (ArenaEngine.Random.NextDouble() < deathProbability)
            {
                return Hall1501();
            }

            if (ArenaEngine.Random.NextDouble() < deathProbability)
            {
                return Hall1502();
            }

            if (ArenaEngine.Random.NextDouble() < deathProbability)
            {
                return Hall1503();
            }

            if (ArenaEngine.Random.NextDouble() < deathProbability)
            {
                return Hall1504();
            }

            if (ArenaEngine.Random.NextDouble() < deathProbability)
            {
                return Hall1505();
            }

            if (ArenaEngine.Random.NextDouble() < deathProbability)
            {
                return Hall15061507();
            }
            
            return new Move(this, Position);
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

        //initial test function that moves agents to one corner
        private Turn MoveRight()
        {
            var direction = new Vector2D(1, 1);
            var newPosition = Position - direction;
            if (Arena.IsValidLocation(newPosition))
            {
                return new Move(this, newPosition);
            }

            return new Move(this, Position);
        }


        //function that sets new location to main hall, based on random vector position
        private Turn MainHall()
        {
            const int maxTries = 10;
            for (int i = 0; i < maxTries; ++i)
            {
                var direction = Vector2D.RandomDirection(maxMoveDistance, ArenaEngine.Random);
                var newPosition = Position + direction;
                if (Arena.IsValidLocation(newPosition))
                {
                    if (newPosition.X > 20 && newPosition.X < 30)
                    {
                        if (newPosition.Y > 10 && newPosition.Y < 20)
                        {
                            return new Move(this, newPosition);
                        }
                    }
                }
                
            }
            // If it always fails, just stay where you are
            return new Move(this, Position);

        }

        //function that sets new location to 1501, based on random vector position
        private Turn Hall1501()
        {
            const int maxTries = 10;
            for (int i = 0; i < maxTries; ++i)
            {
                var direction = Vector2D.RandomDirection(maxMoveDistance, ArenaEngine.Random);
                var newPosition = Position + direction;
                if (Arena.IsValidLocation(newPosition))
                {
                    if (newPosition.X > 35 && newPosition.X < 40)
                    {
                        if (newPosition.Y > 15 && newPosition.Y < 20)
                        {
                            return new Move(this, newPosition);
                        }
                    }
                }

            }
            // If it always fails, just stay where you are
            return new Move(this, Position);

        }

        //function that sets new location to 1502, based on random vector position
        private Turn Hall1502()
        {
            const int maxTries = 10;
            for (int i = 0; i < maxTries; ++i)
            {
                var direction = Vector2D.RandomDirection(maxMoveDistance, ArenaEngine.Random);
                var newPosition = Position + direction;
                if (Arena.IsValidLocation(newPosition))
                {
                    if (newPosition.X > 35 && newPosition.X < 40)
                    {
                        if (newPosition.Y > 20 && newPosition.Y < 25)
                        {
                            return new Move(this, newPosition);
                        }
                    }
                }

            }
            // If it always fails, just stay where you are
            return new Move(this, Position);

        }

        //function that sets new location to 1503, based on random vector position
        private Turn Hall1503()
        {
            const int maxTries = 10;
            for (int i = 0; i < maxTries; ++i)
            {
                var direction = Vector2D.RandomDirection(maxMoveDistance, ArenaEngine.Random);
                var newPosition = Position + direction;
                if (Arena.IsValidLocation(newPosition))
                {
                    if (newPosition.X > 35 && newPosition.X < 40)
                    {
                        if (newPosition.Y > 25 && newPosition.Y < 30)
                        {
                            return new Move(this, newPosition);
                        }
                    }
                }

            }
            // If it always fails, just stay where you are
            return new Move(this, Position);

        }

        //function that sets new location to 1504, based on random vector position
        private Turn Hall1504()
        {
            const int maxTries = 10;
            for (int i = 0; i < maxTries; ++i)
            {
                var direction = Vector2D.RandomDirection(maxMoveDistance, ArenaEngine.Random);
                var newPosition = Position + direction;
                if (Arena.IsValidLocation(newPosition))
                {
                    if (newPosition.X > 28 && newPosition.X < 33)
                    {
                        if (newPosition.Y > 25 && newPosition.Y < 30)
                        {
                            return new Move(this, newPosition);
                        }
                    }
                }

            }
            // If it always fails, just stay where you are
            return new Move(this, Position);

        }

        //function that sets new location to 1505, based on random vector position
        private Turn Hall1505()
        {
            const int maxTries = 10;
            for (int i = 0; i < maxTries; ++i)
            {
                var direction = Vector2D.RandomDirection(maxMoveDistance, ArenaEngine.Random);
                var newPosition = Position + direction;
                if (Arena.IsValidLocation(newPosition))
                {
                    if (newPosition.X > 26 && newPosition.X < 31)
                    {
                        if (newPosition.Y > 33 && newPosition.Y < 38)
                        {
                            return new Move(this, newPosition);
                        }
                    }
                }

            }
            // If it always fails, just stay where you are
            return new Move(this, Position);

        }

        //function that sets new location to grouping of 1506 and 1507, based on random vector position
        private Turn Hall15061507()
        {
            const int maxTries = 10;
            for (int i = 0; i < maxTries; ++i)
            {
                var direction = Vector2D.RandomDirection(maxMoveDistance, ArenaEngine.Random);
                var newPosition = Position + direction;
                if (Arena.IsValidLocation(newPosition))
                {
                    if (newPosition.X > 19 && newPosition.X < 29)
                    {
                        if (newPosition.Y > 28 && newPosition.Y < 33)
                        {
                            return new Move(this, newPosition);
                        }
                    }
                }

            }
            // If it always fails, just stay where you are
            return new Move(this, Position);

        }

        internal bool IsDead { get; set; } = false;

        public override string Name => "Person";

        protected override void UserDefinedEndOfTurn()
        {
            const int maxTries = 10;
            // Logic to infect people around you, also logic for deinfecting people once they step in the quarantine area based on random vector position
            if (Infected)
            {
                var potentialVictims = Arena.GetNearbyObjects<Person>(Position, infectionRadius);
                foreach (var potentialVictim in potentialVictims)
                {
                    if (!potentialVictim.Infected && ArenaEngine.Random.NextDouble() < infectionProbability && !potentialVictim.Vaccinated) 
                    {
                        potentialVictim.Infected = true;
                    }

                    else if (potentialVictim.Infected && ArenaEngine.Random.NextDouble() < infectionProbability)
                    {
                        for (int i = 0; i < maxTries; ++i)
                        {
                            var direction = Vector2D.RandomDirection(maxMoveDistance, ArenaEngine.Random);
                            var newPosition = Position + direction;
                            if (Arena.IsValidLocation(newPosition))
                            {
                                if (newPosition.X > 30 && newPosition.X < 50)
                                {
                                    if (newPosition.Y > 0 && newPosition.Y < 20)
                                    {
                                        potentialVictim.Infected = false;
                                    }
                                }
                            }

                        }
                    }
                    
                }
                
            }

            //logic for vaccination status, which vaccinates people once they step in the vaccination zone based on random vector position
            if (Infected || !Infected)
            {
                var potentialVictims = Arena.GetNearbyObjects<Person>(Position, infectionRadius);
                foreach (var potentialVictim in potentialVictims)
                {

                    if (potentialVictim.Infected && ArenaEngine.Random.NextDouble() < infectionProbability)
                    {
                        for (int i = 0; i < maxTries; ++i)
                        {
                            var direction = Vector2D.RandomDirection(maxMoveDistance, ArenaEngine.Random);
                            var newPosition = Position + direction;
                            if (Arena.IsValidLocation(newPosition))
                            {
                                if (newPosition.X > 15 && newPosition.X < 20)
                                {
                                    if (newPosition.Y > 0 && newPosition.Y < 20)
                                    {
                                        potentialVictim.Vaccinated = true;
                                    }
                                }
                            }

                        }
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
