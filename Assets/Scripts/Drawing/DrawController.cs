using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawController : MonoBehaviour
{
    [SerializeField] private ColoringUI coloringUI;
    
    public Material outMat;
    public Material drawMat;
    
    private Camera _camera;
    private RenderTexture splatMap;
    private RaycastHit hit;
    
    private Vector3 lastMousePos;
    private bool isPainting = false;

    void Start()
    {
        coloringUI.OnClear += Clear;
        
        _camera = GetComponent<Camera>();
        splatMap = new RenderTexture(1024, 1024, 0, RenderTextureFormat.ARGB32);
        outMat.SetTexture("_SplatTex", splatMap);
    }
    
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            isPainting = true;
            Hit(Input.mousePosition);
        }
        else
        {
            isPainting = false;
        }

        bool tempTouchPainting = false;
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                tempTouchPainting = true;
            }

            Hit(Input.mousePosition);
        }

        if (!tempTouchPainting)
        {
            isPainting = false;
        }
        else
        {
            isPainting = true;
        }
        
        lastMousePos = Input.mousePosition;
    }
    private void Hit(Vector3 pos)
    {
        if (isPainting)
        {
            for (float i = 0.0f; i < 1.0f; i += 0.3f)
            {
                Vector3 paintPos = Vector3.Lerp(lastMousePos, pos, i);
                
                Draw(paintPos);
            }
        }
        
        Draw(pos);
    }

    private void Draw(Vector3 pos)
    {
        if (Physics.Raycast(_camera.ScreenPointToRay(pos), out hit))
        {
            if (hit.collider.CompareTag("PaintObject"))
            {
                drawMat.SetVector("_Mouse", new Vector4(hit.textureCoord.x, hit.textureCoord.y, 0, 0));
            
                RenderTexture tmp = RenderTexture.GetTemporary(splatMap.width, splatMap.height, 0, RenderTextureFormat.ARGB32);
            
                Graphics.Blit(splatMap, tmp);
                Graphics.Blit(tmp, splatMap, drawMat);
                RenderTexture.active = splatMap;

                RenderTexture.ReleaseTemporary(tmp);
            }
        }
        
        isPainting = true;
    }

    private void Clear()
    {
        Destroy(splatMap);
        
        splatMap = new RenderTexture(1024, 1024, 0, RenderTextureFormat.ARGB32);
        outMat.SetTexture("_SplatTex", splatMap);
        
        RenderTexture tmp = RenderTexture.GetTemporary(splatMap.width, splatMap.height, 0, RenderTextureFormat.ARGB32);
            
        Graphics.Blit(splatMap, tmp);
        Graphics.Blit(tmp, splatMap, drawMat);
        RenderTexture.active = splatMap;

        RenderTexture.ReleaseTemporary(tmp);
    }
}
