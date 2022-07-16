using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAlarm : MonoBehaviour
{
    private AudioSource _sound;
    private float _rateOfEvasion = 0.5f;
    private bool _isEnable = false;

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
        _sound.volume = 0;
    }

    private void Update()
    {
        if (_sound.volume == 0 && _isEnable == false && _sound.isPlaying == true)
        {
            _sound.Stop();
        }

        if (_isEnable == true)
        {           
                _sound.volume = Mathf.MoveTowards(_sound.volume, 1, _rateOfEvasion * Time.deltaTime);            
        }
        else
        {            
                _sound.volume = Mathf.MoveTowardsAngle(_sound.volume, 0, _rateOfEvasion * Time.deltaTime);            
        }
    }

    public void OnSound()
    {
        if (_isEnable == false)
        {
            _isEnable = true;
            _sound.Play();
        }
    }

    public void OffSound()
    {
        if (_isEnable == true)
        {
            _isEnable = false;
        }
    }

}
