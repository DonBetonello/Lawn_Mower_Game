using UnityEngine;

public class DescriptionPositioner : MonoBehaviour
{
   
    [SerializeField] private RectTransform description;
    [SerializeField] private RectTransform canvas;

    [SerializeField] private Vector2 offset = new Vector2(10f, 10f);

    public void Show(RectTransform target)
    {
       
        description.localScale = new Vector2(1,1);

        Canvas.ForceUpdateCanvases();

        Vector3[] targetCorners = new Vector3[4];
        target.GetWorldCorners(targetCorners);

        Vector3[] descriptionCorners = new Vector3[4];

        // Right
        Vector3 rightPos = targetCorners[2] + new Vector3(offset.x, 0);
        if (TryPosition(rightPos, descriptionCorners))
            return;

        // Left
        Vector3 leftPos = targetCorners[0] - new Vector3(offset.x, 0);
        if (TryPosition(leftPos, descriptionCorners))
            return;

        // Top
        Vector3 topPos = targetCorners[1] + new Vector3(0, offset.y);
        if (TryPosition(topPos, descriptionCorners))
            return;

        // Bottom
        Vector3 bottomPos = targetCorners[0] - new Vector3(0, offset.y);
        if (TryPosition(bottomPos, descriptionCorners))
            return;

        // fallback 
        description.position = target.position;
    }

    private bool TryPosition(Vector3 worldPos, Vector3[] tooltipCorners)
    {
        description.position = worldPos;
        Canvas.ForceUpdateCanvases();

        description.GetWorldCorners(tooltipCorners);

        if (IsInsideScreen(tooltipCorners))
            return true;

        return false;
    }

    private bool IsInsideScreen(Vector3[] corners)
    {
        float width = Screen.width;
        float height = Screen.height;

        foreach (var corner in corners)
        {
            if (corner.x < 0 || corner.x > width ||
                corner.y < 0 || corner.y > height)
                return false;
        }

        return true;
    }

}
