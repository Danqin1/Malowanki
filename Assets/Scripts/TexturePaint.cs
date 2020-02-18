using UnityEngine;
using UnityEngine.Rendering;

public class TexturePaint : MonoBehaviour {

    // ======================================================================================================================
    // PARAMETERS -----------------------------------------------------------------------------------------------
    private  Texture          baseTexture;                  // used to deterimne the dimensions of the runtime texture
    public  Material         meshMaterial;                 // used to bind the runtime texture as the albedo of the mesh
    private  GameObject       meshGameobject;
    private Mesh meshToDraw;

    public  Shader           UVShader;                     // the shader usedto draw in the texture of the mesh
    public  Shader           ilsandMarkerShader;
    public  Shader           fixIlsandEdgesShader;                        
    public  static Vector3   mouseWorldPosition;

    // --------------------------------
  
    private Camera           mainC;
    private RenderTexture    markedIlsandes;
    private CommandBuffer    cb_markingIlsdands;
    private int              numberOfFrames;
    // ---------------------------------
    private PaintableTexture albedo;
    public GameObject flare;
    RaycastHit hit;
    Ray ray;

    // ======================================================================================================================
    // INITIALIZE -------------------------------------------------------------------

    void Start () {
        //finding object paintable in scene
        meshGameobject = GameObject.FindWithTag("PaintObject");
        meshToDraw = meshGameobject.GetComponent<MeshFilter>().mesh;
        baseTexture = new Texture2D(1920,1080,TextureFormat.ARGB32,false);
        // Main cam initialization ---------------------------------------------------
                           mainC = Camera.main;
        if (mainC == null) mainC = GetComponent<Camera>();
        if (mainC == null) mainC = FindObjectOfType<Camera>();
        // Texture and Mat initalization ---------------------------------------------
        markedIlsandes = new RenderTexture(baseTexture.width, baseTexture.height, 0, RenderTextureFormat.R8);
        albedo         = new PaintableTexture(Color.white, baseTexture.width, baseTexture.height, "_MainTex"
            ,UVShader, meshToDraw, fixIlsandEdgesShader,markedIlsandes);

        meshMaterial.SetTexture(albedo.id, albedo.runTimeTexture);
        meshMaterial.EnableKeyword("_METALLICGLOSSMAP");
        // Command buffer inialzation ------------------------------------------------
        cb_markingIlsdands = new CommandBuffer
        {
            name = "markingIlsnads"
        };
        cb_markingIlsdands.SetRenderTarget(markedIlsandes);
        Material mIlsandMarker  = new Material(ilsandMarkerShader);
        cb_markingIlsdands.DrawMesh(meshToDraw, Matrix4x4.identity, mIlsandMarker);
        mainC.AddCommandBuffer(CameraEvent.AfterDepthTexture, cb_markingIlsdands);
        albedo.SetActiveTexture(mainC);
    }
    private void Update()
    {
        if (numberOfFrames > 2) mainC.RemoveCommandBuffer(CameraEvent.AfterDepthTexture, cb_markingIlsdands);
        numberOfFrames++;
        albedo.UpdateShaderParameters(meshGameobject.transform.localToWorldMatrix);
        if (Application.platform == RuntimePlatform.WebGLPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetMouseButton(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.CompareTag("PaintObject"))
                    {
                        Instantiate(flare, hit.point, Quaternion.identity);
                        Shader.SetGlobalVector("_Mouse", new Vector4(hit.point.x, hit.point.y, hit.point.z, 1));
                    }
                }
            }
            else
            {
                ResetMousePos();
            }
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount > 0)
            {
                for (var i = 0; i < Input.touchCount; i++)
                {
                    ray = mainC.ScreenPointToRay(Input.GetTouch(0).position);
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.gameObject.CompareTag("PaintObject"))
                        {
                            Instantiate(flare, hit.point, Quaternion.identity);
                            Shader.SetGlobalVector("_Mouse", new Vector4(hit.point.x, hit.point.y, hit.point.z, 1));
                        }
                    }

                }

            }
            else
            {
                ResetMousePos();
            }
        }
    }
    private void ResetMousePos()
    {
        Shader.SetGlobalVector("_Mouse", new Vector4(0, 0, 0, 0));
    }
}