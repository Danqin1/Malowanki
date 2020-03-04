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
            case "rubber":
                BrushColor = Color.white;// rubber as white color
                break;
            case "black":
                BrushColor = Color.black;
                break;
            case "cyan":
                BrushColor = Color.cyan;
                break;
            case "magenta":
                BrushColor = Color.magenta;
                break;
            case "gray":
                BrushColor = Color.gray;
                break;
            case "yellow":
                BrushColor = Color.yellow;
                break;
        }
    }
}
