using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _stepVolume;

    private const float MaxVolume = 0.3f;
    private const float MinVolume = 0.1f;
    private AudioSource _audioSourse;
    private bool _isReversVolume;
    private Coroutine _changeVolumeJob;

    private void Start()
    {
        _audioSourse = GetComponent<AudioSource>();
    }

    private IEnumerator ChangeVolume()
    {
        while (true)
        {
            if (_audioSourse.volume == MaxVolume)
                _isReversVolume = true;
            else if (_audioSourse.volume == MinVolume)
                _isReversVolume = false;

            if (_isReversVolume == false)
                _audioSourse.volume = Mathf.MoveTowards(_audioSourse.volume, MaxVolume, _stepVolume * Time.deltaTime);
            else
                _audioSourse.volume = Mathf.MoveTowards(_audioSourse.volume, MinVolume, _stepVolume * Time.deltaTime);

            yield return null;
        }
    }

    public void TurnOn()
    {
        if (_changeVolumeJob != null)
            return;

        _audioSourse.volume = MinVolume;
        _audioSourse.Play();
        _changeVolumeJob = StartCoroutine(ChangeVolume());
    }

    public void TurnOff()
    {
        if (_changeVolumeJob is null)
            return;

        _audioSourse.Stop();
        StopCoroutine(_changeVolumeJob);
        _changeVolumeJob = null;
    }
}
