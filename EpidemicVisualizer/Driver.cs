using Arena;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Media;
using WPFUtility;

namespace EpidemicVisualizer
{
    internal class Driver
    {
        private const double xSize = 50;
        private const double ySize = 50;
        private const double timeStep = 1;
        private const int nPeople = 650;
        private const int nInfected = 5;

        static internal void Run()
        {
            Display();
        }
        static private void Display()
        {
            var window = new MainWindow(xSize, ySize, timeStep, nPeople, nInfected);
            window.Manager.AddSingleGraph("Infected", UtilityFunctions.ConvertColor(Colors.BurlyWood), () => window.Engine.Time, () => window.Engine.TotalInfected,
                "Time (hours)", "Number infected");
            window.Manager.AddSingleGraph("Alive", UtilityFunctions.ConvertColor(Colors.DarkTurquoise), () => window.Engine.Time, () => window.Engine.GetObjectsOfType<Person>().Count(),
                "Time (hours)", "Population");
            window.Manager.AddSingleGraph("Vaccinated", UtilityFunctions.ConvertColor(Colors.BurlyWood), () => window.Engine.Time, () => window.Engine.TotalVaccinated,
                "Time (hours)", "Number vaccinated");
            window.Show();
        }
    }
}
