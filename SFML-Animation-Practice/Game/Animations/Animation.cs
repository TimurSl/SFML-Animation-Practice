﻿using System.Diagnostics.Contracts;
using SFML_Animation_Practice.Engine.Interfaces;
using SFML.Graphics;
using Time = SFML_Animation_Practice.Engine.Types.Time;

namespace SFML_Animation_Practice.Game.Animations;

public class Animation : IUpdatable
{
	public bool Loop { get; set; } = true;
	public bool ResetOnStart { get; set; } = true;
	public float AnimationSpeedMultiplier { get; set; } = 1f;
	public Action OnAnimationEnd { get; set; }


	private Shape shape;
	private int currentKeyFrameIndex = 0;
	private float currentKeyFrameTime = 0f;
	private List<AnimationKeyFrame> KeyFrames { get; set; }

	private ShapeAnimationData oldState;

	public Animation(Shape shape)
	{
		this.shape = shape;
		KeyFrames = new List<AnimationKeyFrame>();
		
		oldState = new ShapeAnimationData(shape);
	}
	
	public void Update()
	{
		float deltaTime = Time.DeltaTime; 
		currentKeyFrameTime += deltaTime * AnimationSpeedMultiplier; 
		if (currentKeyFrameIndex < KeyFrames.Count)
		{
			if (currentKeyFrameTime >= KeyFrames[currentKeyFrameIndex].Time)
			{
				currentKeyFrameIndex++; 
				if (currentKeyFrameIndex < KeyFrames.Count)
				{
					ApplyKeyFrameParameters(KeyFrames[currentKeyFrameIndex]);
				}
			}
		}
		else
		{
			OnAnimationEnd?.Invoke();
			if (Loop)
			{
				if (ResetOnStart)
				{
					Reset ();
				}
				
				currentKeyFrameIndex = 0;
				currentKeyFrameTime = 0f;

				if (KeyFrames.Count > 0)
				{
					ApplyKeyFrameParameters(KeyFrames[currentKeyFrameIndex]);
				}
			}
		}
	}
	
	/// <summary>
	/// Restarts the animation.
	/// </summary>
	public void Restart()
	{
		if (ResetOnStart)
		{
			Reset ();
		}
		
		currentKeyFrameIndex = 0;
		currentKeyFrameTime = 0f;

		if (KeyFrames.Count > 0)
		{
			ApplyKeyFrameParameters(KeyFrames[currentKeyFrameIndex]);
		}
	}

	public void Reset()
	{
		oldState.Reset();
	}
	private void ApplyKeyFrameParameters(AnimationKeyFrame keyFrame)
	{
		shape.Position += keyFrame.PositionOffset;
		shape.Rotation += keyFrame.RotationOffset;
		shape.Scale += keyFrame.ScaleOffset;
		
		Color newColor = shape.FillColor + keyFrame.ColorOffset;
		shape.FillColor += newColor;
		shape.FillColor = new Color(shape.FillColor.R, shape.FillColor.G, shape.FillColor.B, (byte)(shape.FillColor.A + keyFrame.AlphaOffset));
		shape.Texture = keyFrame.Texture;
		
		keyFrame.OnAnimationKeyFrame?.Invoke();
	}

	public void AddKeyFrame(AnimationKeyFrame keyFrame)
	{
		KeyFrames.Add(keyFrame);
	}
}
