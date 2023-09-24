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

public class CarController : MonoBehaviour
{
    [SerializeField] private float motorPower;
    [SerializeField] private AnimationCurve steeringCurve;

    [SerializeField] private InputSystem _input;
    [SerializeField] private wheels[] _wheels;

    private float speed;
    private float gasInput;
    private float steeringInput;
    private Rigidbody _rb;

    private void Awake()
    {
        Debug.Log("½ÇÇà");
        _rb = GetComponent<Rigidbody>();
        _input._movementEvent += SetInput;
    }

    // Update is called once per frame
    private void Update()
    {
        Steering();
        Motor();

        //ÈÙ ¿òÁ÷ÀÓ
        foreach (wheels wheel in _wheels)
        {
            RenderingWheel(wheel._wheelcol, wheel._wheelTrans);
        }
    }

    private void Steering()
    {
        float steeringAngle = steeringInput * steeringCurve.Evaluate(speed);
        foreach (wheels wheel in _wheels)
        {
            if (wheel._wheelPos == WheelPos.Rear) continue;
            wheel._wheelcol.steerAngle = steeringAngle;
        }
    }

    private void Motor()
    {
        foreach(wheels wheel in _wheels)
        {
            if (wheel._wheelPos == WheelPos.Rear) continue;
            wheel._wheelcol.motorTorque = motorPower * gasInput;
        }
    }

    public void SetInput(Vector2 value)
    {
        Debug.Log("µÊ");
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
