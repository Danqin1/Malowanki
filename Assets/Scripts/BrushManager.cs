using UnityEngine;

public class BrushManager : MonoBehaviour
{
    public Painter painter;
    void Start()
    {
        //initializing values
        painter.BrushColor = Color.red;
        painter.BrushSize = 1f;
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
<<<<<<< Updated upstream
                painter.BrushColor = Color.magenta;
            break;
=======
                drawMat.color = new Color(1, 0.41f, 0.70f);
                break;
>>>>>>> Stashed changes
            case "gray" :
                painter.BrushColor = Color.gray;
            break;
            case "yellow" :
<<<<<<< Updated upstream
                painter.BrushColor = Color.yellow;
            break;
=======
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
>>>>>>> Stashed changes
        }
    }
    public void SetBrushSize(float size)
    {
        painter.BrushSize = size;
    }
}
