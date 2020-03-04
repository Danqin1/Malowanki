using UnityEngine;

public class BrushManager : MonoBehaviour
{
    public Material drawMat;
    void Start()
    {
        //initializing values
        drawMat.SetVector("_DrawColor", Color.red);
        //Shader.SetGlobalFloat("_BrushOpacity",1);//
        drawMat.SetFloat("_BrushSize", 100f);
        //Shader.SetGlobalFloat("_BrushHardness", 1);
    }

    public void SetColor(string color)
    {
        switch(color)
        {
            case "red" :
                drawMat.SetVector("_DrawColor", Color.red);
                break;
            case "blue" :
                drawMat.SetVector("_DrawColor", Color.blue);
                break;
            case "green" :
                drawMat.SetVector("_DrawColor", Color.green);
                break;
            case "rubber" :
                drawMat.SetVector("_DrawColor", Color.white);// rubber as white color
                break;
            case "black" :
                drawMat.SetVector("_DrawColor", Color.black);
            break;
            case "cyan" :
                drawMat.SetVector("_DrawColor", Color.cyan);
            break;
            case "magenta" :
                drawMat.SetVector("_DrawColor", Color.magenta);
            break;
            case "gray" :
                drawMat.SetVector("_DrawColor", Color.gray);
            break;
            case "yellow" :
                drawMat.SetVector("_DrawColor", Color.yellow);
            break;
        }
    }
    public void SetBrushSize(float size)
    {
        drawMat.SetFloat("_BrushSize", size*1000);
    }
}
