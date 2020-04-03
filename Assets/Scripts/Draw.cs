using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    public Material outMat;
    public Material drawMat;
    public Shader drawShader;

    private Camera _camera;
    private RenderTexture splatMap;
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        //drawMat = new Material(drawShader);
        //drawMat.SetVector("_DrawColor", Color.red);

        //outMat = GetComponent<MeshRenderer>().material;
        splatMap = new RenderTexture(1024, 1024, 0, RenderTextureFormat.ARGB32);
        outMat.SetTexture("_SplatTex", splatMap);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Hit(Input.mousePosition);
        }
        //touch input
        foreach (Touch touch in Input.touches)
        {
            Hit(Input.mousePosition);
        }
    }
    private void Hit(Vector3 pos)
    {
        if (Physics.Raycast(_camera.ScreenPointToRay(pos), out hit))
        {
            drawMat.SetVector("_Mouse", new Vector4(hit.textureCoord.x, hit.textureCoord.y, 0, 0));
            RenderTexture tmp = RenderTexture.GetTemporary(splatMap.width, splatMap.height, 0, RenderTextureFormat.ARGB32);
            Graphics.Blit(splatMap, tmp);
            Graphics.Blit(tmp, splatMap, drawMat);
            RenderTexture.active = splatMap;
            //GL.Clear(true, true, Color.clear);
            //RenderTexture.active = null;
            RenderTexture.ReleaseTemporary(tmp);
        }
    }
}
