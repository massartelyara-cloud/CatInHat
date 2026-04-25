using UnityEngine;

public class DraggableSprite : MonoBehaviour
{
    public bool IsDragging { get; private set; }
// memory for dragable objects 
    private Vector3 offset;
    private Camera mainCam;
    private Vector3 startPosition;

    void Start()
    {
        // saves object starting position + finds main cam
        mainCam = Camera.main;
        startPosition = transform.position;
    }

    void OnMouseDown()
    {
        // moves object to follow mmouse 
        offset = transform.position - GetMouseWorldPos();
        IsDragging = true; // the hot & cold meter lets it know when its right
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + offset;
    }

    void OnMouseUp()
    {
        IsDragging = false;
    }

    private Vector3 GetMouseWorldPos()
    {
        // mouse pixels to game pix
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(mainCam.transform.position.z);
        return mainCam.ScreenToWorldPoint(mousePos);
    }

    public void ReturnToStart()
    {
        transform.position = startPosition;
    }
}