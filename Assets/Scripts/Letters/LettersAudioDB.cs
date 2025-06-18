using System;
using System.Collections.Generic;
using UnityEngine;

namespace Letters
{
    [Serializable]
    public class LetterAudio
    {
        public string letter;
        public AudioClip audioClip;
    }
    
    [CreateAssetMenu(fileName = "LettersAudioDB", menuName = "PDQ/LettersAudioDB", order = 0)]
    public class LettersAudioDB : ScriptableObject
    {
        public List<LetterAudio> Letters;
        public AudioClip winClip;
        public AudioClip looseClip;
    }
}