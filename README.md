 First Person Controller 
By Woyboy

Unity Version 2022.3.15f1

Overview
This simple FPC is a mini first person controller that is neatly organized and is easily customizable. There is nothing complex about this controller other than having the basics of first person movement, camera controls, and a simple interaction system. The biggest thing about this package is that this controller works directly with the Cinemachine package. 

Features
Simple Movement 
 AxisRaw(“Horizontal”) and AxisRaw(“Vertical”);
Simple Sprinting mechanic 
Jumping mechanic
Simple POV Camera (Cinemachine)
Uses Cinemachine Virtual Camera for the extra features such as perlin noise, impulse sources, and cinematic camera changes
Does NOT use the POV Aim component, but a customized camera rotation script
A toggleable and customizable zoom feature
Headbobbing
Simple Interaction System
A simple Interactable.cs class with an empty space, easy for you to customize to your liking
Takes a simple key input to executing the Interact() method
Raycasting for interactables in a player script called PlayerInteractionController.cs 


Demo Scene

This simple demo scene holds the player controller prefab and the testing playground. This playground has pillars and ramps to jump off of and parkour around. The purple spheres are the interactable objects the player can interact with. If the player were to interact with the spheres a message will print on the console confirming the interaction. 
