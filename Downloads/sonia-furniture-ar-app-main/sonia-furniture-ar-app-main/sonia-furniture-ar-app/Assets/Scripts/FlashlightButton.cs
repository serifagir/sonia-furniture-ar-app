using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class FlashlightButton : MonoBehaviour
{
    private bool isFlashlightOn;

    private void Start()
    {
        isFlashlightOn = false;
    }

    private void OnTouchDown() // Change this based on the input method you're using (e.g., OnClick, OnTouch)
    {
        ToggleFlashlight();
    }

    private void ToggleFlashlight()
    {
        ARCameraManager cameraManager = FindObjectOfType<ARCameraManager>();
        if (cameraManager == null)
        {
            Debug.LogWarning("ARCameraManager not found in the scene!");
            return;
        }

        if (isFlashlightOn)
        {
            // Turn off the flashlight
            cameraManager.requestedLightEstimation = LightEstimation.None;
            isFlashlightOn = false;
        }
        else
        {
            // Turn on the flashlight
            cameraManager.requestedLightEstimation = LightEstimation.AmbientColor;
            isFlashlightOn = true;
        }
    }
}
