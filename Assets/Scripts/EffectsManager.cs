using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public AudioManagement audioManager;
    public GameObject WinFlare;
    public void Win(Vector3 posis)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(posis);
        audioManager.PlayAddingWinClip(pos);
        for (int i = 0; i < 3; i++)
        {
            Instantiate(WinFlare, pos, Quaternion.identity);
        }
    }
}
