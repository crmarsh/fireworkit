using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FollowMouse : MonoBehaviour 
{
    /// <summary>
    /// Function definition for a button click event.
    /// </summary>
    [Serializable]
    public class ClickedEvent : UnityEvent<Vector3> { }

    [SerializeField] private float _distance = 10.0f;
    [SerializeField] private float _scrollScale = 0.1f;
    [SerializeField] ClickedEvent _onClick = null;

    void Update()
    {
        if (!Camera.main)
        {
            return;
        }

        _distance += Input.mouseScrollDelta.y * _scrollScale;
        _distance = Mathf.Clamp(_distance, Camera.main.nearClipPlane, Camera.main.farClipPlane);

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);
        var p = ray.GetPoint(_distance);
        transform.position = p;

        if (Input.GetMouseButtonDown(0) && _onClick != null)
        {
            _onClick.Invoke(p);
        }
    }
}
