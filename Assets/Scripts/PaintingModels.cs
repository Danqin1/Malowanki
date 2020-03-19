using UnityEngine;

public class PaintingModels : MonoBehaviour
{
    RaycastHit2D hit;
    public PaintingModelUI paintingUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Hit(Input.GetTouch(0).position);
        }
        if (Input.GetMouseButton(0))
        {
            Hit(Input.mousePosition);
        }
    }
    private void Hit(Vector3 pos)
    {
        Vector3 ray = Camera.main.ScreenToWorldPoint(pos);
        RaycastHit2D hitInfo = Physics2D.Raycast(ray, Vector2.zero);
        if (hitInfo && hitInfo.transform.gameObject.CompareTag("Paintable"))
        {
            hitInfo.transform.gameObject.GetComponent<SpriteRenderer>().color = paintingUI.BrushColor;
        }
    }
}
