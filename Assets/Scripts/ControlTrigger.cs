using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _onAlarm;
    [SerializeField] private UnityEvent _offAlarm;

    private float _positionTriggerX;
    private float _positionCollisionEnterX;
    private float _positionCollisionExitX;
    private bool isAlarm = false;

    private void Start()
    {
        _positionTriggerX = GetComponent<Transform>().position.x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Movement>(out Movement player))
        {
            _positionCollisionEnterX = collision.GetComponent<Transform>().position.x;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Movement>(out Movement player))
        {
            _positionCollisionExitX = collision.GetComponent<Transform>().position.x;

            if((_positionCollisionEnterX < _positionTriggerX && _positionTriggerX < _positionCollisionExitX) || (_positionCollisionEnterX > _positionTriggerX && _positionTriggerX > _positionCollisionExitX))
            {
                if(isAlarm == false)
                {
                    isAlarm = true;
                    _onAlarm.Invoke();
                }
                else
                {
                    isAlarm = false;
                    _offAlarm.Invoke();
                }
            }
        }
    }
}
