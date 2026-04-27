using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(CircleCollider2D))]
[DisallowMultipleComponent]
public class CameraShakeZone : MonoBehaviour
{
    [SerializeField, Min(0f)] private float Radius = 3f;
    [SerializeField] private CameraShake cameraShake;
    [SerializeField, Min(0f)] private float trauma;
    [SerializeField] private LayerMask triggerLayers = ~0;
    [SerializeField] private string requiredTag;
    
    CircleCollider2D _collider;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!IsValidTrigger(other))
        {
            return;
        }

        cameraShake?.AddTrauma(trauma);
    }

    bool IsValidTrigger(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & triggerLayers) == 0)
        {
            return false;
        }

        if (!string.IsNullOrWhiteSpace(requiredTag) && !other.CompareTag(requiredTag))
        {
            return false;
        }

        return true;
    }

    void Awake()
    {
        _collider = GetComponent<CircleCollider2D>();
        ApplyColliderSettings();
    }
    
    void OnValidate()
    {
        _collider = GetComponent<CircleCollider2D>();
        ApplyColliderSettings();
    }
    
    void ApplyColliderSettings()
    {
        if (_collider == null)
        {
            return;
        }

        _collider.radius = Radius;
        _collider.isTrigger = true;
    }
    
    void OnDrawGizmos() => DrawGizmo(Color.white);
    
    void OnDrawGizmosSelected() => DrawGizmo(Color.red);

    void DrawGizmo(Color color)
    {
        Gizmos.color = color;
        Gizmos.DrawWireSphere(transform.position, Radius);
        
#if UNITY_EDITOR
        Handles.Label(transform.position + new Vector3(1, 0, 0), gameObject.name);
#endif
    }
}
