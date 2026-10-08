using OpenCover.Framework.Model;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Keeps a GameObject on screen
/// Only works for an orthographic Main Camera
/// </summary>

public class BoundsCheck : MonoBehaviour
{

    [Header("Dynamic")]
    public float camWidth;
    public float camHeight;

    private void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }
    void LateUpdate()
    {
        Vector3 pos = transform.position;

        if (pos.x > camWidth)
        {
            pos.x = camWidth;
        }
        if (pos.x < -camWidth)
        {
            pos.x = -camWidth;
        }

        if (pos.y > camHeight)
        {
            pos.y = camHeight;
        }
        if (pos.y < -camHeight)
        {
            pos.y = -camHeight;
        }

        transform.position = pos;
    }
}
