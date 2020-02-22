using UnityEngine;
using UnityEngine.SceneManagement;

public class FreePaintingUI : MonoBehaviour
{
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
