using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Letters
{
    public class LettersUI : MonoBehaviour
    {
        public Action<string> OnLetterSelected;
        
        [SerializeField] private GameObject letterPrefab;
        [SerializeField] private Transform letterContainer;
        [SerializeField] private int numberOfLetters = 26; // A-Z
        [SerializeField] private Text score;
        
        const string LETTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        
        string gameLetters = LETTERS; // You can modify this to include only specific letters if needed
        private System.Random _random = new System.Random();
        
        public void GenerateLetters()
        {
            UILetter[] spawnedLetters = letterContainer.GetComponentsInChildren<UILetter>();

            for (int i = spawnedLetters.Length - 1; i >= 0; i--)
            {
                Destroy(spawnedLetters[i].gameObject);
            }
            
            RandomizeLetters();
            
            for (int i = 0; i < numberOfLetters; i++)
            {
                GameObject letterObject = Instantiate(letterPrefab, letterContainer);
                UILetter uiLetter = letterObject.GetComponent<UILetter>();
                if (uiLetter != null)
                {
                    uiLetter.Setup(i, gameLetters[i].ToString());
                }
                
                uiLetter.OnClicked += OnLetterClicked;
            }
        }
        
        private void OnLetterClicked(UILetter letter)
        {
            Debug.Log($"Letter {gameLetters[letter.Index]} clicked: {letter.Index + 65}"); // 65 is ASCII for 'A'
            OnLetterSelected.Invoke(gameLetters[letter.Index].ToString());
        }
        
        public void BackToMenu()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
        
        private void RandomizeLetters()
        {
            gameLetters = new string(gameLetters.ToCharArray().OrderBy(c => _random.Next()).ToArray());
            Debug.Log($"Randomized letters: {gameLetters}");
        }

        public void RemoveAllLetters()
        {
            UILetter[] spawnedLetters = letterContainer.GetComponentsInChildren<UILetter>();

            for (int i = spawnedLetters.Length - 1; i >= 0; i--)
            {
                Destroy(spawnedLetters[i].gameObject);
            }
        }

        public void RemoveLetter(string letter)
        {
            UILetter[] spawnedLetters = letterContainer.GetComponentsInChildren<UILetter>();

            for (int i = spawnedLetters.Length - 1; i > 0; i--)
            {
                if (spawnedLetters[i].Letter == letter)
                {
                    Destroy(spawnedLetters[i].gameObject);
                }
            }
        }

        public void SetScore(int scoreValue)
        {
            score.text = "Score: " + scoreValue;
        }
    }
}
