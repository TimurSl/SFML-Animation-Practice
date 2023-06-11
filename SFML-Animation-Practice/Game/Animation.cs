using agar.io.Engine.Interfaces;
using SFML.Graphics;
using SFML.System;
using Time = agar.io.Engine.Types.Time;

namespace SFML_Animation_Practice.Game;

public class Animation : IUpdatable
{
	public List<AnimationKeyFrame> KeyFrames { get; set; }
	public float AnimationSpeedMultiplier { get; set; } = 1f;
	public bool Loop { get; set; } = true;
	
	
	private Shape shape;
	private int currentKeyFrameIndex = 0;
	private float currentKeyFrameTime = 0f;
	
	public Animation(Shape shape)
	{
		this.shape = shape;
		KeyFrames = new List<AnimationKeyFrame>();
	}
	
	public void Update()
	{
		// Обновление анимации
		float deltaTime = Time.DeltaTime; // Получение времени, прошедшего с последнего кадра

		currentKeyFrameTime += deltaTime * AnimationSpeedMultiplier; // Увеличение времени текущего кадра с учетом множителя скорости

		if (currentKeyFrameIndex < KeyFrames.Count)
		{
			// Проверка, достигли ли мы времени следующего ключевого кадра
			if (currentKeyFrameTime >= KeyFrames[currentKeyFrameIndex].Time)
			{
				currentKeyFrameIndex++; // Переход к следующему ключевому кадру

				if (currentKeyFrameIndex < KeyFrames.Count)
				{
					// Применение параметров текущего ключевого кадра к форме
					ApplyKeyFrameParameters(KeyFrames[currentKeyFrameIndex]);
				}
			}
		}
		else
		{
			// Если анимация зациклена, то переход к первому ключевому кадру
			if (Loop)
			{
				currentKeyFrameIndex = 0;
				currentKeyFrameTime = 0f;

				if (KeyFrames.Count > 0)
				{
					// Применение параметров первого ключевого кадра к форме
					ApplyKeyFrameParameters(KeyFrames[currentKeyFrameIndex]);
				}
			}
		}
		
		
	}

	public void Play()
	{
		// Воспроизведение анимации с интерполяцией
		currentKeyFrameIndex = 0;
		currentKeyFrameTime = 0f;

		if (KeyFrames.Count > 0)
		{
			// Применение параметров первого ключевого кадра к форме
			ApplyKeyFrameParameters(KeyFrames[currentKeyFrameIndex]);
		}
	}

	private void ApplyKeyFrameParameters(AnimationKeyFrame keyFrame)
	{
		// Применение параметров ключевого кадра к форме
		shape.Position += keyFrame.PositionOffset;
		shape.Rotation += keyFrame.RotationOffset;
		shape.Scale += keyFrame.ScaleOffset;
		shape.FillColor += keyFrame.ColorOffset;
		shape.FillColor = new Color(shape.FillColor.R, shape.FillColor.G, shape.FillColor.B, (byte)(shape.FillColor.A + keyFrame.AlphaOffset));
		shape.Texture = keyFrame.Texture;
	}

	public void AddKeyFrame(AnimationKeyFrame keyFrame)
	{
		KeyFrames.Add(keyFrame);
	}
}

public struct AnimationKeyFrame
{
	public float Time { get; set; }
	
	public SFML.System.Vector2f PositionOffset { get; set; }
	public float RotationOffset { get; set; }
	public SFML.System.Vector2f ScaleOffset { get; set; }
	public Color ColorOffset { get; set; }
	public float AlphaOffset { get; set; }
	public Texture Texture { get; set; }
}

public static class AnimationKeyFrameFactory
{
	private static AnimationKeyFrame currentKeyFrame = new AnimationKeyFrame();
	
	public static AnimationKeyFrame CreateKeyFrame(float time)
	{
		currentKeyFrame.Time = time;
		return currentKeyFrame;
	}
	
	public static AnimationKeyFrame SetPositionOffset(this AnimationKeyFrame keyFrame, SFML.System.Vector2f positionOffset)
	{
		keyFrame.PositionOffset = positionOffset;
		return keyFrame;
	}
	
	public static AnimationKeyFrame SetRotationOffset(this AnimationKeyFrame keyFrame, float rotationOffset)
	{
		keyFrame.RotationOffset = rotationOffset;
		return keyFrame;
	}
	
	public static AnimationKeyFrame SetScaleOffset(this AnimationKeyFrame keyFrame, SFML.System.Vector2f scaleOffset)
	{
		keyFrame.ScaleOffset = scaleOffset;
		return keyFrame;
	}
	
	public static AnimationKeyFrame SetColorOffset(this AnimationKeyFrame keyFrame, Color colorOffset)
	{
		keyFrame.ColorOffset = colorOffset;
		return keyFrame;
	}
	
	public static AnimationKeyFrame SetAlphaOffset(this AnimationKeyFrame keyFrame, float alphaOffset)
	{
		keyFrame.AlphaOffset = alphaOffset;
		return keyFrame;
	}
	
	public static AnimationKeyFrame SetTexture(this AnimationKeyFrame keyFrame, Texture texture)
	{
		keyFrame.Texture = texture;
		return keyFrame;
	}
}
