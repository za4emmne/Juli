using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSirena : MonoBehaviour
{
    [SerializeField] private AudioSource _sirena;

    private Coroutine _soundJob;
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
        if (_soundJob != null)
        {
            StopCoroutine(_soundJob);
        }

        _sirena.Play();
        _soundJob = StartCoroutine(ChangeVolume(_maxVolume));
    }

    public void StopSirena()
    {
        if (_soundJob != null)
        {
            StopCoroutine(_soundJob);
        }

        _soundJob = StartCoroutine(ChangeVolume(_minVolume));
    }

    public IEnumerator ChangeVolume(float targetVolume)
    {
        while (true)
        {
            _sirena.volume = Mathf.MoveTowards(_sirena.volume, targetVolume, _step);
            yield return new WaitForSeconds(_waitSecond);
        }

        if (_sirena.volume <= 0)
        {
            _sirena.Stop();
        }
    }
}
