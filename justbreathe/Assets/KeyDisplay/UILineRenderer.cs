using UnityEngine;
using UnityEngine.UI;

public class UILineRenderer : Graphic
{
    public float Thickness = 6f;
    public Vector2[] pointPositions;

    public void ForceRedraw()
    {
        SetVerticesDirty();
    }

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        if (pointPositions == null) return;
        if (pointPositions.Length < 2) return;

        vh.Clear();

        UIVertex vertex = UIVertex.simpleVert;
        vertex.color = color;

        for (int i = 0; i < pointPositions.Length; i++)
            DrawVerticesForPoint(pointPositions[i], vh);

        for (int i = 0; i < pointPositions.Length - 1; i++)
        {
            int index = i * 2;
            vh.AddTriangle(index + 0, index + 1, index + 3);
            vh.AddTriangle(index + 3, index + 2, index + 0);
        }
    }

    private void DrawVerticesForPoint(Vector2 point, VertexHelper vh)
    {
        UIVertex vertex = UIVertex.simpleVert;
        vertex.color = color;

        vertex.position = GetPosition(point.x, point.y, 0, -Thickness / 2f);
        vh.AddVert(vertex);

        vertex.position = GetPosition(point.x, point.y, 0, Thickness / 2f);
        vh.AddVert(vertex);
    }

    private Vector3 GetPosition(float widthOffset, float heightOffset, float xOffset = 0, float yOffset = 0)
    {
        return new Vector3(
            (rectTransform.rect.width * widthOffset) - (rectTransform.rect.width / 2f) + xOffset,
            (rectTransform.rect.height * heightOffset) - (rectTransform.rect.height / 2f) + yOffset);
    }
}
