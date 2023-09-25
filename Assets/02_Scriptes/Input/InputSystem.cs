using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static CarInput;

[CreateAssetMenu(fileName = "New Input System", menuName ="SO/InputSystem")]
public class InputSystem : ScriptableObject, ICarActions
{
    public event Action<Vector2> _movementEvent;
    public event Action<Vector2> _gearChangeEvent;
    public event Action <Vector2> _blinkEvent;
    public event Action _lightEvent;
    private CarInput _carInput;


    private void OnEnable()
    {
        if(_carInput == null)
        {
            _carInput = new CarInput();
            _carInput.Car.SetCallbacks(this);
        }
        _carInput.Car.Enable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("move");
        Vector2 value = context.ReadValue<Vector2>();
        _movementEvent.Invoke(value);
    }

    public void OnLight(InputAction.CallbackContext context)
    {
        _lightEvent.Invoke();
    }

    public void OnBlink(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        _blinkEvent.Invoke(value);
    }

    public void OnGear(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        _gearChangeEvent.Invoke(value);
    }
}
