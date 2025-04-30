using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGuide : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public CheckPointManager savePointManager;
    public float scrollSpeed = -0.5f;

    private Material lineMaterial;
    private float offset;

    void Start()
    {
        Transform current = savePointManager.GetCurrentSavePoint();
        Transform next = savePointManager.GetNextSavePoint();

        lineMaterial = lineRenderer.material;


        if (next != null)
        {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, current.position + Vector3.up); // …‘Œ¢Ãß∏ﬂ“ªµ„
            lineRenderer.SetPosition(1, next.position + Vector3.up);
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    void Update()
    {
        offset += Time.deltaTime * scrollSpeed;
        lineMaterial.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
