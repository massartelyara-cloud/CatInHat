using UnityEngine;

public class DraggableSprite : MonoBehaviour
{
    public bool IsDragging { get; private set; }

    private Vector3 offset;
    private Camera mainCam;
    private Vector3 startPosition;

    void Start()
    {
        mainCam = Camera.main;
        startPosition = transform.position;
    }

    void OnMouseDown()
    {
        offset = transform.position - GetMouseWorldPos();
        IsDragging = true;
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
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(mainCam.transform.position.z);
        return mainCam.ScreenToWorldPoint(mousePos);
    }

    public void ReturnToStart()
    {
        transform.position = startPosition;
    }
}