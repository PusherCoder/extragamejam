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

        float curAngle = 0;
        float angle = 0;
        int numVertexGroups = 0;
        for (int i = 0; i < pointPositions.Length; i++)
        {
            if (i < pointPositions.Length - 1)
                angle = GetAngle(pointPositions[i], pointPositions[i + 1]);

            do 
            {
                numVertexGroups++;
                DrawVerticesForPoint(pointPositions[i], vh, curAngle);
                curAngle = Mathf.MoveTowards(curAngle, angle, 5f);
            } while (Mathf.Abs(curAngle - angle) > 3f);
        }

        for (int i = 0; i < numVertexGroups - 1; i++)
        {
            int index = i * 2;
            vh.AddTriangle(index + 0, index + 1, index + 3);
            vh.AddTriangle(index + 3, index + 2, index + 0);
        }
    }

    private void DrawVerticesForPoint(Vector2 point, VertexHelper vh, float angle)
    {
        UIVertex vertex = UIVertex.simpleVert;
        vertex.color = color;

        vertex.position = GetPosition(point.x, point.y, 0, -Thickness / 2f, angle);
        vh.AddVert(vertex);

        vertex.position = GetPosition(point.x, point.y, 0, Thickness / 2f, angle);
        vh.AddVert(vertex);
    }

    private float GetAngle(Vector2 me, Vector2 next)
    {
        return (float)(Mathf.Atan2(next.y - me.y, next.x - me.x) * (180f / Mathf.PI));
    }

    private Vector3 GetPosition(float widthOffset, float heightOffset, float xOffset = 0, float yOffset = 0, float angle = 0)
    {
        Vector3 position = Quaternion.Euler(0, 0, angle) * new Vector3(xOffset, yOffset);
        position += new Vector3(
            (rectTransform.rect.width * widthOffset) - (rectTransform.rect.width / 2f),
            (rectTransform.rect.height * heightOffset) - (rectTransform.rect.height / 2f));

        return position;
    }
}
