using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuCanvas;
    public GameObject PlayModesCanvas;
    public void PlayButton()
    {
        MainMenuCanvas.SetActive(false);
        PlayModesCanvas.SetActive(true);
    }
    public void PlayFreePaint()
    {
        SceneManager.LoadScene("DrawingWithInstantiate");
    }
    public void PlayPaintingModels()
    {
        SceneManager.LoadScene("PaintingModels");
    }
    public void PlayAdding()
    {
        SceneManager.LoadScene("Adding");
    }
    public void BackToMainMenu()
    {
        MainMenuCanvas.SetActive(true);
        PlayModesCanvas.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
