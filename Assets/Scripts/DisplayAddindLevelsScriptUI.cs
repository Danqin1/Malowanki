using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayAddindLevelsScriptUI : MonoBehaviour
{
    public Button btn10;
    public Button btn20;
    public Button btn30;
    public Button btn40;
    public Button btn50;
    public Button btn100;
    private int addingLevel;
    private void Awake()
    {
        addingLevel = PlayerPrefs.GetInt("AddingScore");
        if (addingLevel < 600)
        {
            btn100.transform.GetChild(0).GetComponent<Text>().text = "X";
            btn100.interactable = false;
        }
        if (addingLevel < 500)
        {
            btn50.transform.GetChild(0).GetComponent<Text>().text = "X";
            btn50.interactable = false;
        }
        if (addingLevel < 400)
        {
            btn40.transform.GetChild(0).GetComponent<Text>().text = "X";
            btn40.interactable = false;
        }
        if (addingLevel < 300)
        {
            btn30.transform.GetChild(0).GetComponent<Text>().text = "X";
            btn30.interactable = false;
        }
        if (addingLevel < 200)
        {
            btn20.transform.GetChild(0).GetComponent<Text>().text = "X";
            btn20.interactable = false;
        }
    }
}
