using UnityEngine;
using UnityEngine.UI;

public class HotColdMeter : MonoBehaviour
{
    public Image meterImage;        // The UI image that changes color
    public float maxDistance = 10f; // Distance at which it's "freezing"

    private DraggableSprite activeDraggable;
    private Transform targetZone; // remembers dropzone it needs to be in 

    void Update()
    {
        // Find what's currently being dragged
        DraggableSprite[] allItems = FindObjectsOfType<DraggableSprite>();
        activeDraggable = null;

        foreach (DraggableSprite item in allItems)
        {
            if (item.IsDragging)
            {
                activeDraggable = item;
                break; // are you being dragged now ??
            }
        }

        if (activeDraggable == null)
        {
            
            meterImage.color = Color.clear;
            return; // meter goes away if nothing is being dragged
        }

        // Find the matching drop zone for this item
        DropZone2D[] allZones = FindObjectsOfType<DropZone2D>();
        targetZone = null;

        foreach (DropZone2D zone in allZones)
        {
            if (zone.acceptedTag == activeDraggable.tag)
            {
                targetZone = zone.transform;
                break;
            }
        }

        if (targetZone == null) return;

        // Calculate distance and map to color
        float dist = Vector2.Distance(activeDraggable.transform.position, targetZone.position);
        float t = Mathf.Clamp01(1f - (dist / maxDistance));

        // Blue = cold, Red = hot
        meterImage.color = Color.Lerp(Color.blue, Color.red, t);
    }
}
