using UnityEngine;

public class DescriptionPositioner : MonoBehaviour
{
    [SerializeField] private RectTransform description;
    [SerializeField] private RectTransform canvas;

    [SerializeField] private Vector2 offset = new Vector2(10f, 10f);

    private Vector3[] targetCorners = new Vector3[4];
    private Vector3[] descriptionCorners = new Vector3[4];

    public void Show(RectTransform target)
    {
        description.localScale = Vector3.one;

        Canvas.ForceUpdateCanvases();

        target.GetWorldCorners(targetCorners);

        // Right
        Vector2 rightPosition = WorldToCanvasPosition(targetCorners[2]);
        rightPosition.x += offset.x;

        if (TryPosition(rightPosition))
            return;

        // Left
        Vector2 leftPosition = WorldToCanvasPosition(targetCorners[0]);
        leftPosition.x -= offset.x;

        if (TryPosition(leftPosition))
            return;

        // Top
        Vector2 topPosition = WorldToCanvasPosition(targetCorners[1]);
        topPosition.y += offset.y;

        if (TryPosition(topPosition))
            return;

        // Bottom
        Vector2 bottomPosition = WorldToCanvasPosition(targetCorners[0]);
        bottomPosition.y -= offset.y;

        if (TryPosition(bottomPosition))
            return;

        // Fallback
        description.position = target.position;
    }

    private Vector2 WorldToCanvasPosition(Vector3 worldPosition)
    {
        Vector2 screenPosition = RectTransformUtility.WorldToScreenPoint(
            null,
            worldPosition
        );

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas,
            screenPosition,
            null,
            out Vector2 canvasPosition
        );

        return canvasPosition;
    }

    private bool TryPosition(Vector2 canvasPosition)
    {
        description.anchoredPosition = canvasPosition;

        Canvas.ForceUpdateCanvases();

        description.GetWorldCorners(descriptionCorners);

        return IsInsideScreen(descriptionCorners);
    }

    private bool IsInsideScreen(Vector3[] corners)
    {
        foreach (Vector3 corner in corners)
        {
            Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(
                null,
                corner
            );

            if (screenPoint.x < 0 || screenPoint.x > Screen.width ||
                screenPoint.y < 0 || screenPoint.y > Screen.height)
            {
                return false;
            }
        }

        return true;
    }
}