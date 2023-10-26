using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSirena : MonoBehaviour
{
    [SerializeField] private AudioSource _sirena;

    private Coroutine _soundOnJob;
    private Coroutine _soundOffJob;
    private float _maxVolume = 1f;
    private float _minVolume = 0;
    private float _step = 0.005f;
    private float _waitSecond = 0.1f;

    private void Start()
    {
        _sirena.volume = _minVolume;
    }


    public void StartSirena()
    {
        _sirena.Play();
        _soundOnJob = StartCoroutine(SoundOn());
    }

    public void StopSirena()
    {
        StopCoroutine(_soundOnJob);
        _soundOffJob = StartCoroutine(SoundOff());

        if (_sirena.volume <= 0)
        {
            _sirena.Stop();
        }
    }

    public IEnumerator SoundOn()
    {
        while (_sirena.volume < _maxVolume)
        {
            ChangeVolume(_maxVolume);
            //_sirena.volume = Mathf.MoveTowards(_sirena.volume, _maxVolume, _step);
            yield return new WaitForSeconds(_waitSecond);
        }
    }

    private IEnumerator SoundOff()
    {
        while (_sirena.volume >= _minVolume)
        {
            ChangeVolume(_minVolume);
            //_sirena.volume = Mathf.MoveTowards(_sirena.volume, _minVolume, _step);
            yield return new WaitForSeconds(_waitSecond);
        }
    }

    private void ChangeVolume(float targetVolume)
    {
        _sirena.volume = Mathf.MoveTowards(_sirena.volume, targetVolume, _step);
    }
}