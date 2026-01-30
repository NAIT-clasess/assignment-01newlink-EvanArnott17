using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SimpleAnimationNamespace;

namespace Assignment_01;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    //creating variables for sprites
    private Texture2D _background;

    private Texture2D _staticImage;

    //game position variables
    private Vector2 _wagonPosition = new Vector2(350,225);

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        //Setting game window size
        _graphics.PreferredBackBufferWidth = 576;
        _graphics.PreferredBackBufferHeight = 320;
        _graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        _background = Content.Load<Texture2D>("Background");
        _staticImage = Content.Load<Texture2D>("Chest");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Gold);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        //Drawing the background image
        _spriteBatch.Draw(_background, Vector2.Zero, Color.White);

        //Drawing the static image
        _spriteBatch.Draw(_staticImage, _wagonPosition, Color.White);

        _spriteBatch.End();


        base.Draw(gameTime);
    }
}
