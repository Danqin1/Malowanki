using UnityEngine;

public class BrushManager : MonoBehaviour
{
    public Painter painter;
    void Start()
    {
        //initializing values
        painter.BrushColor = Color.black;
        painter.BrushSize = 1;
    }

    public void SetColor(string color)
    {
        switch(color)
        {
            case "red" :
                painter.BrushColor = Color.red;
            break;
            case "blue" :
                painter.BrushColor = Color.blue;
            break;
            case "green" :
                painter.BrushColor = Color.green;
            break;
            case "rubber" :
                painter.BrushColor = Color.white;// rubber as white color
            break;
            case "black" :
                painter.BrushColor = Color.black;
            break;
            case "cyan" :
                painter.BrushColor = Color.cyan;
            break;
            case "magenta" :
                painter.BrushColor = Color.magenta;
            break;
            case "gray" :
                painter.BrushColor = Color.gray;
            break;
            case "yellow" :
                painter.BrushColor = Color.yellow;
            break;
        }
    }
    public void SetBrushSize(float size)
    {
        painter.BrushSize = size;
    }
}
