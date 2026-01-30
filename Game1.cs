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

    private SimpleAnimation _knightRun;

    private SimpleAnimation _guyAttack;

    private  Texture2D _movingCloud;

    private SpriteFont _font;

    private Texture2D _moveableObject;

    //game position variables
    private Vector2 _chestPosition = new Vector2(350,225);

    private Vector2 _knightPosition = new Vector2(180, 215);

    private Vector2 _guyPosition = new Vector2(0, 175);

    private Vector2 _cloudStartingPosition = new Vector2(350, 35);

    private Vector2 _fontPosition = new Vector2(25, 50);

    private Vector2 _playerLocation = new Vector2(30, 100);

    //other variables
    private float _moveSpeed = 15f;

    private string _text = "Monogame Assignment 1";

    private Vector2 _playerInput;  

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

        _playerInput = Vector2.Zero;

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        _background = Content.Load<Texture2D>("Background");
        _staticImage = Content.Load<Texture2D>("Chest");

        _knightRun = new SimpleAnimation(Content.Load<Texture2D>("Run"), 71, 84, 7, 7);

        _guyAttack = new SimpleAnimation(Content.Load<Texture2D>("Attack1"), 200, 200, 6, 6);

        _movingCloud = Content.Load<Texture2D>("Cloud7");

        _font = Content.Load<SpriteFont>("Font");

        _moveableObject = Content.Load<Texture2D>("Moveable");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        //Animation Updates
        _knightRun.Update(gameTime);

        _guyAttack.Update(gameTime);

        //Moving the cloud to the right automatically
        float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
       _cloudStartingPosition.X += _moveSpeed * delta;

       //Moving based on player input
       KeyboardState state = Keyboard.GetState();
       _playerInput = Vector2.Zero;

        if (state.IsKeyDown(Keys.Down))
        {
            _playerInput += new Vector2(0,1);
        }
        if (state.IsKeyDown(Keys.Up))
        {
            _playerInput += new Vector2(0,-1);
        }
        if (state.IsKeyDown(Keys.Left))
        {
            _playerInput += new Vector2(-1, 0);
        }
        if (state.IsKeyDown(Keys.Right))
        {
            _playerInput += new Vector2(1, 0);
        }
        if (state.IsKeyDown(Keys.S))
        {
            _playerInput += new Vector2(0,1);
        }
        if (state.IsKeyDown(Keys.W))
        {
            _playerInput += new Vector2(0,-1);
        }
        if (state.IsKeyDown(Keys.A))
        {
            _playerInput += new Vector2(-1, 0);
        }
        if (state.IsKeyDown(Keys.D))
        {
            _playerInput += new Vector2(1, 0);
        }

        _playerLocation += _playerInput* 4;

        //Binding player movement to screen size
        _playerLocation.X = MathHelper.Clamp(_playerLocation.X, 0, 576-64);
        _playerLocation.Y = MathHelper.Clamp(_playerLocation.Y, 0, 320-64);
        

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
        _spriteBatch.Draw(_staticImage, _chestPosition, Color.White);

        //knight animation
        _knightRun.Draw(_spriteBatch, _knightPosition, SpriteEffects.None);

        //Guy animation
        _guyAttack.Draw(_spriteBatch, _guyPosition, SpriteEffects.None);

        //automatic moving cloud
        _spriteBatch.Draw(_movingCloud, _cloudStartingPosition, Color.White);

        //Drawing the sprite font text
        _spriteBatch.DrawString(_font, _text, _fontPosition, Color.Black);

        //Drawing the moveable object
        _spriteBatch.Draw(_moveableObject, _playerLocation, Color.White);

        _spriteBatch.End();


        base.Draw(gameTime);
    }
}
