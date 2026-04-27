using UnityEngine;

public sealed class CameraShake : MonoBehaviour
{
    [SerializeField] private float maxOffset = 0.5f;
    [SerializeField] private float maxAngle = 4f;
    [SerializeField] private float frequency = 25f;
    [SerializeField] private float traumaDecay = 1.5f;

    private float trauma;
    private Vector3 basePosition;
    private Quaternion baseRotation;
    private float seedX;
    private float seedY;
    private float seedAngle;

    private void Awake()
    {
        basePosition = transform.localPosition;
        baseRotation = transform.localRotation;
        seedX = Random.Range(0f, 1000f);
        seedY = Random.Range(0f, 1000f);
        seedAngle = Random.Range(0f, 1000f);
    }

    public void AddTrauma(float amount)
    {
        trauma = Mathf.Clamp01(trauma + amount);
    }

    private void LateUpdate()
    {
        if (trauma <= 0f)
        {
            transform.localPosition = basePosition;
            transform.localRotation = baseRotation;
            return;
        }

        float shake = trauma * trauma;
        float time = Time.time * frequency;

        float offsetX = (Mathf.PerlinNoise(seedX, time) * 2f - 1f) * maxOffset * shake;
        float offsetY = (Mathf.PerlinNoise(seedY, time) * 2f - 1f) * maxOffset * shake;
        float angle = (Mathf.PerlinNoise(seedAngle, time) * 2f - 1f) * maxAngle * shake;

        transform.localPosition = basePosition + new Vector3(offsetX, offsetY, 0f);
        transform.localRotation = baseRotation * Quaternion.Euler(0f, 0f, angle);

        trauma = Mathf.Max(0f, trauma - traumaDecay * Time.deltaTime);
    }
}