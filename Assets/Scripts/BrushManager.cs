using UnityEngine;

public class BrushManager : MonoBehaviour
{
    public Material drawMat;
    void Start()
    {
        drawMat.color = Color.black;
        drawMat.SetFloat("_BrushSize", 100f);
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
                drawMat.color = new Color(1, 0.41f, 0.70f);
                break;
            case "gray" :
                drawMat.color = Color.gray;
            break;
            case "yellow" :
                drawMat.color = Color.yellow;
            break;
            case "brown":
                drawMat.color = new Color(0.56f, 0.39f, 0);
                break;
            case "orange":
                drawMat.color = new Color(1, 0.65f, 0);
                break;
            case "violet":
                drawMat.color = new Color(0.61f, 0, 0.74f);
                break;
        }
    }
    public void SetBrushSize(float size)
    {
        drawMat.SetFloat("_BrushSize", size*1000);
    }
}
