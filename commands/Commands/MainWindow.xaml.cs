using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Commands
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            BindNewCommandOnKey(Key.A, Brushes.AliceBlue, Button);
            BindNewCommandOnKey(Key.B, Brushes.Blue, Button);
            BindNewCommandOnKey(Key.C, Brushes.Cyan, Button);
            BindNewCommandOnKey(Key.D, Brushes.DarkBlue, Button);
            BindNewCommandOnKey(Key.E, Brushes.LightGreen, Button);
            BindNewCommandOnKey(Key.F, Brushes.Fuchsia, Button);
            BindNewCommandOnKey(Key.G, Brushes.Green, Button);
            BindNewCommandOnKey(Key.H, Brushes.HotPink, Button);
            BindNewCommandOnKey(Key.I, Brushes.Indigo, Button);
            BindNewCommandOnKey(Key.J, Brushes.LightSeaGreen, Button);
            BindNewCommandOnKey(Key.K, Brushes.Khaki, Button);
            BindNewCommandOnKey(Key.L, Brushes.LemonChiffon, Button);
            BindNewCommandOnKey(Key.M, Brushes.Magenta, Button);
            BindNewCommandOnKey(Key.N, Brushes.Navy, Button);
            BindNewCommandOnKey(Key.O, Brushes.Orange, Button);
            BindNewCommandOnKey(Key.P, Brushes.Purple, Button);
            BindNewCommandOnKey(Key.Q, Brushes.MediumPurple, Button);
            BindNewCommandOnKey(Key.R, Brushes.Red, Button);
            BindNewCommandOnKey(Key.S, Brushes.Silver, Button);
            BindNewCommandOnKey(Key.T, Brushes.Turquoise, Button);
            BindNewCommandOnKey(Key.U, Brushes.MediumBlue, Button);
            BindNewCommandOnKey(Key.V, Brushes.Violet, Button);
            BindNewCommandOnKey(Key.W, Brushes.White, Button);
            BindNewCommandOnKey(Key.X, Brushes.DarkGray, Button);
            BindNewCommandOnKey(Key.Y, Brushes.Yellow, Button);
            BindNewCommandOnKey(Key.Z, Brushes.DarkOrange, Button);
        }

        private void BindNewCommandOnKey(Key key, Brush brush, Control element, 
            ModifierKeys modifier = ModifierKeys.Control)
        {
            var command = new RoutedCommand();
            command.InputGestures.Add(new KeyGesture(key, modifier));
            CommandBindings.Add(new CommandBinding(
                command, (s, e) => element.Background = brush));
        }
    }
}
