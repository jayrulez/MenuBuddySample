using InputHelper;
using MenuBuddy;
using Microsoft.Xna.Framework;

namespace MenuBuddySample
{
	/// <summary>
	/// The options screen is brought up over the top of the main menu
	/// screen, and gives the user a chance to configure the game
	/// in various hopefully useful ways.
	/// </summary>
	internal class ScrollOptionsScreen : MenuScreen
	{
		#region Fields

		private ScrollLayout _layout;

		private const float _scrollDelta = 5f;

		#endregion

		#region Initialization

		/// <summary>
		/// Constructor.
		/// </summary>
		public ScrollOptionsScreen()
			: base("Scroll Layout Test")
		{
		}

		public override void LoadContent()
		{
			base.LoadContent();

			AddCancelButton();

			//add the scroll options
			var scroll = new MenuEntry("Scroll Up");
			scroll.OnClick += ((object obj, ClickEventArgs e) =>
			{
				var scrollPos = _layout.ScrollPosition;
				scrollPos.Y -= _scrollDelta;
				_layout.ScrollPosition = scrollPos;
			});
			AddMenuEntry(scroll);

			scroll = new MenuEntry("Scroll Down");
			scroll.OnClick += ((object obj, ClickEventArgs e) =>
			{
				var scrollPos = _layout.ScrollPosition;
				scrollPos.Y += _scrollDelta;
				_layout.ScrollPosition = scrollPos;
            });
			AddMenuEntry(scroll);

			scroll = new MenuEntry("Scroll Left");
			scroll.OnClick += ((object obj, ClickEventArgs e) =>
			{
				var scrollPos = _layout.ScrollPosition;
				scrollPos.X -= _scrollDelta;
				_layout.ScrollPosition = scrollPos;
			});
			AddMenuEntry(scroll);

			scroll = new MenuEntry("Scroll Right");
			scroll.OnClick += ((object obj, ClickEventArgs e) =>
			{
				var scrollPos = _layout.ScrollPosition;
				scrollPos.X += _scrollDelta;
				_layout.ScrollPosition = scrollPos;
			});
			AddMenuEntry(scroll);

			//create the stack layout and add some labels
			var stack = new StackLayout()
			{
				Alignment = StackAlignment.Top,
				Horizontal = HorizontalAlignment.Left,
				Vertical = VerticalAlignment.Top
			};

			var label = new Label("buttnuts", FontSize.Small);
			var button = new RelativeLayoutButton()
			{
				HasOutline = true,
				HasBackground = false
			};
			button.Size = new Vector2(label.Rect.Width, label.Rect.Height);
			button.AddItem(label);
			button.OnClick += ((object obj, ClickEventArgs e) =>
			{
				ExitScreen();
			});
			stack.AddItem(button);

			label = new Label("catpants", FontSize.Small);
			button = new RelativeLayoutButton()
			{
				HasOutline = true,
				HasBackground = false
			};
			button.Size = new Vector2(label.Rect.Width, label.Rect.Height);
			button.AddItem(label);
			button.OnClick += ((object obj, ClickEventArgs e) =>
			{
				ExitScreen();
			});
			stack.AddItem(button);

			label = new Label("foo", FontSize.Small);
			button = new RelativeLayoutButton()
			{
				HasOutline = true,
				HasBackground = false
			};
			button.Size = new Vector2(label.Rect.Width, label.Rect.Height);
			button.AddItem(label);
			button.OnClick += ((object obj, ClickEventArgs e) =>
			{
				ExitScreen();
			});
			stack.AddItem(button);

			label = new Label("bleh", FontSize.Small);
			button = new RelativeLayoutButton()
			{
				HasOutline = true,
				HasBackground = false
			};
			button.Size = new Vector2(label.Rect.Width, label.Rect.Height);
			button.AddItem(label);
			button.OnClick += ((object obj, ClickEventArgs e) =>
			{
				ExitScreen();
			});
			stack.AddItem(button);

			//create the scroll layout and add the stack
			_layout = new ScrollLayout()
			{
				Horizontal = HorizontalAlignment.Right,
				Vertical = VerticalAlignment.Bottom,
                Size = new Vector2(label.Rect.Width, label.Rect.Height)
			};
			_layout.Position = new Point(ResolutionBuddy.Resolution.ScreenArea.Right, ResolutionBuddy.Resolution.ScreenArea.Bottom);

			_layout.AddItem(stack);
			AddItem(_layout);
		}

		#endregion
	}
}