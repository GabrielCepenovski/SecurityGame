using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetySystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _rateIncreaseVolume = 0.1f;

    private bool _siren = false;

    private void Awake()
    {
        _audio.volume = 0;
    }

    public void TurnSiren()
    {
        if (_audio != null)
        {
            _siren = true;
            _audio.Play();
        }
    }

    public void StopSiren()
    {
        if (_audio != null)
        {
            _siren = false;
        }
    }

    private void Start()
    {
        if (_audio != null)
            StartCoroutine(UpdateSystem());
    }

    private IEnumerator UpdateSystem()
    {
        while (true)
        {
            if (_siren)
                _audio.volume = Mathf.MoveTowards(_audio.volume, 1, _rateIncreaseVolume * Time.deltaTime);
            else
                _audio.volume = Mathf.MoveTowards(_audio.volume, 0, _rateIncreaseVolume * Time.deltaTime);

            if (_audio.volume == 0)
                _audio.Stop();

            yield return null;
        }

    }
}