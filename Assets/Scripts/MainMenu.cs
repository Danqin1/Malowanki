using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuCanvas;
    public GameObject PlayModesCanvas;
    public GameObject ModelsCanvas;
    public void PlayButton()
    {
        MainMenuCanvas.SetActive(false);
        PlayModesCanvas.SetActive(true);
    }
    public void PaintingModels()
    {
        PlayModesCanvas.SetActive(false);
        ModelsCanvas.SetActive(true);
    }
    public void PlayFreePaint()
    {
        SceneManager.LoadScene("DrawingWithInstantiate");
    }
    
    public void PlayAdding()
    {
        SceneManager.LoadScene("Adding");
    }
    public void PaintButterfly()
    {
        SceneManager.LoadScene("Butterfly");
    }
    public void PaintBear()
    {
        SceneManager.LoadScene("Bear");
    }
    public void BackToMainMenu()
    {
        MainMenuCanvas.SetActive(true);
        PlayModesCanvas.SetActive(false);
    }
    public void BackPlayModes()
    {
        ModelsCanvas.SetActive(false);
        PlayModesCanvas.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
