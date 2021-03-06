# <a href="https://chewbaku.itch.io/space-game">Random Space Game Project</a>
 
## Synopsis
This is a small "game" we created in a week to generally test out new mechanics and learn stuff we haven't done before such as working with quaternions. In the rest of this synopsis, I will document all of the intermediate topics that we covered to create this game for future reference.

### Quaternions

Quaternions solve many issues by storing rotations in a 3-element vector. Unfortunately, Mr. William Rowan Hamilton made them 4 dimensional. Quaternions are used in this project for various features, though they are mainly to re-align the player's ship. When the player stops moving, they are "AutoCorrected" in the X,Y,Z, and W fields of rotation to the nearest 45 degree. This is so that they do not remain disoriented when they turn about in many different ways through the shrewd void of space. Quaternions are also used to rotate the enemy ships to the player. This works by taking the inverse cosine of the dot product of Vector3.forward and the direction to the player which results in an angle (that you then multiply to get that angle in degrees) and the cross product of those same fields which gives you an axis of rotation. Using the axis of rotation and the angle, the enemy is then set to a quaternion created with those two fields. The bullets also use quaternions to keep their rotation the same as the ships. By simply taking the ships rotation and multiplying it by a 90,0,0 euler, we are able to rotate the ships 90 degrees on the x axis.

![Imgur Image](https://imgur.com/Faivkg7.gif)
|:--:| 
| *enemy dodges player with... quaternions!* |
### Vectors

Vectors are used in a variety of places, though mainly: to get the player's direction, move them along that direction, get the direction that their shots will travel, the direction from the enemy to the player, etc.









###### <sub>coded by yannis lagrosa :3 [fork & inspect]
<!--- You're digging deep for information. I wonder if I'm in trouble? Or maybe you're similar to me? (: --->
