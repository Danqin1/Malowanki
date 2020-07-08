using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    private Text _text;
    private void Start()
    {
        _text = GetComponent<Text>();
    }
    void Update()
    {
        _text.text = PlayerPrefs.GetInt(PlayerPrefs.GetString("MathMode","Adding")+"Score",0).ToString();
    }
}
