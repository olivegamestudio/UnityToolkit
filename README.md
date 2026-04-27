# Unity Toolkit

Shared Unity runtime components and helpers for general Unity projects.

## Contents

Current runtime scripts in the package:

- `CameraShake`
- `CameraShakeZone` with radius-based trigger filtering, layer masks, optional tag filtering, and trauma application.
- `CameraTrackWithGameObject`
- `CameraTrackWithRotationGameObject`
- `OrthographicCameraSizeTween`
- `OrthographicCameraZoom`
- `SoftSway`

## Install into Unity

In the Unity Editor:

1. Open `Window > Package Manager`.
2. Click the `+` button.
3. Choose `Add package from git URL...`.
4. Paste:

```text
https://github.com/olivegamestudio/UnityToolkit.git?path=/upm
```

## Package

- Package id: `com.olivegamestudio.unitytoolkit`
- Version: `1.0.5`
- Unity version: `2021.3`

## Structure

- `upm/Runtime` contains the runtime scripts.
- `upm/Tests` contains the Unity test package files.

## License

MIT
