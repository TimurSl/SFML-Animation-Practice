using SFML_Animation_Practice.Engine.Types;
using SFML_Animation_Practice.Game.Objects;
using SFML.Window;

namespace SFML_Animation_Practice.Game;

public class Game : BaseGame
{
	public static Game Instance { get; private set; }
	
	private AnimatedObject animatedObject;
	
	public Game()
	{
		Instance = this;
	}

	public override void Initialize()
	{
		base.Initialize ();
		
		animatedObject = Engine.RegisterActor(new AnimatedObject ()) as AnimatedObject;
	}

	public override void Run()
	{
		base.Run ();
		animatedObject.Animation.Restart();
		Console.WriteLine("Hello World!");
	}

	protected override void OnFrameEnd()
	{
		if (Keyboard.IsKeyPressed(Keyboard.Key.E))
		{
			animatedObject.Animation.Restart ();
			animatedObject.Animation.Loop = false;
		}

		if (Keyboard.IsKeyPressed(Keyboard.Key.R))
		{
			animatedObject.Animation.Restart();
			animatedObject.Animation.Loop = true;
		}
	}
}