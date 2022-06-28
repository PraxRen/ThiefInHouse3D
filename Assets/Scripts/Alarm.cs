using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _stepVolume;

    private const float MaxVolume = 1.0f;
    private const float MinVolume = 0.1f;
    private AudioSource _audioSourse;
    private bool isReversVolume;
    private bool _isOn;
    public bool IsOn => _isOn;

    private void Start()
    {
        _audioSourse = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (_isOn == false)
            return;

        if (_audioSourse.volume == MaxVolume)
            isReversVolume = true;
        else if (_audioSourse.volume == MinVolume)
            isReversVolume = false;

        if (isReversVolume == false)
            _audioSourse.volume = Mathf.MoveTowards(_audioSourse.volume, MaxVolume, _stepVolume * Time.deltaTime);
        else
            _audioSourse.volume = Mathf.MoveTowards(_audioSourse.volume, MinVolume, _stepVolume * Time.deltaTime);
    }

    public void TurnOn()
    {
        if (_isOn == true)
            return;

        _isOn = true;
        _audioSourse.volume = MinVolume;
        _audioSourse.Play();
    }

    public void TurnOff()
    {
        _isOn = false;
        _audioSourse.Stop();
    }
}
