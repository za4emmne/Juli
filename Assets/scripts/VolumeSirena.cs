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
        _soundOnJob = StartCoroutine(ChangeVolume(_maxVolume));
    }

    public void StopSirena()
    {
        StopCoroutine(_soundOnJob);
        _soundOffJob = StartCoroutine(ChangeVolume(_minVolume));

        if (_sirena.volume <= 0)
        {
            _sirena.Stop();
        }
    }

    public IEnumerator ChangeVolume(float targetVolume)
    {
        while (true)
        {
            _sirena.volume = Mathf.MoveTowards(_sirena.volume, targetVolume, _step);
            yield return new WaitForSeconds(_waitSecond);
        }
    }
}