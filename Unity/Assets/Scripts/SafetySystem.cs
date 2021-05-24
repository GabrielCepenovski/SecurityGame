using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetySystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _rateIncreaseVolume = 0.1f;

    private void Awake()
    {
        _audio.volume = 0;
    }

    public void TurnSiren()
    {
        if (_audio != null)
        {
            StopCoroutine(DownSiren());
            StartCoroutine(UpSiren());
        }
    }

    public void StopSiren()
    {
        if (_audio != null)
        {
            StopCoroutine(UpSiren());
            StartCoroutine(DownSiren());
        }
    }

    private IEnumerator UpSiren()
    {
        _audio.volume = Mathf.MoveTowards(_audio.volume, 1, _rateIncreaseVolume * Time.deltaTime);

        yield return null;

        if (_audio.volume == 1)
            StopCoroutine(UpSiren());
    }

    private IEnumerator DownSiren()
    {
        _audio.volume = Mathf.MoveTowards(_audio.volume, 0, _rateIncreaseVolume * Time.deltaTime);

        yield return null;

        if (_audio.volume == 1)
            StopCoroutine(DownSiren());
    }
}