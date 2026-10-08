using OpenCover.Framework.Model;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Keeps a GameObject on screen
/// Only works for an orthographic Main Camera
/// </summary>

public class BoundsCheck : MonoBehaviour
{
    public enum eType { center, inset, outset };

    [Header("Inscribed")]
    public eType boundsType = eType.center;
    public float radius = 1f;
    public bool keepOnScreen = true;

    [Header("Dynamic")]
    public bool isOnScreen = true;
    public float camWidth;
    public float camHeight;

    private void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }
    void LateUpdate()
    {
        float checkRadius = 0;
        if (boundsType == eType.inset) checkRadius = -radius;
        if (boundsType == eType.outset) checkRadius = radius;

        Vector3 pos = transform.position;
        isOnScreen = true;

        if (pos.x > camWidth + checkRadius)
        {
            pos.x = camWidth + checkRadius;
            isOnScreen = false;
        }
        if (pos.x < -camWidth - checkRadius)
        {
            pos.x = -camWidth - checkRadius;
            isOnScreen = false;
        }

        if (pos.y > camHeight + checkRadius)
        {
            pos.y = camHeight + checkRadius;
            isOnScreen = false;
        }
        if (pos.y < -camHeight - checkRadius)
        {
            pos.y = -camHeight - checkRadius;
            isOnScreen = false;
        }
        if (keepOnScreen && !isOnScreen)
        {
            transform.position = pos;
            isOnScreen = true;
        }
    }
}
