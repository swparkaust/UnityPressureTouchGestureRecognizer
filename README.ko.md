# UnityPressureTouchGestureRecognizer

가속도계를 이용한 Unity 용 터치 벨로시티 감지. iOS용 GarageBand에서 영감을 얻음.

![demo unitypressuretouchgesturerecognizer](https://github.com/swparkaust/UnityPressureTouchGestureRecognizer/raw/master/img/demo-unitypressuretouchgesturerecognizer.gif)

*Read this in other languages: [English](README.md), [한국어](README.ko.md).*

### 설치

Unity 이외의 종속성은 필요하지 않습니다. 무슨 일이 생기면 알려주세요!

1. 빈 GameObject를 만들고 이름을 PressureTouchGestureRecognizer로 지정합니다.
2. PressureTouchGestureRecognizer.cs 스크립트를 다운로드하여 GameObject에 추가합니다.
3. 트리거 되면 "pressure"가 0.0f에서 2.0f 사이의 플로트로 설정됩니다.
4. 선택적으로 인식에 필요한 최소 및 최대 터치 감도를 설정할 수 있습니다.

### 용법
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
