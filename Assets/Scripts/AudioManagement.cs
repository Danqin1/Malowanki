using UnityEngine;

public class AudioManagement : MonoBehaviour
{
    public AudioClip AddingWinClip;
    public AudioClip AddingBadNrClip;
    public void PlayAddingWinClip(Vector3 pos)
    {
        AudioSource.PlayClipAtPoint(AddingWinClip, pos);
    }
    public void PlayAddingBadClip(Vector3 pos)
    {
        AudioSource.PlayClipAtPoint(AddingBadNrClip, pos);
    }
}
