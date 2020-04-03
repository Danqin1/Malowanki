using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Adding : MonoBehaviour
{
    public AudioManagement audioManager;
    public EffectsManager effectsManager;
    public GameObject eventSystem;

    private readonly int minValues = 1;
    public int maxValues;

    private int scoreRate = 10; // added to player score
    //buttons
    public Button Number1;
    public Button Number2;
    public Button E1;
    public Button E2;
    public Button E3;
    //text in btns
    private Text N1Text;
    private Text N2Text;
    private Text E1Text;
    private Text E2Text;
    private Text E3Text;
    int score;

    private List<int> values;
    private List<Text> listOfScores;//list of scores to choose
    private void Start()
    {
        SetLevel();
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
    private void SetLevel()
    {
        int level = PlayerPrefs.GetInt("AddingLevel");
        switch (level)
        {
            case 10:
                maxValues = 10;
                break;
            case 20:
                maxValues = 20;
                break;
            case 30:
                maxValues = 30;
                break;
            case 40:
                maxValues = 40;
                break;
            case 50:
                maxValues = 50;
                break;
            case 100:
                maxValues = 100;
                break;
            default:
                break;
        }
    }
    private void SetValues()
    {
        int _1 = Random.Range(minValues, maxValues);
        N1Text.text = _1.ToString();
        int _2 = Random.Range(minValues, maxValues);
        N2Text.text = _2.ToString();
        score = _1+_2;
        if (score > maxValues) SetValues(); // checking if score is in range

        bool exists = false;
        foreach (var item in listOfScores)
        {
            item.transform.parent.gameObject.SetActive(true);
            item.text = Random.Range(minValues, maxValues).ToString();
        }
        foreach (var item in listOfScores)// checking good value
        {
            if (int.Parse(item.text) == score)
            {
                exists = true;
            }
        }
        if(exists == false)
        {
            int pos = Random.Range(0, 2);
            listOfScores[pos].text = score.ToString();
        }
        CheckTheSameValues();
    }
    private void CheckTheSameValues()
    {
        foreach (var item in listOfScores)// checking the same values
        {
            int count = 0;
            int tmp = int.Parse(item.text);
            for (int i = 0; i < listOfScores.Count; i++)
            {
                if (tmp == int.Parse(listOfScores[i].text))
                {
                    count++;
                    if (count > 1)
                    {
                        int newValue = Random.Range(minValues, maxValues);
                        if (newValue == int.Parse(listOfScores[i].text)) CheckTheSameValues();
                        listOfScores[i].text = newValue.ToString();
                    }
                }
            }
        }
    }
    private void Win(Transform transf)
    {
        effectsManager.Win(transf.position);
        StartCoroutine(Reset());
        PlayerPrefs.SetInt("AddingScore", PlayerPrefs.GetInt("AddingScore") + scoreRate);
        SetLevel();
    }
    private void BadNumber(Button btn)
    {
        audioManager.PlayAddingBadClip(Camera.main.ScreenToWorldPoint(btn.transform.position));
        btn.gameObject.SetActive(false);
    }
    IEnumerator Reset()
    {
        eventSystem.SetActive(false);
        yield return new WaitForSeconds(3);
        SetValues();
        eventSystem.SetActive(true);
    }
    //checking win
    public void Btn1()
    {
        if(int.Parse(E1Text.text) == score)
        {
            Win(E1.gameObject.transform);
        }
        else
        {
            BadNumber(E1);
        }
    }
    public void Btn2()
    {
        if (int.Parse(E2Text.text) == score)
        {
            Win(E2.gameObject.transform);
        }
        else
        {
            BadNumber(E2);
        }
    }
    public void Btn3()
    {
        if (int.Parse(E3Text.text) == score)
        {
            Win(E3.gameObject.transform);
        }
        else
        {
            BadNumber(E3);
        }
    }
}
