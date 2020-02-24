using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Adding : MonoBehaviour
{
    public AudioClip winClip;
    public GameObject WinFlare;
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
        bool exists = false;
        foreach (var item in listOfScores)
        {
            item.transform.parent.gameObject.SetActive(true);
            item.text = Random.Range(2, 10).ToString();
        }
        foreach (var item in listOfScores)
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
    }
    private void Win(Transform transf)
    {
        
        Vector3 pos = transf.position;
        pos.x = pos.x / Camera.main.pixelWidth;
        pos.y = pos.y / Camera.main.pixelHeight;
        print("Win");
        AudioSource.PlayClipAtPoint(winClip, pos);
        for (int i = 0; i < 3; i++)
        {
           GameObject flare = Instantiate(WinFlare, pos, Quaternion.identity);
        }
        StartCoroutine(Reset());
    }
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(3);
        SetValues();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Btn1()
    {
        if(int.Parse(E1Text.text) == score)
        {
            Win(E1.gameObject.transform);
        }
        else
        {
            E1.gameObject.SetActive(false);
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
            E2.gameObject.SetActive(false);
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
            E3.gameObject.SetActive(false);
        }
    }
}
