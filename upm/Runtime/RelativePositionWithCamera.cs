using System;
using UnityEngine;

[DisallowMultipleComponent]
public class RelativePositionWithCamera : MonoBehaviour
{
    public Camera Camera;

    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position;

        if (Camera == null)
        {
            throw new InvalidOperationException("There is no camera attached.");
        }
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(
            Camera.transform.position.x + _offset.x,
            Camera.transform.position.y + _offset.y,
            transform.position.z);
    }
}
