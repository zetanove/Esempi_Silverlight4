using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Styling
{
    public class FlipControlAction : TargetedTriggerAction<FrameworkElement>
    {
        #region Front element

        public static readonly DependencyProperty FrontElementNameProperty =
            DependencyProperty.Register("FrontElementName", typeof(string),
                                        typeof(FlipControlAction), new PropertyMetadata(null));

        [Category("FlipControlAction Properties")]
        public string FrontElementName { get; set; }

        #endregion

        #region Back element

        public static readonly DependencyProperty BackElementNameProperty =
            DependencyProperty.Register("BackElementName", typeof(string),
                                        typeof(FlipControlAction), new PropertyMetadata(null));

        [Category("FlipControlAction Properties")]
        public string BackElementName { get; set; }

        #endregion

        #region Duration

        public static readonly DependencyProperty DurationProperty =
            DependencyProperty.Register("Duration", typeof(Duration),
                                        typeof(FlipControlAction), new PropertyMetadata(null));

        [Category("Animation Properties")]
        public Duration Duration { get; set; }

        #endregion

        private readonly Storyboard frontToBackStoryboard = new Storyboard();
        private readonly Storyboard backToFrontStoryboard = new Storyboard();
        private bool forward = true;

        protected override void OnAttached()
        {
            base.OnAttached();
            FrameworkElement parent = AssociatedObject as FrameworkElement;
            if(parent!=null)
                parent.Loaded += new RoutedEventHandler(parent_Loaded);
        }

        void parent_Loaded(object sender, RoutedEventArgs e)
        {
            UIElement front = null;
            UIElement back = null;

            front = (sender as FrameworkElement).FindName(FrontElementName) as UIElement;
            back = (sender as FrameworkElement).FindName(BackElementName) as UIElement;
            if (front == null || back == null) return;

            if (front.Projection == null || back.Projection == null)
            {
                front.Projection = new PlaneProjection();
                front.RenderTransformOrigin = new Point(.5, .5);
                front.Visibility = Visibility.Visible;

                back.Projection = new PlaneProjection { CenterOfRotationY = .5, RotationY = 180.0 };
                back.RenderTransformOrigin = new Point(.5, .5);
                back.Visibility = Visibility.Collapsed;

                var frontPP = new PlaneProjection();
                var backPP = new PlaneProjection();

                front.RenderTransformOrigin = new Point(.5, .5);
                back.RenderTransformOrigin = new Point(.5, .5);

                front.Projection = frontPP;
                back.Projection = backPP;

                frontToBackStoryboard.Duration = this.Duration;
                backToFrontStoryboard.Duration = this.Duration;

                // Rotation
                frontToBackStoryboard.Children.Add(CreateRotationAnimation(frontPP, 0, 180));
                frontToBackStoryboard.Children.Add(CreateRotationAnimation(backPP, 0, 180));
                backToFrontStoryboard.Children.Add(CreateRotationAnimation(backPP, 180, 0));
                backToFrontStoryboard.Children.Add(CreateRotationAnimation(frontPP, 180, 0));


                // Visibility
                frontToBackStoryboard.Children.Add(CreateVisibilityAnimation(Duration, front, false));
                frontToBackStoryboard.Children.Add(CreateVisibilityAnimation(Duration, back, true));
                backToFrontStoryboard.Children.Add(CreateVisibilityAnimation(Duration, front, true));
                backToFrontStoryboard.Children.Add(CreateVisibilityAnimation(Duration, back, false));
            }
        }


        protected override void Invoke(object parameter)
        {
            if (forward)
            {
                frontToBackStoryboard.Begin();
                forward = false;
            }
            else
            {
                backToFrontStoryboard.Begin();
                forward = true;
            }
        }

        /// <summary>
        /// Creates the visibility animation.
        /// </summary>
        /// <param name="duration">The duration.</param>
        /// <param name="element">The element.</param>
        /// <param name="show">if set to <c>true</c> [show].</param>
        /// <returns></returns>
        private ObjectAnimationUsingKeyFrames CreateVisibilityAnimation(Duration duration, DependencyObject element, bool show)
        {
            var animation = new ObjectAnimationUsingKeyFrames();
            animation.BeginTime = new TimeSpan(0);
            animation.KeyFrames.Add(new DiscreteObjectKeyFrame { KeyTime = new TimeSpan(0), Value = (show ? Visibility.Collapsed : Visibility.Visible) });
            animation.KeyFrames.Add(new DiscreteObjectKeyFrame { KeyTime = new TimeSpan(duration.TimeSpan.Ticks / 2), Value = (show ? Visibility.Visible : Visibility.Collapsed) });
            Storyboard.SetTargetProperty(animation, new PropertyPath("Visibility"));
            Storyboard.SetTarget(animation, element);
            return animation;
        }


        /// <summary>
        /// Creates the rotation animation.
        /// </summary>
        /// <param name="rd">The rd.</param>
        /// <returns></returns>
        private DoubleAnimationUsingKeyFrames CreateRotationAnimation(PlaneProjection plane, double fromGradi, double toGradi)
        {

            var animation = new DoubleAnimationUsingKeyFrames();
            animation.BeginTime = new TimeSpan(0);
            animation.KeyFrames.Add(new EasingDoubleKeyFrame { KeyTime = new TimeSpan(0), Value = fromGradi, EasingFunction = new BackEase() { EasingMode = EasingMode.EaseIn } });
            animation.KeyFrames.Add(new EasingDoubleKeyFrame { KeyTime = new TimeSpan(Duration.TimeSpan.Ticks / 2), Value = Math.Abs(toGradi-fromGradi)/2 });
            animation.KeyFrames.Add(new EasingDoubleKeyFrame { KeyTime = new TimeSpan(Duration.TimeSpan.Ticks), Value = toGradi, EasingFunction = new BackEase() { EasingMode = EasingMode.EaseOut } });
            Storyboard.SetTargetProperty(animation, new PropertyPath("RotationY"));
            Storyboard.SetTarget(animation, plane);
            return animation;
        }

    }

    public class RotationData
    {
        public double FromDegrees { get; set; }
        public double MidDegrees { get; set; }
        public double ToDegrees { get; set; }
        public string RotationProperty { get; set; }
        public PlaneProjection PlaneProjection { get; set; }
        public Duration AnimationDuration { get; set; }
    }
}
