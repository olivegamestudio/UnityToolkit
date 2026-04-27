using UnityEngine;

public sealed class SpotlightSoftSway : MonoBehaviour
{
    [SerializeField] private float maxAngle = 8f;
    [SerializeField] private float frequency = 0.5f;

    private Quaternion baseRotation;
    private float noiseSeed;

    private void Awake()
    {
        baseRotation = transform.localRotation;
        noiseSeed = Random.Range(0f, 1000f);
    }

    private void Update()
    {
        float sample = Mathf.PerlinNoise(noiseSeed + Time.time * frequency, 0f);
        float offset = (sample * 2f - 1f) * maxAngle;
        transform.localRotation = baseRotation * Quaternion.Euler(0f, 0f, offset);
    }
}