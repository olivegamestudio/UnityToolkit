using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Camera))]
public sealed class OrthographicCameraZoom : MonoBehaviour
{
    [SerializeField, Min(0.0001f)] private float startSize = 5f;
    [SerializeField, Min(0.0001f)] private float endSize = 3f;
    [SerializeField, Min(0f)] private float duration = 1f;
    [SerializeField] private bool playOnEnable = true;
    [SerializeField] private bool disableWhenComplete = true;
    [SerializeField] private bool useUnscaledTime;

    private Camera _camera;
    private float _elapsed;
    private bool _isPlaying;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void OnEnable()
    {
        if (playOnEnable)
        {
            Play();
        }
    }

    private void Update()
    {
        if (!_isPlaying)
        {
            return;
        }

        float deltaTime = useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
        _elapsed += deltaTime;

        float progress = duration <= 0f
            ? 1f
            : Mathf.Clamp01(_elapsed / duration);

        float easedProgress = Mathf.SmoothStep(0f, 1f, progress);

        _camera.orthographicSize = Mathf.Lerp(startSize, endSize, easedProgress);

        if (progress < 1f)
        {
            return;
        }

        _camera.orthographicSize = endSize;
        _isPlaying = false;

        if (disableWhenComplete)
        {
            enabled = false;
        }
    }

    public void Play()
    {
        if (_camera == null)
        {
            _camera = GetComponent<Camera>();
        }

        _elapsed = 0f;
        _isPlaying = true;
        enabled = true;
        _camera.orthographicSize = startSize;
    }

    public void Stop()
    {
        _isPlaying = false;
    }

    public void Complete()
    {
        if (_camera == null)
        {
            _camera = GetComponent<Camera>();
        }

        _elapsed = duration;
        _camera.orthographicSize = endSize;
        _isPlaying = false;

        if (disableWhenComplete)
        {
            enabled = false;
        }
    }
}
