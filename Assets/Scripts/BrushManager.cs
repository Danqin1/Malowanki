using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushManager : MonoBehaviour
{    
    void Start()
    {
        //initializing values
        Shader.SetGlobalColor("_BrushColor",Color.black);
        Shader.SetGlobalFloat("_BrushOpacity",1);//
        Shader.SetGlobalFloat("_BrushSize", 0.1f);
        Shader.SetGlobalFloat("_BrushHardness", 1);
    }

    public void SetColor(string color)
    {
        switch(color)
        {
            case "red" : Shader.SetGlobalColor("_BrushColor",Color.red);
            break;
            case "blue" : Shader.SetGlobalColor("_BrushColor",Color.blue);
            break;
            case "green" : Shader.SetGlobalColor("_BrushColor",Color.green);
            break;
            case "rubber" : Shader.SetGlobalColor("_BrushColor",Color.white);
            break;
            case "black" : Shader.SetGlobalColor("_BrushColor",Color.black);
            break;
        }
    }
    public void SetBrushSize(float size)
    {
        Shader.SetGlobalFloat("_BrushSize", size);
    }
}
