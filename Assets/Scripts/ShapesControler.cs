using UnityEngine;

public class ShapesControler : MonoBehaviour
{
    Vector3 initPosition;
    Vector3 ray;
    RaycastHit2D hit;
    GameObject clickedObj;
    GameObject[] sprites;
    Vector3 basePosition;
    int win;
    private void Start()
    {
        win = 0;
        sprites = FindObjectsOfType<GameObject>();
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Hit(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {

            ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(ray, Vector2.zero);
            if (hit && hit.transform.gameObject.CompareTag("Shape"))
            {
                if (!clickedObj)
                {
                    initPosition = hit.transform.gameObject.transform.position;
                    foreach (var item in sprites)
                    {
                        if(item.name == hit.transform.gameObject.name+"Base")
                        {
                            basePosition = item.transform.position;
                        }
                    }
                }
                clickedObj = hit.transform.gameObject;
                
            }
        }
        if (clickedObj)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            clickedObj.transform.position = pos;
        }
        if(Input.GetMouseButtonUp(0))
        {
            if(clickedObj)
            {
                if (Mathf.Abs(clickedObj.transform.position.x - basePosition.x) <= 0.5f && Mathf.Abs(clickedObj.transform.position.y - basePosition.y) <= 0.5f)
                {
                    clickedObj.transform.position = basePosition;
                    win++;
                    clickedObj = null;
                }
                else
                {
                    clickedObj.transform.position = initPosition;
                    clickedObj = null;
                }
            } 
        }
    }
        private void Hit(Vector3 pos)
        {
            ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(ray, Vector2.zero);
            if (hit && hit.transform.gameObject.CompareTag("Shape"))
            {
                print("clicked" + hit.transform.gameObject.name);
                if (Input.touchCount > 0)
                {
                    switch (Input.GetTouch(0).phase)
                    {
                        case TouchPhase.Began:
                            initPosition = hit.transform.gameObject.transform.position;
                            break;
                        case TouchPhase.Moved:
                            hit.transform.gameObject.transform.position = Input.mousePosition;
                            break;
                        case TouchPhase.Ended:
                            hit.transform.gameObject.transform.position = initPosition;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    } 
