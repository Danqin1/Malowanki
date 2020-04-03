using UnityEngine;

public class DrawWithInstantiate : MonoBehaviour
{
    public GameObject brush;
    public GameObject brushContainer;
    public GameObject cyl;
    public RenderTexture rt;
    public Material board;
    private RaycastHit hit;
    private Ray ray;
    private Vector3[] positions;
    private int position = 0;
    private int drawLayerValue = 9; // layer number
    private void Start()
    {
        positions = new Vector3[2];
        ClearBoard();
    }
    void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            position = (position + 1) % 2;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                positions[position] = hit.point;
                GameObject _brush = (GameObject)Instantiate(brush, hit.point, Quaternion.identity);
                _brush.transform.parent = brushContainer.transform;
                _brush.layer = drawLayerValue;
            }
            if (Vector3.Distance(positions[0], positions[1]) > 0.2 && positions[0].x != 0 && positions[1].x != 0)
            {
                SpawnBetween();
            }
        }
        else
        {
            if (Vector3.Distance(positions[0], positions[1]) > 0.2 && positions[0].x != 0 && positions[1].x != 0)
            {
                SpawnBetween();
            }
            positions[0] = positions[1] = Vector3.zero;
        }
        if (Input.touchCount > 0 && (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) || Input.GetMouseButtonUp(0))
        {
            Save();
        }
    }
    private void SpawnBetween()
    {
        GameObject cylinder = Instantiate(cyl, Vector3.zero, Quaternion.identity);
        cylinder.transform.parent = brushContainer.transform;
        cylinder.layer = drawLayerValue;
        UpdateCylinderPosition(cylinder, positions[0], positions[1]);
    }
    private void UpdateCylinderPosition(GameObject cylinder, Vector3 beginPoint, Vector3 endPoint)
    {
        Vector3 offset = endPoint - beginPoint;
        Vector3 position = beginPoint + (offset / 2.0f);

        cylinder.transform.position = position;
        cylinder.transform.LookAt(beginPoint);
        Vector3 localScale = cylinder.transform.localScale;
        localScale.z = (endPoint - beginPoint).magnitude;
        cylinder.transform.localScale = localScale;
    }
    private void Save()
    {
        Texture2D tex = new Texture2D(rt.width, rt.height, TextureFormat.RGB24, false);
        RenderTexture.active = rt;
        tex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        tex.Apply();
        board.mainTexture = tex;
        foreach (Transform child in brushContainer.transform)
        {
            Destroy(child.gameObject);
        }
        RenderTexture.active = null;
    }
    private void ClearBoard()
    {
        Texture2D tex = new Texture2D(board.mainTexture.width, board.mainTexture.height);
        Color32[] colors = tex.GetPixels32();
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = Color.white;
        }
        tex.SetPixels32(colors);
        tex.Apply();
        board.mainTexture = tex;
    }
}
