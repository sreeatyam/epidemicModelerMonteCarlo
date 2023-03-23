using Arena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpidemicVisualizer
{
    public class Obstacle : StationaryObject
    {
        private const int obstacleLayer = 1;
        private const int graphicCode = 2;

        public Obstacle(EpidemicEngine arena, double width, double height) :
            base(graphicCode, obstacleLayer, width, height)
        {
            Arena = arena;
        }

        public override string Name => "Obstacle";

        public override bool IsPassable(ArenaObject mover = null)
        {
            return false;
        }
    }
}
