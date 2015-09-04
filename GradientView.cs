//
// GradientView.cs
//
// Copyright (c) 2015 Lukas Lipka. All rights reserved.
//

using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Xamarin
{
	public enum GradientViewMode {
		Linear,
		Radial,
	}

	public enum GradientViewDirection {
		Horizontal,
		Vertical
	}

	[Register ("GradientView")] 
	public class GradientView : UIView {
		CGGradient _gradient;

		GradientViewMode _mode;
		public GradientViewMode Mode {
			get { return _mode; }
			set { _mode = value; SetNeedsDisplay (); }
		}

		GradientViewDirection _direction;
		public GradientViewDirection Direction {
			get { return _direction; }
			set { _direction = value; SetNeedsDisplay (); }
		}

		UIColor[] _colors;
		public UIColor[] Colors {
			get { return _colors; }
			set { _colors = value; UpdateGradient (); }
		}

		nfloat[] _locations;
		public nfloat[] Locations {
			get { return _locations; }
			set { _locations = value; UpdateGradient (); }
		}

		public GradientView ()
		{
			Initialize ();
		}

		public GradientView (IntPtr handle) : base (handle)
		{
			Initialize ();
		}

		void Initialize ()
		{
			ContentMode = UIViewContentMode.Redraw;
		}

		public override void Draw (CGRect rect)
		{
			if (_gradient == null) {
				return;
			}

			var ctx = UIGraphics.GetCurrentContext ();

			if (Mode == GradientViewMode.Linear) {
				var startPoint = CGPoint.Empty;
				var endPoint = Direction == GradientViewDirection.Horizontal ? new CGPoint (Bounds.Width, 0) : new CGPoint (0, Bounds.Height);
				ctx.DrawLinearGradient (_gradient, startPoint, endPoint, 0);
			} else if (Mode == GradientViewMode.Radial) {
				var center = new CGPoint (Bounds.GetMidX (), Bounds.GetMidY ());
				ctx.DrawRadialGradient (_gradient, center, 0, center, Bounds.Width / 2, CGGradientDrawingOptions.DrawsAfterEndLocation);
			}
		}

		void UpdateGradient ()
		{
			if (_colors == null || _colors.Length < 2) {
				_gradient = null;
				return;
			}

			var colorspace = _colors [0].CGColor.ColorSpace;

			var gradientColors = new List<CGColor> ();
			foreach (var color in _colors) {
				gradientColors.Add (color.CGColor);
			}

			nfloat[] gradientLocations = null;
			if (Locations != null && Locations.Length == Colors.Length) {
				gradientLocations = Locations;
			}

			_gradient = new CGGradient (colorspace, gradientColors.ToArray (), gradientLocations);

			SetNeedsDisplay ();
		}
	}
}

