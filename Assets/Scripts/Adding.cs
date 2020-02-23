using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Adding : MonoBehaviour
{
    public Button Number1;
    public Button Number2;
    public Button E1;
    public Button E2;
    public Button E3;
    private Text N1Text;
    private Text N2Text;
    private Text E1Text;
    private Text E2Text;
    private Text E3Text;
    int score;

    private List<int> values;
    private List<Text> listOfScores;
    private void Start()
    {
        values = new List<int>();
        listOfScores = new List<Text>();
        for (int i = 1; i <= 5; i++)
        {
            values.Add(i);
        }
        N1Text = Number1.GetComponentInChildren<Text>();
        N2Text = Number2.GetComponentInChildren<Text>();
        E1Text = E1.GetComponentInChildren<Text>();
        E2Text = E2.GetComponentInChildren<Text>();
        E3Text = E3.GetComponentInChildren<Text>();
        listOfScores.Add(E1Text);
        listOfScores.Add(E2Text);
        listOfScores.Add(E3Text);
        SetValues();
    }
    private void SetValues()
    {
        int _1 = Random.Range(1, 5);
        N1Text.text = _1.ToString();
        int _2 = Random.Range(1, 5);
        N2Text.text = _2.ToString();
        score = _1+_2;
        foreach (var item in listOfScores)
        { 
            item.text = Random.Range(2, 10).ToString();
        }
    }
}
