# Simple NDI Multiview

A free and open source multiviewer built with Unity and uses keijiro's [KlakNDI](https://github.com/keijiro/KlakNDI) integration.

### Current Functionality
+ automatically tiling of as many sources as your PC can handle
thats pretty much it. At least for now.

This was a pretty quick and dirty project that I threw together in the total time of an afternoon or 2. so because of that it's missing a lot of "creature comforts" *(aka stuff that should already exist in this kind of tool)*, so below is a list of features that im working on getting up and running in future releases.

### Upcoming Functionality

+ A refresh sources button. Atm it only looks for sources on startup.
+ Customizeable background/splash image
+ More logical source management. a way to place the NDI sources where you want them. Drag and drop hopefully
+ The abiity to output the multiview as NDI itself. Hopefully allowing for nesting NDI sources
+ General UI clean up. make it a bit more presentable.

## Screenshots
![ScreenShot](https://github.com/Casual-Cynic/Simple-NDI-Multiview/assets/28310036/1260e3a2-fbd9-48ff-a1ca-b164f792f7bd)

![ScreenShot2](https://github.com/Casual-Cynic/Simple-NDI-Multiview/assets/28310036/acb7bcdc-e09c-4b57-8ab3-ba5468d12ac8)

## Project Installation Notes
+ The project uses [Unity 2022.3.14f1](unityhub://2022.3.14f1/eff2de9070d8). If you dont already, I suggest using [Unity Hub](https://unity.com/unity-hub).
+ You *MUST* have [v2.1.0](https://github.com/keijiro/KlakNDI/releases/tag/2.1.0) of the KlakNDI package installed. Make sure to follow their [install guide](https://github.com/keijiro/KlakNDI?tab=readme-ov-file#how-to-install) if this project doesnt come with it preinstalled.
