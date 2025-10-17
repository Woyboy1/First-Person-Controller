# 🎮 First Person Controller 
## By Woyboy

## Unity Version 6000.0.45f1 + Cinemachine 3 Upgrade

### Overview
This simple FPC is a mini first-person controller that is neatly organized and easily customizable. There is nothing complex about this controller other than having the basics of first-person movement, camera controls, and a simple interaction system. The biggest thing about this package is that this controller works directly with the Cinemachine package. This package also includes a flexible, interactable system that allows the player to pick up an object and drop it. This is a very simple yet strong system I made to quickly prototype your projects

## 🚀 Features
- First-person movement with sprint and jump
- Cinemachine-based camera control
- Modular interaction system (pickup/drop)
- Namespace-driven architecture
- Editor tools for organization and debugging

## 📁 How to Setup
Setting up the FPC Package is very simple. Simply download the UnityPackage listed on GitHub or download all the files manually and import them into your Unity Project. This package only requires Cinemachine 3 as a dependency and does not change any project settings.

Copy the Player Controller prefab from the scene or drag it from the Prefabs folder. Nothing needs to be assigned since all the fields are assigned for you. 

Create 2 layers in your project labeled “Interactable” and “Ground” as the scripts use these references. Automatically, the controller should assign the LayerMasks itself. But if it hasn’t, please look at PlayerMovement.cs and PlayerInteractionController.cs

<img width="1078" height="517" alt="demoscene" src="https://github.com/user-attachments/assets/c604e564-14eb-4ab8-b649-fc66f8f6f9cc" />
