Input Tool Scripts

How to Use:

GazeCaster:
- Add this Gaze Caster on your ARCamera in the scene.
- Set the lMask in the inspector to whichever layer you wish for gui collisions to occur.

GazeResponder:
- This script is the base interface that you may inherit from to allow your scripts to accept gaze events from GazeCaster.

BasicGazeButton:
- This is an example implementation of the GazeResponder. It behaves similar to a UnityEngine.UI Button. 
- Attach it and a box collider to an object, set its layer to the lMask defined by your GazeCaster, and then it will do anything you specify in the exposed Unity Events.

GazeSpriteButton:
- This is an example implementation of the GazeResponder. It behaves similar to a UnityEngine.UI Button, with added functionality to swap sprites of an expected Image component. 
- Attach it, a box collider, and a UnityEngine.UI Image component to an object, set its layer to the lMask defined by your GazeCaster, and then it will do anything you specify in the exposed Unity Events.
- Additionally, this script allows you to swap sprites based on your interaction with the button.

InputRelativeRotation:
- Attach this script to the ImageTarget. Then register to the OnRotationChange event to listen for changes in rotation.
- This event call will happen every update.

PointerControl:
- Attach sprite renderer object to ARCamera to ensure reticle stays in place on screen.
- Attach script to your sprite renderer reticle.

InputVelocity:
- Register to the OnVelocityReached() event to receive the average direction once terminal velocity is reached.

AndroidAutofocuser:
- Attach this script to the MultiTarget object that handles tracking the HoloCube.

BasicTrackableEventHandler:
- Attach this script to the MultiTarget object within the scene.

CubeOrientation:
- Call this script's OrientateToCamera function from another script by using the proper namespace:
	Merge.CubeOrientation.OrientateToCamera (Transform imageTargetLocation, Transform target);



