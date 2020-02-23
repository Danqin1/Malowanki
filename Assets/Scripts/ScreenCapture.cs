using System;
using System.IO;
using UnityEngine;

public class ScreenCapture : MonoBehaviour
{
    private static ScreenCapture instance;
    private Camera myCam;
    private bool takeScreenshot;
    private void Awake()
    {
        instance = this;
        myCam = GetComponent<Camera>();
    }
    private void OnPostRender()
    {
        if(takeScreenshot)
        {
            takeScreenshot = false;
            RenderTexture renderTexture = myCam.targetTexture;
            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect,0,0);

            byte[] bytes = renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/ScreenShot"+Time.deltaTime+".png", bytes);
            print("photo saved");
            RenderTexture.ReleaseTemporary(renderTexture);
            myCam.targetTexture = null;
        }
        
    }
    private void TakeScreenshot(int width, int height)
    {
        myCam.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takeScreenshot = true;
    }
    public static void TakeScreenshot_Static(int width, int height)
    {
        instance.TakeScreenshot(width,height);
    }
}
