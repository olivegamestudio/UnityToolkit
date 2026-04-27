using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(CircleCollider2D))]
public class CameraShakeZone : MonoBehaviour
{
    [SerializeField] private float Distance = 3f;
    [SerializeField] private CameraShake cameraShake;
    [SerializeField] private float trauma;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("QuestZoneBehaviourBase.OnTriggerEnter2D " + other.name);
        
        QuestPlayer questPlayer = other.GetComponentInParent<QuestPlayer>();
        if (questPlayer != null)
        {
            cameraShake.AddTrauma(trauma);
        }
    }

    void OnValidate()
    {
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        collider.radius = Distance;
        collider.isTrigger = true;
    }
    
    void OnDrawGizmos() => DrawGizmo(Color.white);
    
    void OnDrawGizmosSelected() => DrawGizmo(Color.red);

    void DrawGizmo(Color color)
    {
        Gizmos.color = color;
        Gizmos.DrawWireSphere(transform.position, Distance);
        
#if UNITY_EDITOR
        Handles.Label(transform.position + new Vector3(1, 0, 0), gameObject.name);
#endif
    }
}
