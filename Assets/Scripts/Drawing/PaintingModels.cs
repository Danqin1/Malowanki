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
        if(Input.touchCount > 1)
        {
            float enterDistance = 0;
            float finishDistance = 0;
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                enterDistance = Mathf.Abs(Vector3.Distance(Input.GetTouch(0).deltaPosition, Input.GetTouch(1).deltaPosition));
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                finishDistance = Mathf.Abs(Vector3.Distance(Input.GetTouch(0).deltaPosition, Input.GetTouch(1).deltaPosition));
            }
            if (finishDistance > enterDistance) print("przyblizanie");
            else if (finishDistance < enterDistance) print("oddalanie");
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
