using System;
using UnityEngine;
using UnityEngine.UI;

namespace Letters
{
    public class UILetter : MonoBehaviour
    {
        public Action<UILetter> OnClicked;

        [SerializeField] private Text text;
        
        public int Index { get; private set; }
        public string Letter { get; private set; }

        public void Setup(int index, string letter)
        {
            Index = index;
            Letter = letter;
            text.text = letter;
        }

        public void Clicked()
        {
            OnClicked.Invoke(this);
        }
    }
}