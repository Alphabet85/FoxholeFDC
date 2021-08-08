using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FoxholeFDC.Helpers
{
    public class BorderClipping : Border
    {
        private RectangleGeometry _clipRect = new RectangleGeometry();
        private object _originalClip = new object();

        protected override void OnRender(DrawingContext dc)
        {
            ApplyClip();
            base.OnRender(dc);
        }

        public override UIElement Child
        {
            get
            {
                return base.Child;
            }
            set
            {
                if (Child != value)
                {
                    // If there is a child already, replace its original Clip property
                    if (Child != null)
                        Child.SetValue(ClipProperty, _originalClip);

                    if (value != null)
                        // Store the child's original clip
                        _originalClip = value.ReadLocalValue(ClipProperty);
                    else
                        _originalClip = null;

                    base.Child = value;
                }
            }
        }

        private void ApplyClip()
        {
            if (Child != null)
            {
                double radius = Math.Max(0.0, CornerRadius.TopLeft - (BorderThickness.Left * 0.5));

                {
                    var withBlock = _clipRect;
                    withBlock.RadiusX = radius;
                    withBlock.RadiusY = radius;
                    withBlock.Rect = new Rect(Child.RenderSize);
                }

                Child.Clip = _clipRect;
            }
        }
    }
}
