using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public void ToggleFlashlight()
    {
        // Eğer uygulama Android platformunda çalışıyorsa
        if (Application.platform == RuntimePlatform.Android)
        {
            // Flaş ışığını açma/kapama işlemini gerçekleştir
            AndroidJavaClass cameraClass = new AndroidJavaClass("android.hardware.Camera");
            AndroidJavaObject cameraObject = cameraClass.CallStatic<AndroidJavaObject>("open");
            cameraObject.Call("startPreview");
            AndroidJavaObject paramsObject = cameraObject.Call<AndroidJavaObject>("getParameters");
            string flashMode = paramsObject.Call<string>("getFlashMode");
            if (flashMode.Equals("torch"))
            {
                paramsObject.Call("setFlashMode", "off");
            }
            else
            {
                paramsObject.Call("setFlashMode", "torch");
            }
            cameraObject.Call("setParameters", paramsObject);
            cameraObject.Call("release");
        }
    }
}
