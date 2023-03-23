﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GraphControl;
using System.Media;
using GraphData;
using System.IO;

namespace GraphControl
{
    /// <summary>
    /// Interaction logic for LeaderBoardControl.xaml
    /// </summary>
    public partial class LeaderBoardControl : UserControl, IUpdating
    {
        public LeaderBoardControl()
        {
            InitializeComponent();
        }

        public void WriteFile(string filename)
        {
            using var file = File.CreateText(filename);
            foreach (var bar in entries)
            {
                file.WriteLine($"{bar.NameOfBar}\t{bar.Number.Text}");
            }
        }

        private List<LeaderBar> entries = new List<LeaderBar>();
        private List<LeaderBar> forSorting = new List<LeaderBar>();

        public bool HasEntry(string name) => entries.Any(x => x.NameOfBar == name);

        public IEnumerable<LeaderBar> Bars => entries;

        public void AddEntry(string name, Color color)
        {
            var newBar = new LeaderBar
            {
                NameOfBar = name,
                Color = color
            };

            entries.Add(newBar);
            forSorting.Add(newBar);

            TheGrid.Rows = entries.Count;
            TheGrid.Children.Add(newBar);

            Sort();
        }

        public void Update(GraphDataPacket data)
        {
            // This peels off an extraneous size variable we don't want
            data.GetData();

            foreach (var entry in entries)
            {
                entry.Update(data);
            }

            Sort();
        }

        public bool DescendingOrder { get; set; } = true;

        private void Sort()
        {
            double max = entries.Max((x) => x.NumberOnRight);
            double min = entries.Min((x) => x.NumberOnRight);

            // Removing this for now, for Hunger Games
            //double bottom = Math.Min(min, 0); // This allows for negative minimum scores
            double bottom = 0;

            foreach (var bar in entries)
            {
                bar.BarLength = (bar.NumberOnRight - bottom) / (max - bottom);
            }

            int multiplier = DescendingOrder ? -1 : 1;

            forSorting.Sort((x, y) => multiplier * (x.SortValue.CompareTo(y.SortValue)));
            TheGrid.Children.Clear();
            foreach (var entry in forSorting)
            {
                TheGrid.Children.Add(entry);
            }
        }

    }
}
