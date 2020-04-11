using System;
using UnityEngine;

public partial class Constants
{
    public const float PressureNone = 0.0f;
    public const float PressureLight = 0.1f;
    public const float PressureMedium = 0.3f;
    public const float PressureHard = 0.8f;
    public const float PressureInfinite = 2.0f;
    public const int KNumberOfPressureSamples = 3;
}
public class PressureTouchGestureRecognizer : MonoBehaviour
{
    private System.Action<float> action;
    private float pressure;
    private float minimumPressureRequired;
    private float maximumPressureRequired;
    private float[] pressureValues = new float[30];
    private uint currentPressureValueIndex;
    private uint setNextPressureValue;

    public enum State
    {
        Possible,
        Began,
        Changed,
        Ended,
        Cancelled,
        Failed,
        Recognized = Ended
    }

    public State state = State.Possible;

    public float Pressure
    {
        get
        {
            return pressure;
        }
    }

    public float MinimumPressureRequired
    {
        get
        {
            return minimumPressureRequired;
        }
        set
        {
            minimumPressureRequired = value;
        }
    }

    public float MaximumPressureRequired
    {
        get
        {
            return maximumPressureRequired;
        }
        set
        {
            maximumPressureRequired = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.Setup();
    }

    // Update is called once per frame
    void Update()
    {
        int sz = pressureValues.Length;
        pressureValues[currentPressureValueIndex % sz] = Input.acceleration.z;
        if (setNextPressureValue > 0)
        {
            float total = 0.0f;
            for (int loop = 0; loop < sz; loop++) total += pressureValues[loop];

            float average = total / sz;
            if (setNextPressureValue == Constants.KNumberOfPressureSamples)
            {
                float mostRecent = pressureValues[(currentPressureValueIndex - 1) % sz];
                pressure = (float)Math.Abs(average - mostRecent);
            }

            float diff = (float)Math.Abs(average - Input.acceleration.z);
            if (pressure < diff) pressure = diff;

            setNextPressureValue--;
            if (setNextPressureValue == 0)
            {
                if (pressure >= minimumPressureRequired && pressure <= maximumPressureRequired) this.state = State.Recognized;
                else this.state = State.Failed;

            }

        }

        currentPressureValueIndex++;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                setNextPressureValue = Constants.KNumberOfPressureSamples;
                this.state = State.Possible;
            }

            if (touch.phase == TouchPhase.Canceled)
            {
                this.state = State.Failed;
            }
        }

        if (this.state == State.Ended || this.state == State.Recognized || this.state == State.Cancelled || this.state == State.Failed)
        {
            if (this.state != State.Failed) action(pressure);
            this.state = State.Possible;

            pressure = Constants.PressureNone;
            setNextPressureValue = 0;
            currentPressureValueIndex = 0;
        }
    }

    public void SetAction(System.Action<float> func)
    {
        action += func;
    }

    public void Setup()
    {
        minimumPressureRequired = Constants.PressureNone;
        maximumPressureRequired = Constants.PressureInfinite;
        pressure = Constants.PressureNone;
    }
}
