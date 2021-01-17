# UnityPressureTouchGestureRecognizer

Touch velocity detection for Unity using an accelerometer. Inspired by GarageBand for iOS.

![demo unitypressuretouchgesturerecognizer](https://github.com/swparkaust/UnityPressureTouchGestureRecognizer/raw/master/img/demo-unitypressuretouchgesturerecognizer.gif)

*Read this in other languages: [English](README.md), [한국어](README.ko.md).*

### Installation

No dependencies other than Unity are required. Let me know if anything happens!

1. Create an empty GameObject and name it PressureTouchGestureRecognizer.
2. Download the PressureTouchGestureRecognizer.cs script and add it to the GameObject.
3. When triggered, "pressure" is set to a float between 0.0f and 2.0f.
4. Optionally, you can set the minimum and maximum touch sensitivity required for recognition.

### Usage
```C#
	private PressureTouchGestureRecognizer recognizer;

	void Start()
	{
		recognizer = GetComponent<PressureTouchGestureRecognizer>();
		recognizer.SetAction(HandlePressureTouch);
	}

	void HandlePressureTouch(float pressure)
	{
		Debug.Log("pressure = " + pressure);
	}
```
