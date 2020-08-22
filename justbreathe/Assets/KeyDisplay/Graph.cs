#pragma warning disable 0649

using UnityEngine;

public class Graph : MonoBehaviour
{
    public int NumPoints = 100;
    public float DownPosition = -20f;
    public float UpPosition = 20f;

    private bool[] pointBools;
    private UILineRenderer lineRenderer;

    protected void Awake()
    {
        lineRenderer = GetComponent<UILineRenderer>();
    }

    private void Update()
    {
        lineRenderer.pointPositions = GetPointPositions();
        lineRenderer.ForceRedraw();
    }

    public void SetPoints(bool[] positions)
    {
        pointBools = positions;
    }

    public Vector2[] GetPointPositions()
    {
        if (pointBools == null) return null;
        if (pointBools.Length < 2) return null;

        Vector2[] pointPosition = new Vector2[NumPoints];
        for (int i = 0; i < Mathf.Min(NumPoints, pointBools.Length); i++)
        {
            pointPosition[i] = new Vector2(
                (float)i / NumPoints,
                pointBools[i] ? 0f : 1f);
        }

        return pointPosition;
    }
}
