using System;
using System.Collections;
using UnityEngine;

namespace Letters
{
    public class LettersController : MonoBehaviour
    {
        [SerializeField] private LettersUI lettersUI;
        [SerializeField] private LettersAudioController lettersAudio;
        [SerializeField] private GameObject winFlare;

        private string gameLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // Default to A-Z
        private string selectedLetter = "A";
        private bool isRestarting = false;
        
        private int score = 0;
        
        private void Start()
        {
            lettersUI.OnLetterSelected += OnLetterSelected;
            lettersUI.SetScore(score);
            StartCoroutine(RestartCoroutine());
        }
        
        private void OnLetterSelected(string letter)
        {
            if (isRestarting)
            {
                return;
            }
            
            if (letter == selectedLetter)
            {
                score++;
                lettersAudio.PlayWin();
                lettersUI.RemoveAllLetters();
                lettersUI.SetScore(score);
                
                for (int i = 0; i < 3; i++)
                {
                    Instantiate(winFlare, new Vector3(0,0, 0), Quaternion.identity);
                }
                
                StartCoroutine(RestartCoroutine());
            }
            else
            {
                lettersUI.RemoveLetter(letter);
                lettersAudio.PlayLoose();
            }
        }

        private IEnumerator RestartCoroutine()
        {
            isRestarting = true;
            
            yield return new WaitForSecondsRealtime(2);
            selectedLetter = gameLetters[UnityEngine.Random.Range(0, gameLetters.Length)].ToString();
            lettersUI.GenerateLetters();
            
            lettersAudio.PlayLetterSound(selectedLetter);
            
            isRestarting = false;
        }
    }
}