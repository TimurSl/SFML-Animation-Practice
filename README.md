
# SFML Animation Practice
## Description
 This project contains the source code of my practiceforo SFML animation

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
- `Game.cs` - the project's main file, contains the creation of AnimatedObject. Render, Update is in Engine.cs

## Instructions
1. Build the project using any .NET Core 7.0 compiler 
2. Place images in (Compile dir)\AnimationImages\
3. Run the SFML-Animation-Practice.exe in the folder

## Development Progress
During the development, the following tasks were completed:
1.  Importing the Engine
2. Creation of Game class
3. Creation of Animation manager (Animation.cs)
4. Creation of AnimationKeyFrame and AnimationKeyFrameBuilder
5. Creation of AnimatedObject class, that can be animated using the Animation
6. Implementing the system, that can switch states of Shape

## Future Improvements
The following features and improvements can be considered for future development:
1. Refactor code
2. Put Animations into the Engine for future projects
3. Make animations work in JSON or XML, or any other data file 

Feel free to contribute to the project by submitting pull requests or opening issues for any bugs or suggestions.

## Credits

This project was developed by Zenisoft
