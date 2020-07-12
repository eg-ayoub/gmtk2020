using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{

    [SerializeField]
    public AudioClip _hitSound;

    [SerializeField]
    public AudioClip _deathSound;
    private AudioSource _source;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    public void PlayHit()
    {
        _source.PlayOneShot(_hitSound);
    }

    public void PlayerDeath()
    {
        _source.PlayOneShot(_deathSound);
    }
}
