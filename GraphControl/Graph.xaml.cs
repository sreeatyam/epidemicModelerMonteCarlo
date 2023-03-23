﻿using DongUtility;
using GraphData;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraphControl
{
    /// <summary>
    /// Interaction logic for Graph.xaml
    /// </summary>
    public partial class Graph : UserControl, IUpdating
    {
        /// <summary>
        /// The thing that actually does the drawing, via an interface
        /// </summary>
        public IGraphInterface InternalGraph { get; private set; }

        public Graph(IGraphInterface graph)
        {
            InitializeComponent();
            InternalGraph = graph;
        }

        /// <summary>
        /// Update the graph using the given data
        /// </summary>
        public void Update(GraphDataPacket data)
        {
            InternalGraph.Update(data);
            InvalidateVisual();
        }

        /// <summary>
        /// The fraction of space to leave on the inside margin of the graph
        /// </summary>
        public double InnerMargin { get; set; } = .15;
     
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            // Adjust for the size of the new window
            InternalGraph.UpdateTransform(ActualWidth * (1 - 2 * InnerMargin), ActualHeight * (1 - 2 * InnerMargin), 
                ActualWidth * InnerMargin, ActualHeight * InnerMargin);
            drawingContext.DrawDrawing(InternalGraph.Drawing);
        }
    }
}
