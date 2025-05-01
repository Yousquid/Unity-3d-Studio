using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGuide : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public CheckPointManager savePointManager;
    public float scrollSpeed = 0.5f;
    public float heightOffset = 1f; // »√œﬂÃı…‘Œ¢¿Îµÿ

    private Material lineMaterial;
    private float offset;

    void Start()
    {
        Transform current = savePointManager.GetCurrentSavePoint();
        Transform next = savePointManager.GetNextSavePoint();

        lineMaterial = lineRenderer.material;


    }

    void Update()
    {
        offset += Time.deltaTime * scrollSpeed;
        lineMaterial.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        Transform current = savePointManager.GetCurrentSavePoint();
        Transform next = savePointManager.GetNextSavePoint();

        if (current != null && next != null)
        {
            lineRenderer.enabled = true;
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(1, current.position + Vector3.up * heightOffset);
            lineRenderer.SetPosition(0, next.position + Vector3.up * heightOffset);
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }
}
