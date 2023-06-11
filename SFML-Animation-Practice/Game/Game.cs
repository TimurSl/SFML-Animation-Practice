using SFML_Animation_Practice.Engine.Types;
using SFML_Animation_Practice.Game.Objects;

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
		animatedObject.Animation.Play();
		Console.WriteLine("Hello World!");
	}
	
}