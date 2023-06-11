using agar.io.Engine.Config;
using agar.io.Engine.Interfaces;
using SFML.Window;

namespace agar.io.Engine.Types;

public abstract class BaseGame
{
	protected Engine Engine { get; init; }

	protected BaseGame()
	{
		Engine = new Engine();
		
		Engine.OnFrameStart += OnFrameStart;
		Engine.OnFrameEnd += OnFrameEnd;
		
		Engine.Window.Closed += OnWindowClosed;
	}
	
	public virtual void Run()
	{
		Initialize();
		
		Engine.Run();
	}
	
	public virtual void Initialize()
	{
		Engine.DestroyAll();
		
	}

	protected virtual void OnFrameStart()
	{
		
	}

	protected virtual void OnFrameEnd()
	{
		
	}
	
	protected virtual void OnWindowClosed(object sender, EventArgs args)
	{
		Window window = (Window) sender;
		EngineConfiguration.Save();
		
		window.Close();
	}
	
	public virtual void RegisterUpdatable(IUpdatable updatable)
	{
		Engine.RegisterUpdatable(updatable);
	}
	
	public virtual void RegisterDrawable(IDrawable drawable)
	{
		Engine.RegisterDrawable(drawable);
	}
	
}