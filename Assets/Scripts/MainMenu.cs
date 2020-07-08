using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuCanvas;
    public GameObject PlayModesCanvas;
    public GameObject ModelsCanvas;
    public GameObject MathMode;
    public GameObject LevelPanel;
    private string currentViewPanel;
    private void Awake()
    {
        currentViewPanel = "MainMenu";
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            switch (currentViewPanel)
            {
                case "MainMenu": Quit();
                    break;
                case "PlayModes": BackToMainMenu();
                    break;
                case "MathMode": BackPlayModes();
                    break;
                case "LevelPanel": BackToMathModes();
                    break;
                case "Models": BackPlayModes();
                    break;
                default:
                    break;
            }
        }
    }
    public void PlayButton()
    {
        MainMenuCanvas.SetActive(false);
        PlayModesCanvas.SetActive(true);
        currentViewPanel = "PlayModes";
    }
    public void PaintingModels()
    {
        PlayModesCanvas.SetActive(false);
        ModelsCanvas.SetActive(true);
        currentViewPanel = "Models";
    }
    public void PlayPuzzle()
    {
        SceneManager.LoadScene("Shapes");
    }
    public void PlayFreePaint()
    {
        SceneManager.LoadScene("DrawingWithInstantiate");
    }
    //adding -------------------------------------------------------
    public void SetLevelAndPlay(int level)
    {
        PlayerPrefs.SetInt(PlayerPrefs.GetString("MathMode","Adding")+"Level", level);
        SceneManager.LoadScene(PlayerPrefs.GetString("MathMode","Adding"));
    }

    public void PlayMath()
    {
        PlayModesCanvas.SetActive(false);
        MathMode.SetActive(true);
        currentViewPanel = "MathMode";
    }
    public void PlayMathMode(string mode)
    {
        MathMode.SetActive(false);
        LevelPanel.SetActive(true);
        currentViewPanel = "LevelPanel";
        PlayerPrefs.SetString("MathMode", mode);
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
        currentViewPanel = "MainMenu";
    }
    public void BackPlayModes()
    {
        ModelsCanvas.SetActive(false);
        PlayModesCanvas.SetActive(true);
        MathMode.SetActive(false);
        LevelPanel.SetActive(false);
        currentViewPanel = "PlayModes";
    }
    public void BackToMathModes()
    {
        MathMode.SetActive(true);
        LevelPanel.SetActive(false);
        currentViewPanel = "MathMode";
    }
    public void Quit()
    {
        Application.Quit();
    }
}
