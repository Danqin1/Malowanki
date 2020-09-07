using UnityEngine;
using UnityEngine.SceneManagement;

public class ColoringUI : MonoBehaviour
{
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
