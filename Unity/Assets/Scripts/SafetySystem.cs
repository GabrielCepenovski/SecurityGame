using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SafetySystem : MonoBehaviour
{
    [SerializeField] private float _rateIncreaseVolume = 0.1f;

    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _audio.volume = 0;
    }

    public void TurnSiren()
    {
        StopCoroutine(DownSiren());
        StartCoroutine(UpSiren());
    }

    public void StopSiren()
    {
        StopCoroutine(UpSiren());
        StartCoroutine(DownSiren());
    }

    private IEnumerator UpSiren()
    {
        while (true)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, 1, _rateIncreaseVolume * Time.deltaTime);

            yield return new WaitForFixedUpdate();

            if (_audio.volume == 1) 
                break;
        }
    }

    private IEnumerator DownSiren()
    {
        while (true)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, 0, _rateIncreaseVolume * Time.deltaTime);

            yield return new WaitForFixedUpdate();

            if (_audio.volume == 0f)
                break;
        }
    }
}