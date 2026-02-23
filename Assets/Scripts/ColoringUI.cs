using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColoringUI : MonoBehaviour
{
    public Action OnClear;

    public void Clear()
    {
        OnClear?.Invoke();
    }
    
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ScreenShot()
    {
        //ScreenCapture.TakeScreenshot_Static(Camera.main.pixelWidth, Camera.main.pixelHeight);
    }
}
