using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class ScreenCapture : MonoBehaviour
{
    private Camera myCam;
    public string callBack;
    private IEnumerator TakeScreenshotAndSave()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        // Save the screenshot to Gallery/Photos
        Debug.Log("Permission result: " + NativeGallery.SaveImageToGallery(ss, "ColoLearn", Time.deltaTime+"Image.png"));

        // To avoid memory leaks
        Destroy(ss);
    }
}
