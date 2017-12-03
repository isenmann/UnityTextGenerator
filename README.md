# UnityTextGenerator

![alt-text](https://github.com/isenmann/UnityTextGenerator/raw/master/Screenshot/sample.gif "gif animation")

Writing text in Unity isn't that easy, at least if you want to generate text with single gameobjects. Every single letter is it's own gameobject and so you have to drag and drop every single letter to its place. 
Personally I was frustrated and didn't find a solution on the internet, so I decided to write this small script which generates text in the editor while you are typing as you can see in the animation.
I used the letters from the Unity Asset Store package "Simple Icons" (https://www.assetstore.unity3d.com/en/#!/content/59925)

## Usage

Create an empty gameobject (TextToVisualize) and attach the TextGenerator script to it. Generate a second empty gameobject (TextObjects) and add all the letters and numbers as children to it. Like you see in the screenshot:
![alt-text](https://github.com/isenmann/UnityTextGenerator/raw/master/Screenshot/textobjects.png "editor screenshots")

Set "Available Letters" in the script to the TextObjects gameobject:
![alt-text](https://github.com/isenmann/UnityTextGenerator/raw/master/Screenshot/textobjects_1.png "editor screenshots")

If the letters have some prefix or postfix in their name, then you have to set it in the script, too. The script is just looking for the letter itself in the name. So if you press an "A", then the script is looking for the "prefix + A + postfix" in the name of the gameobject.

![alt-text](https://github.com/isenmann/UnityTextGenerator/raw/master/Screenshot/textobjects_2.png "editor screenshots")
