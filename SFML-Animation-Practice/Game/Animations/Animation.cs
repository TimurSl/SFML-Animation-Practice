using SFML_Animation_Practice.Engine.Interfaces;
using SFML.Graphics;
using Time = SFML_Animation_Practice.Engine.Types.Time;

namespace SFML_Animation_Practice.Game.Animations;

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
			if (Loop)
			{
				currentKeyFrameIndex = 0;
				currentKeyFrameTime = 0f;

				if (KeyFrames.Count > 0)
				{
					ApplyKeyFrameParameters(KeyFrames[currentKeyFrameIndex]);
				}
			}
		}
		
		
	}

	public void Play()
	{
		currentKeyFrameIndex = 0;
		currentKeyFrameTime = 0f;

		if (KeyFrames.Count > 0)
		{
			ApplyKeyFrameParameters(KeyFrames[currentKeyFrameIndex]);
		}
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
	}

	public void AddKeyFrame(AnimationKeyFrame keyFrame)
	{
		KeyFrames.Add(keyFrame);
	}
}