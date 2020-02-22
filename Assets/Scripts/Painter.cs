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
    //Vector3 first;
    //Vector3 second;
    //Vector3 size;

    public GameObject Brush;
    public GameObject BrushContainer;
    public Color BrushColor;
    public float BrushSize;
    private int brushCount = 0;
    private readonly int maxBrushCount = 300;
    bool saving = false;
    void Start()
    {
        baseMaterialTexture = baseMaterial.mainTexture; //  saving base texture before painting
        //size = Brush.GetComponent<SpriteRenderer>().bounds.size;
    }
    void Update()
    {
        if (!saving)
        {
            //Raycasting---------------------------------------------------------------------------------------------------------------- -
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
                            Paint(hit.point);
                            //first = hit.point;
                        }
                    }
                    
                }
            }
            if (Application.platform == RuntimePlatform.Android)
            {
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    for (var i = 0; i < Input.touchCount; i++)
                    {
                        ray = mainCam.ScreenPointToRay(Input.GetTouch(0).position);
                        if (Physics.Raycast(ray, out hit))
                        {
                            if (hit.collider.gameObject.CompareTag("PaintObject"))
                            {
                                //Instantiate(flare, hit.point, Quaternion.identity);
                                Paint(hit.point);
                            }
                        }
                    }
                }
                //if(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Moved)
                //{
                //    ray = mainCam.ScreenPointToRay(Input.GetTouch(0).position);
                //    if (Physics.Raycast(ray, out hit))
                //    {
                //        if (hit.collider.gameObject.CompareTag("PaintObject"))
                //        {
                //            //Instantiate(flare, hit.point, Quaternion.identity);
                //            secondFrame = hit.point;
                //            PaintBetweenFrames();
                //        }
                //    }
                //}
            }
            
        }
        //-------------------------end of Raycasting ---------------------------------------------------------
    }
    //private void LateUpdate()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        ray = mainCam.ScreenPointToRay(Input.mousePosition);
    //        if (Physics.Raycast(ray, out hit))
    //        {
    //            if (hit.collider.gameObject.CompareTag("PaintObject"))
    //            {
    //                second = hit.point;
    //                ColourBetween(first, second);
    //            }
    //        }
    //        print("late"+first+" "+second);
    //    }
    //}
    private void OnApplicationQuit()
    {
        baseMaterial.mainTexture = baseMaterialTexture; // reversing all changes to texture;
    }
    private void Paint(Vector3 rhit)
    {
        GameObject brushObject = Instantiate(Brush);
        BrushColor.a = 1;
        brushObject.GetComponent<SpriteRenderer>().color = BrushColor;
        brushObject.transform.parent = BrushContainer.transform;
        brushObject.transform.position = rhit;
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
    public void ColourBetween(Vector3 start_point, Vector3 end_point)
    {
        // Get the distance from start to finish
        float distance = Vector3.Distance(start_point, end_point);
        //Vector3 direction = (start_point - end_point).normalized;

        Vector3 cur_position;// = start_point; // Calculate how many times we should interpolate between start_point and end_point based on the amount of time that has passed since the last update
        float lerp_steps = 1 / distance;
        print(distance);
        for (float lerp = 0; lerp <= 1; lerp += lerp_steps)
        {
            cur_position = Vector3.Lerp(start_point, end_point, lerp);
            Paint(cur_position);
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
