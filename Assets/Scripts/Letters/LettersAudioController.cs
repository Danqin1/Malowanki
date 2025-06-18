using System;
using System.Linq;
using UnityEngine;

namespace Letters
{
    public class LettersAudioController : MonoBehaviour
    {
        [SerializeField] private LettersAudioDB lettersAudioDB;

        AudioSource audioSource;
        
        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayLetterSound(string selectedLetter)
        {
            LetterAudio audio = lettersAudioDB.Letters.FirstOrDefault(x => x.letter == selectedLetter);

            if (audio != null)
            {
                audioSource.PlayOneShot(audio.audioClip);
            }
            else
            {
                Debug.LogWarning("Audio clip could not be found: " + selectedLetter);
            }
        }

        public void PlayWin()
        {
            audioSource.PlayOneShot(lettersAudioDB.winClip);
        }

        public void PlayLoose()
        {
            audioSource.PlayOneShot(lettersAudioDB.looseClip);
        }
    }
}