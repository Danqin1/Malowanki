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
            case "rubber" :
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
            case "yellow" :
                drawMat.color = Color.yellow;
            break;
        }
    }
    public void SetBrushSize(float size)
    {
        drawMat.SetFloat("_BrushSize", size*1000);
    }
}
