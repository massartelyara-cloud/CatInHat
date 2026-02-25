using UnityEngine;

public class DropZone2D : MonoBehaviour
{
    public string acceptedTag = "Fish";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(acceptedTag)) return;

        DraggableSprite item = other.GetComponent<DraggableSprite>();
        if (item == null) return;

        // Snap fish to the center of this drop zone
        other.transform.position = transform.position;
        item.enabled = false;
        Debug.Log("Fish placed correctly!");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag(acceptedTag)) return;

        DraggableSprite item = other.GetComponent<DraggableSprite>();
        if (item != null) item.ReturnToStart();
    }
}