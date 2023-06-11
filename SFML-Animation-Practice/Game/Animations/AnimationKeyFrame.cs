using SFML.Graphics;

namespace SFML_Animation_Practice.Game.Animations;

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