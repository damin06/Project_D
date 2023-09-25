using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WheelPos { Front, Rear };
[Serializable]
struct wheels
{
    public WheelPos _wheelPos;
    public WheelCollider _wheelcol;
    public Transform _wheelTrans;
}

[RequireComponent(typeof(Rigidbody))]

public class CarController : MonoBehaviour
{
    [SerializeField] private float motorPower;
    [SerializeField] private AnimationCurve steeringCurve;

    [SerializeField] private InputSystem _input;
    [SerializeField] private wheels[] _wheels;

    private float gasInput;
    private float steeringInput;
    private float speed => _rb.velocity.magnitude;
    private float slipAngle;

    private Rigidbody _rb;

    private void Awake()
    {
        Debug.Log("실행");
        _rb = GetComponent<Rigidbody>();
        _input._movementEvent += SetInput;
    }

    // Update is called once per frame
    private void Update()
    {
        Steering();
        Motor();
        Brake();

        //휠 움직임
        foreach (wheels wheel in _wheels)
        {
            RenderingWheel(wheel._wheelcol, wheel._wheelTrans);
        }
    }

    private void Brake()
    {
        //slipAngle = Vector3.SignedAngle(transform.forward)
    }

    private void Steering()
    {
        //float percent = Vector3.Lerp()
        float steeringAngle = steeringInput * steeringCurve.Evaluate(speed);
        Debug.Log(steeringAngle);
        foreach (wheels wheel in _wheels)
        {
            if (wheel._wheelPos == WheelPos.Front)
            wheel._wheelcol.steerAngle = steeringAngle;
        }
    }

    private void Motor()
    {
        foreach(wheels wheel in _wheels)
        {
            if (wheel._wheelPos == WheelPos.Rear)
            wheel._wheelcol.motorTorque = motorPower * gasInput;
        }
    }

    public void SetInput(Vector2 value)
    {
        gasInput = value.y;
        steeringInput = value.x;
    }

    private void RenderingWheel(WheelCollider _col, Transform _wheelPos)
    {
        Vector3 pos;
        Quaternion rot;
        _col.GetWorldPose(out pos, out rot);
        _wheelPos.transform.position = pos;
        _wheelPos.transform.rotation = rot;
    }
}
