using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Animations
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btDoubleannimation_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new DoubleAnimPage());
        }

        private void btPointAnimation_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new PointAnimationPage());
        }

        private void btColorAnim_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new ColorAnimationPage());
        }

        private void btBrillEffect_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new BrillantEffectControl());
        }

        private void btEasingFunction_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new EasingFunctionPage());
        }

        private void bt3Danim_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new Anim3dPage());
        }

        private void btKeyframes_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new KeyframesPage());
        }

        private void btDiscreteObjectKeyframes_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new PhotoGallery());

        }

        private void btSplineKeyframes_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new SplineKeyFramePage());
        }

        private void btEasingKeyFrames_Click(object sender, RoutedEventArgs e)
        {
            theContainer.Children.Clear();
            theContainer.Children.Add(new EasingKeyFrame());
        }


    }
}
