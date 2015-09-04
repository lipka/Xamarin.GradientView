# Xamarin.GradientView

A Xamarin.iOS (formerly MonoTouch) implementation of a gradient view.

* Configurable direction
* Linear or radial mode
* Color stop locations
* Supports the new Unified API

## Usage

``` c#
using Xamarin;

...

var gradientView = new GradientView ();
gradientView.Direction = GradientViewDirection.Horizontal;
gradientView.Mode = GradientViewMode.Linear;
gradientView.Colors = new UIColor[] { UIColor.Red, UIColor.Blue };
gradientView.Locations = new nfloat[] { 0.3f, 0.7f };
View.AddSubview (gradientView);
```

## Installation

Just add GradientView.cs to your project. Boom. Done.

## Requirements

Xamarin.GradientView is tested on iOS7 and above.

## Contact

Lukas Lipka

- http://github.com/lipka
- http://twitter.com/lipec
- http://lukaslipka.com

## License

Xamarin.GradientView is available under the [MIT license](LICENSE). See the LICENSE file for more info.
