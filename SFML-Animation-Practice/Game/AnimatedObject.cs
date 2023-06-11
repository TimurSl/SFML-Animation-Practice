using agar.io.Engine;
using agar.io.Engine.Config;
using agar.io.Engine.Interfaces;
using agar.io.Engine.Types;
using SFML.Graphics;
using SFML.System;

namespace SFML_Animation_Practice.Game;

public class AnimatedObject : BaseObject, IDrawable
{
	public int ZIndex { get; set; } = 1;
	public RectangleShape Shape { get; set; }
	public Animation Animation { get; set; }
	
	public AnimatedObject()
	{
		Shape = new RectangleShape(new SFML.System.Vector2f(100, 100));
		Shape.Position = new SFML.System.Vector2f(EngineConfiguration.WindowWidth / 2, EngineConfiguration.WindowHeight / 2);
		Shape.Origin = new SFML.System.Vector2f(Shape.Size.X / 2, Shape.Size.Y / 2);
		Shape.Scale = new SFML.System.Vector2f(5, 5);

		Animation = new(Shape);
		string[] files = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory (), "AnimationImages"));
		for (var i = 0; i < files.Length; i++)
		{
			Texture texture = new Texture(files[i]);

			AnimationKeyFrame keyFrame = AnimationKeyFrameFactory.CreateKeyFrame(i / 20f).SetTexture(texture);
			Animation.KeyFrames.Add(keyFrame);
		}
		
		Game.Instance.RegisterUpdatable(Animation);
	}
	
	public void Draw(RenderTarget target)
	{
		target.Draw(Shape);
	}
}

public static class TextureExtensions
{
	public static Texture RemoveColor(this Texture texture, Color targetColor)
	{
		byte[] pixels = texture.CopyToImage().Pixels;
			
		uint width = texture.Size.X;
		uint height = texture.Size.Y;

		for (uint y = 0; y < height; y++)
		{
			for (uint x = 0; x < width; x++)
			{
				uint index = (y * width + x) * 4;
				byte red = pixels[index];
				byte green = pixels[index + 1];
				byte blue = pixels[index + 2];
				byte alpha = pixels[index + 3];
					
				if (red == targetColor.R && green == targetColor.G && blue == targetColor.B)
				{
					pixels[index + 3] = 0;
				}
			}
		}
		
		texture.Update(pixels);
		
		return texture;
	}
}