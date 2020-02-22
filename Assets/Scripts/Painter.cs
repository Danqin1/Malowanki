using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painter : MonoBehaviour
{
    public GameObject flare;
    public Camera mainCam, canvasCam;
    public RenderTexture painterTexture;
    public Material baseMaterial; // material to paint;
    private Texture baseMaterialTexture;

    RaycastHit hit;
    Ray ray;

    public GameObject Brush;
    public GameObject BrushContainer;
    public Color BrushColor;
    public float BrushSize;
    private int brushCount = 0;
    private readonly int maxBrushCount = 500;
    bool saving = false;
    void Start()
    {
        baseMaterialTexture = baseMaterial.mainTexture; //  saving base texture before painting
    }
    void Update()
    {
        if (!saving)
        {
            //Raycasting -----------------------------------------------------------------------------------------------------------------
            if (Application.platform == RuntimePlatform.WebGLPlayer || Application.platform == RuntimePlatform.WindowsEditor)
            {
                if (Input.GetMouseButton(0))
                {
                    ray = mainCam.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.gameObject.CompareTag("PaintObject"))
                        {
                            //Instantiate(flare, hit.point, Quaternion.identity);
                            Paint();
                        }
                    }
                }
            }
            if (Application.platform == RuntimePlatform.Android)
            {
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    for (var i = 0; i < Input.touchCount; i++)
                    {
                        ray = mainCam.ScreenPointToRay(Input.GetTouch(0).position);
                        if (Physics.Raycast(ray, out hit))
                        {
                            if (hit.collider.gameObject.CompareTag("PaintObject"))
                            {
                                //Instantiate(flare, hit.point, Quaternion.identity);
                                Paint();
                            }
                        }
                    }
                }
            }
        }
        //-------------------------end of Raycasting ---------------------------------------------------------
    }
    private void OnApplicationQuit()
    {
        baseMaterial.mainTexture = baseMaterialTexture; // reversing all changes to texture;
    }
    private void Paint()
    {
        GameObject brushObject = Instantiate(Brush);
        BrushColor.a = 1;
        brushObject.GetComponent<SpriteRenderer>().color = BrushColor;
        brushObject.transform.parent = BrushContainer.transform;
        brushObject.transform.position = hit.point;
        brushObject.transform.localScale = Vector3.one * BrushSize;
        brushObject.layer = 8;
        brushCount++;
        if(brushCount>=maxBrushCount)
        {
            brushCount = 0;
            Brush.SetActive(false);
            Save();
        }
    }
    
    private void Save()
    {
        saving = true;
        RenderTexture.active = painterTexture;
        Texture2D tex = new Texture2D(painterTexture.width, painterTexture.height, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(0, 0, painterTexture.width, painterTexture.height), 0, 0);
        tex.Apply();
        RenderTexture.active = null;
        baseMaterial.mainTexture = tex;
        foreach (Transform child in BrushContainer.transform)
        {
            Destroy(child.gameObject);
        }
        Brush.SetActive(true);
        saving = false;
    }
}
