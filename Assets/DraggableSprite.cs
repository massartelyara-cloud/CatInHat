using UnityEngine;

public class DraggableSprite : MonoBehaviour
{
    
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
        // Calculate offset so the sprite doesn't "jump" to mouse center
        offset = transform.position - GetMouseWorldPos();
        
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + offset;
    }

    

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(mainCam.transform.position.z); // distance from cam
        return mainCam.ScreenToWorldPoint(mousePos);
    }

    public void ReturnToStart()
    {
        transform.position = startPosition;
    }
}
