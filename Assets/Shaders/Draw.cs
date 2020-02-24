using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    public Camera camera;
    public Shader drawShader;

    private RenderTexture splatMap;
    private Material outMat, drawMat;
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        drawMat = new Material(drawShader);
        drawMat.SetVector("_Color", Color.red);

        outMat = GetComponent<MeshRenderer>().material;
        splatMap = new RenderTexture(1024, 1024, 0, RenderTextureFormat.ARGBFloat);
        outMat.SetTexture("_SplatTex", splatMap);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                drawMat.SetVector("_Mouse", new Vector4(hit.textureCoord.x, hit.textureCoord.y, 0, 0));
                RenderTexture tmp = RenderTexture.GetTemporary(splatMap.width, splatMap.height, 0, RenderTextureFormat.ARGBFloat);
                Graphics.Blit(splatMap, tmp);
                Graphics.Blit(tmp, splatMap, drawMat);
                RenderTexture.ReleaseTemporary(tmp);
            }
        }
    }
    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, 256, 256), splatMap, ScaleMode.ScaleToFit,false,1);
    }
}
