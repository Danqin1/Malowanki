using System;
using UnityEngine;
using UnityEngine.UI;

public class BrushManager : MonoBehaviour
{
    [SerializeField] private Slider brushSlider;
    public Material drawMat;
    
    void Start()
    {
        brushSlider.onValueChanged.AddListener(SetBrushSize);
        brushSlider.SetValueWithoutNotify(1);
        
        drawMat.color = Color.black;
        SetBrushSize(1);
    }

    private void OnDestroy()
    {
        brushSlider.onValueChanged.RemoveListener(SetBrushSize);
    }

    public void SetColor(string color)
    {
        switch(color)
        {
            case "red" :
                drawMat.color = Color.red;
                break;
            case "blue" :
                drawMat.color = Color.blue;
                break;
            case "green" :
                drawMat.color = Color.green;
                break;
            case "white" :
                drawMat.color = Color.white;// rubber as white color
                break;
            case "black" :
                drawMat.color = Color.black;
            break;
            case "cyan" :
                drawMat.color = Color.cyan;
            break;
            case "magenta" :
                drawMat.color = Color.magenta;
            break;
            case "gray" :
                drawMat.color = Color.gray;
            break;
            case "orange" :
                drawMat.color = Color.orange;
                break;
            case "yellow" :
                drawMat.color = Color.yellow;
            break;
            case "brown":
                drawMat.color = new Color(143, 100, 0);
            break;
            case "violet":
                drawMat.color = Color.violet;
                break;
            default:
                Debug.LogError("Unknown brush color: " + color);
                break;
        }
        
        drawMat.SetColor("_DrawColor", drawMat.color);
    }
    public void SetBrushSize(float size)
    {
        drawMat.SetFloat("_BrushSize", size*10);
    }
}
