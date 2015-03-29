using FontBuddyLib;
using MenuBuddy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ResolutionBuddy;

namespace MenuBuddySample
{
	/// <summary>
	/// This screen displays on top of all the other screens
	/// </summary>
	internal class TopScreen : Screen
	{
		#region Fields

		const float TextVelocity = 2.0f;

		/// <summary>
		/// current location of the text
		/// </summary>
		Vector2 _textLocation = Vector2.Zero;

		/// <summary>
		/// current direction the text is travelling in
		/// </summary>
		Vector2 _textDirection;

		/// <summary>
		/// thing for writing text
		/// </summary>
		readonly FontBuddy _text;

		private Vector2 _textSize;

		private const string Message = "Top Screen!!!";

		#endregion //Fields

		#region Initialization

		/// <summary>
		/// Constructor fills in the menu contents.
		/// </summary>
		public TopScreen()
			: base("top")
		{
			_textDirection = new Vector2(TextVelocity, TextVelocity);
			_text = new FontBuddy();
		}

		#endregion //Initialization

		#region Methods

		public override void LoadContent()
		{
			base.LoadContent();
			_text.Font = ScreenManager.Game.Content.Load<SpriteFont>("ArialBlack48");

			_textSize = _text.Font.MeasureString(Message);
		}

		public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
		{
			base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

			//move the text
			_textLocation += _textDirection;

			//bounce the text off the walls
			if (_textLocation.X <= Resolution.TitleSafeArea.Left)
			{
				_textDirection.X = TextVelocity;
			}
			else if (_textLocation.X >= Resolution.TitleSafeArea.Right)
			{
				_textDirection.X = -TextVelocity;
			}

			if (_textLocation.Y <= Resolution.TitleSafeArea.Top)
			{
				_textDirection.Y = TextVelocity;
			}
			else if (_textLocation.Y >= Resolution.TitleSafeArea.Bottom)
			{
				_textDirection.Y = -TextVelocity;
			}
		}

		public override void Draw(GameTime gameTime)
		{
			base.Draw(gameTime);

			Vector2 textpos = _textLocation - (_textSize / 2f);

			//draw the text
			ScreenManager.SpriteBatchBegin();
			_text.Write(Message, textpos, Justify.Center, 1.0f, Color.Cyan, ScreenManager.SpriteBatch, Time);
			ScreenManager.SpriteBatchEnd();
		}

		#endregion
	}
}