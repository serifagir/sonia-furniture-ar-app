using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoCaptureButton : MonoBehaviour
{
    public Button captureButton;
    public GameObject arCameraObject;
    public string savePath = "/CapturedPhotos/";

    private void Start()
    {
        captureButton.onClick.AddListener(TakePhoto);
    }

    private void TakePhoto()
    {
        StartCoroutine(CaptureScreenshot());
    }

    private IEnumerator CaptureScreenshot()
    {
        yield return new WaitForEndOfFrame();

        // Get the current screen dimensions
        int width = Screen.width;
        int height = Screen.height;

        // Create a new texture with the screen dimensions
        Texture2D texture = new Texture2D(width, height, TextureFormat.RGB24, false);

        // Read pixels from the screen into the texture
        texture.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        texture.Apply();

        // Save the texture as a PNG file
        byte[] bytes = texture.EncodeToPNG();
        string filePath = Application.persistentDataPath + savePath + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
        System.IO.File.WriteAllBytes(filePath, bytes);

        // Destroy the texture to free up memory
        Destroy(texture);

        Debug.Log("Screenshot saved to: " + filePath);
    }
}


