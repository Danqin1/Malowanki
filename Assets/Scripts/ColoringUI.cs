using UnityEngine;
using UnityEngine.SceneManagement;

public class ColoringUI : MonoBehaviour
{
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
