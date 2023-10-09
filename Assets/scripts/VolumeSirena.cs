using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSirena : MonoBehaviour
{
    [SerializeField] private AudioSource _sirena;
    private Coroutine _soundOnJob;
    private void Start()
    {
         _sirena.volume = 0f;
    }
    public void StartSirena()
    {
        _soundOnJob = StartCoroutine(SoundOn());
    }

    public void StopSirena()
    {
        StopCoroutine(_soundOnJob);
        var SoundOffJob = StartCoroutine(SoundOff());
        if (_sirena.volume <= 0.01)
            _sirena.Stop();
    }

    public IEnumerator SoundOn()
    {
        _sirena.Play();

        for (float i = 0; i < 1; i += 0.01f)
        {
            _sirena.volume = i;
            Debug.Log(_sirena.volume);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private IEnumerator SoundOff()
    {
        for (float i = _sirena.volume; i >= 0; i -= 0.01f)
        {
            _sirena.volume = i;
            Debug.Log(_sirena.volume);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
