using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace LayoutContainers
{
    public class RadialPanel:Panel
    {
        private double radius;

        protected override Size MeasureOverride(Size availableSize)
        {
            radius = Math.Min(availableSize.Width, availableSize.Height) / 2 -10 ;
            Size max = new Size(0.0, 0.0);

            // Invoca Measure su ogni figlio e memorizza la dimensione massima di ognuno di essi
            foreach (UIElement element in this.Children)
            {
                element.Measure(availableSize);
                max.Width = Math.Max(max.Width, element.DesiredSize.Width);
                max.Height = Math.Max(max.Height, element.DesiredSize.Height);
            }

            // se availabeSize è infinita, restituisce il diametro più
            // la dimensione del figlio più grande
            double width = double.IsPositiveInfinity(availableSize.Width) ?
                (2.0 * this.radius) + max.Width : availableSize.Width;
            double height = double.IsPositiveInfinity(availableSize.Height) ?
                (2.0 * this.radius) + max.Height : availableSize.Height;

            // Deve essere restituita la dimensione che indica lo spazio disponibile mel pannello
            return new Size(width, height);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            int i = 0;
            double inc = 360.0 / this.Children.Count;
            double width, height, angle;
            foreach (FrameworkElement element in this.Children)
            {
                width = element.DesiredSize.Width / 2.0;
                height = element.DesiredSize.Height / 2.0;

                angle = inc * i++;

                RotateTransform transform = new RotateTransform();
                transform.CenterX = width;
                transform.CenterY = height;
                transform.Angle = angle;
                element.RenderTransform = transform;

                double x = this.radius * Math.Cos((Math.PI * angle) / 180.0);
                double y = this.radius * Math.Sin((Math.PI * angle) / 180.0);

                element.Arrange(new Rect((x + (finalSize.Width / 2.0)) - width,
                    (y + (finalSize.Height / 2.0)) - height,
                    element.DesiredSize.Width,
                    element.DesiredSize.Height));
            }

            return finalSize;
        }
    }
}
