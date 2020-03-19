using UnityEngine;

public class PaintingModelUI : ColoringUI
{
    public Color BrushColor;
    void Start()
    {
        BrushColor = Color.black;
    }
    public void SetColor(string color)
    {
        switch (color)
        {
            case "red":
                BrushColor = Color.red;
                break;
            case "blue":
                BrushColor = Color.blue;
                break;
            case "green":
                BrushColor = Color.green;
                break;
            case "white":
                BrushColor = Color.white;// rubber as white color
                break;
            case "black":
                BrushColor = Color.black;
                break;
            case "cyan":
                BrushColor = Color.cyan;
                break;
            case "magenta":
                BrushColor = new Color(1,0.41f,0.70f);
                break;
            case "gray":
                BrushColor = Color.gray;
                break;
            case "yellow":
                BrushColor = Color.yellow;
                break;
            case "brown":
                BrushColor = new Color(0.56f, 0.39f, 0);
                break;
            case "orange":
                BrushColor = new Color(1, 0.65f, 0);
                break;
            case "violet":
                BrushColor = new Color(0.61f, 0, 0.74f);
                break;
        }
    }
}
