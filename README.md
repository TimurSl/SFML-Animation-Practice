# SFML Animation Practice
## Description
 This project contains the source code of my practice for SFML animation

## Structure
### Engine - contains all game engine classes
### Game - contains all game classes (like objects, texts, etc.)
### AnimationImages - the folder where you can put your animation in images (just for testing, but you can use it later)

## Files

- `Animation.cs` - the main file of the animation
- `AnimationKeyFrame.cs` - the file of keyframe, point in the animation
- `AnimationKeyFrameBuilder.cs` - the builder of AnimationKeyFrame, can be used in creating animations with the script
- `TextureExtensions.cs` - the extensions of SFML.Graphics.Texture class, at the moment, contains only 1 method - RemoveColor, that removes color from the texture
- `AnimatedObject.cs` - the class with the object to test animations, but can be used not just in animations
- `Game.cs` - the main file of the project, contains the creation of AnimatedObject. Render, Update is in Engine.cs

## Instructions
1. Build the project using any .NET Core 7.0 compiler 
2. Place images in (Compile dir)\AnimationImages\
3. Run the SFML-Animation-Practice.exe in folder
