using UnityEngine;

namespace OliveGame.UnityKit.Camera;

[DisallowMultipleComponent]
[RequireComponent(typeof(Camera))]
public sealed class OrthographicCameraSizeTween : MonoBehaviour
{
    [SerializeField, Min(0.0001f)] private float duration = 1f;
    [SerializeField] private float startSize = 5f;
    [SerializeField] private float endSize = 3f;
    [SerializeField] private bool playOnEnable = true;
    [SerializeField] private bool disableWhenComplete = true;
    [SerializeField] private AnimationCurve easing = AnimationCurve.Linear(0f, 0f, 1f, 1f);

    private Camera _camera;
    private float _elapsed;
    private bool _isPlaying;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void OnEnable()
    {
        if (!playOnEnable)
        {
            return;
        }

        Play();
    }

    private void Update()
    {
        if (!_isPlaying)
        {
            return;
        }

        _elapsed += Time.deltaTime;

        float progress = Mathf.Clamp01(_elapsed / duration);
        float easedProgress = easing.Evaluate(progress);

        _camera.orthographicSize = Mathf.LerpUnclamped(startSize, endSize, easedProgress);

        if (progress < 1f)
        {
            return;
        }

        _isPlaying = false;

        if (disableWhenComplete)
        {
            enabled = false;
        }
    }

    public void Play()
    {
        _elapsed = 0f;
        _isPlaying = true;
        enabled = true;

        if (_camera == null)
        {
            _camera = GetComponent<Camera>();
        }

        _camera.orthographicSize = startSize;
    }
}
