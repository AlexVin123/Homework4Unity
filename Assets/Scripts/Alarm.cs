using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private AudioSource _sound;
    private float _rateOfEvasion = 0.5f;

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
        _sound.volume = 0;
    }

    public void OnSound()
    {
        _sound.Play();
        StartCoroutine(UpVolume());

        if(_sound.volume == 1)
        {
            StopCoroutine(UpVolume());
        }                
    }

    public void OffSound()
    {
        StartCoroutine(DownVolume());

        if(_sound.volume == 0)
        {
            StopCoroutine(DownVolume());
            _sound.Stop();
        }
    }

    private IEnumerator UpVolume()
    {
        while(_sound.volume != 1)
        {
            _sound.volume = Mathf.MoveTowards(_sound.volume, 1, _rateOfEvasion * Time.deltaTime);
            yield return null;
        }              
    }

    private IEnumerator DownVolume()
    {
        while(_sound.volume != 0)
        {
            _sound.volume = Mathf.MoveTowardsAngle(_sound.volume, 0, _rateOfEvasion * Time.deltaTime);
            yield return null;
        }                
    }
}
