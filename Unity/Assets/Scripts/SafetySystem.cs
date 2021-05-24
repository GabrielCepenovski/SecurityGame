using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SafetySystem : MonoBehaviour
{
    [SerializeField] private float _rateIncreaseVolume = 0.1f;

    private AudioSource _audio;
    private float _targetValue;
    private Stay _stay;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();

        _audio.volume = 0;
        _stay = Stay.NoCorutine;
    }

    public void TurnSiren()
    {
        _targetValue = 1;

        if (_stay != Stay.NoCorutine)
        {
            StopCoroutine(Siren());
            _stay = Stay.NoCorutine;
        }

        StopCoroutine(Siren());
    }

    public void StopSiren()
    {
        _targetValue = 0;

        if (_stay != Stay.NoCorutine)
        {
            StopCoroutine(Siren());
            _stay = Stay.NoCorutine;
        }

        StopCoroutine(Siren());
    }

    private IEnumerator Siren()
    {
        if (_audio.isPlaying == false)
            _audio.Play();

        _stay = Stay.Corutine;
        while (true)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, _targetValue, _rateIncreaseVolume * Time.deltaTime);

            yield return null;

            if (_audio.volume == _targetValue) 
                break;
        }

        if (_audio.isPlaying && _audio.volume == 0)
            _audio.Stop();
    }

    private enum Stay
    {
        NoCorutine,
        Corutine
    }
}