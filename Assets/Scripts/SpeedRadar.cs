using Assets.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedRadar : MonoBehaviour
{
    [SerializeField] private float _speedThreshold = 150f;
    private float _fastestSpeedRegistered;
    private float _lowestSpeedRegistered;

    [Space(15f)]
    [Header("Speed Radar UI")]
    [SerializeField] private UIManager _ui;

    private void Start()
    {
        _fastestSpeedRegistered = _speedThreshold;
        _lowestSpeedRegistered = _speedThreshold;
    }

    private void OnTriggerExit(Collider other)
    {
        SpaceShip temp = other.gameObject.GetComponent<SpaceShip>();
        if(temp != null)
        {
            float tempSpeed = temp.GetCurrentSpeed();
            CompareSpeedWithRegisteredSpeeds(tempSpeed);
        }
    }

    private void CompareSpeedWithRegisteredSpeeds(float speed)
    {
        if (speed > _fastestSpeedRegistered)
        {
            RegisterFastestSpeed(speed);
        }

        if(speed < _lowestSpeedRegistered)
        {
            RegisterLowestSpeed(speed);
        }
    }

    private void RegisterFastestSpeed(float speedToRegister)
    {
        _fastestSpeedRegistered = speedToRegister;
        _ui.UpdateFastestSpeed(_fastestSpeedRegistered);
    }

    private void RegisterLowestSpeed(float speedToRegister)
    {
        _lowestSpeedRegistered = speedToRegister;
        _ui.UpdateLowestSpeed(_lowestSpeedRegistered);
    }
}
