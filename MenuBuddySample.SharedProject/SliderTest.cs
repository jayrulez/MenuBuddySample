﻿using MenuBuddy;
using Microsoft.Xna.Framework;
using ResolutionBuddy;

namespace MenuBuddySample
{
	public class SliderTest : WidgetScreen
	{
		Label _label;
		Slider _slider;

		public SliderTest() : base("Slider Test")
		{
			CoverOtherScreens = true;
			CoveredByOtherScreens = false;
			Transition.OffTime = 1f;
		}

		public override void LoadContent()
		{
			base.LoadContent();

			AddCancelButton();

			//create the stack layout
			var stack = new StackLayout();
			stack.Position = new Point(Resolution.ScreenArea.Center.X, Resolution.TitleSafeArea.Top);

			//add the label
			_label = new Label();
			stack.AddItem(_label);

			//add the slider
			_slider = new Slider()
			{
				Min = 100,
				Max = 200,
				HandlePosition = 150,
				HandleSize = new Vector2(64, 64),
				Size = new Vector2(512, 128)
			};
			stack.AddItem(_slider);

			_label.Text = _slider.HandlePosition.ToString();

			_slider.OnDrag += ((obj, e) => {
				_label.Text = _slider.HandlePosition.ToString();
			});

			AddItem(stack);
		}
	}
}
