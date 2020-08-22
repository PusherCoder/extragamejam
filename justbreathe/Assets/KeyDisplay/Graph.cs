using UnityEngine;

public class Graph : MonoBehaviour
{
    public int NumPoints = 100;
    public float DownPosition = -20f;
    public float UpPosition = 20f;

    [SerializeField] private RectTransform pointPrefab;

    private RectTransform myRectTransform;
    private RectTransform[] points;

    protected void Awake()
    {
        myRectTransform = GetComponent<RectTransform>();

        points = new RectTransform[NumPoints];
        for (int i = 0; i < NumPoints; i++)
        {
            points[i] = Instantiate(pointPrefab, transform);
            points[i].anchoredPosition = new Vector2(i * (myRectTransform.sizeDelta.x / NumPoints), DownPosition);
        }
    }

    public void SetPoints(bool[] positions)
    {
        int numIterations = Mathf.Min(positions.Length, NumPoints);
        for (int i = 0; i < numIterations; i++)
            points[i].anchoredPosition = new Vector2(points[i].anchoredPosition.x, positions[i] ? DownPosition : UpPosition);

    }
}
