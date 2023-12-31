﻿using SFML_Animation_Practice.Engine.Config;
using SFML_Animation_Practice.Engine.Interfaces;
using SFML_Animation_Practice.Engine.Types;
using SFML_Animation_Practice.Game.Animations;
using SFML_Animation_Practice.Game.Extensions;
using SFML.Graphics;
using SFML.System;

namespace SFML_Animation_Practice.Game.Objects;

public class AnimatedObject : BaseObject, IDrawable
{
	public int ZIndex { get; set; } = 1;
	public RectangleShape Shape { get; set; }
	public Animation Animation { get; set; }
	
	public AnimatedObject()
	{
		Shape = new RectangleShape(new Vector2f(70, 100));
		Shape.Position = new SFML.System.Vector2f(EngineConfiguration.WindowWidth / 2, EngineConfiguration.WindowHeight / 2);
		Shape.Origin = new SFML.System.Vector2f(Shape.Size.X / 2, Shape.Size.Y / 2);
		Shape.Scale = new SFML.System.Vector2f(1, 1);

		Animation = new(Shape, playOnStart: true);
		Animation.Loop = false;
		Animation.ResetOnStart = true;
		Animation.OnAnimationEnd += () =>
		{
			// do something
		};

		string[] files = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory (), "AnimationImages"));
		files = files.Where(x => x.EndsWith(".png") || x.EndsWith(".jpg") || x.EndsWith(".jpeg")).ToArray();

		for (var i = 0; i < files.Length; i++)
		{
			Texture texture = new Texture(files[i]);
			texture = texture.RemoveColor(new Color(0, 255, 255));

			AnimationKeyFrame keyFrame = AnimationKeyFrameBuilder
				.CreateKeyFrame(i * 0.05f)
				.SetTexture(texture)
				.SetScaleOffset(new Vector2f(0.2f, 0.2f));
			
			Animation.KeyFrames.Add(keyFrame);
		}
	}
	
	public void Draw(RenderTarget target)
	{
		target.Draw(Shape);
	}
}