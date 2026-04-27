# Unity Toolkit

Shared Unity runtime helpers. Current contents:

- `CameraShake` for camera shake behaviour.
- `CameraShakeZone` for trigger-based shake activation with radius, layer filtering, optional tag filtering, and trauma application.
- `CameraTrackWithGameObject` for following a target transform.
- `CameraTrackWithRotationGameObject` for following a target transform and rotation.
- `OrthographicCameraSizeTween` for curve-driven orthographic size tweening.
- `OrthographicCameraZoom` for direct orthographic zoom playback between start and end sizes.
- `SoftSway` for lightweight sway motion.

To include it in the Unity Editor:

1. Open `Window > Package Manager`.
2. Click the `+` button.
3. Choose `Add package from git URL...`.
4. Paste:

```text
https://github.com/olivegamestudio/UnityToolkit.git?path=/upm
```

Readme: https://github.com/olivegamestudio/UnityToolkit
