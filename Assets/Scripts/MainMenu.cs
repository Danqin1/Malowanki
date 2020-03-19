using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuCanvas;
    public GameObject PlayModesCanvas;
    public GameObject ModelsCanvas;
    public GameObject AddingLevels;
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
    //adding -------------------------------------------------------
    public void SetAddingLevel(int level)
    {
        PlayerPrefs.SetInt("AddingLevel", level);
        SceneManager.LoadScene("Adding");
    }

    public void PlayAdding()
    {
        PlayModesCanvas.SetActive(false);
        AddingLevels.SetActive(true);
    }
    public void PaintButterfly()
    {
        SceneManager.LoadScene("Butterfly");
    }
    public void PaintGiraffe()
    {
        SceneManager.LoadScene("Giraffe");
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
        AddingLevels.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
