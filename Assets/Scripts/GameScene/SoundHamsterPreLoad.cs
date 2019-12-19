using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHamsterPreLoad : MonoBehaviour
{
    [SerializeField] private AudioClip soundHamsterStandSmall;
    public AudioClip SoundHamsterStandSmall { get => soundHamsterStandSmall;  }

    [SerializeField] private AudioClip soundHamsterStandBig;
    public AudioClip SoundHamsterStandBig { get => soundHamsterStandBig; }

    [SerializeField] private AudioClip soundHamsterBombSmall;
    public AudioClip SoundHamsterBombSmall { get => soundHamsterBombSmall; }

    [SerializeField] private AudioClip soundHamsterBombBig;
    public AudioClip SoundHamsterBombBig { get => soundHamsterBombBig; }

    [SerializeField] private AudioClip soundHamsterHealSmall;
    public AudioClip SoundHamsterHealSmall { get => soundHamsterHealSmall; }

    [SerializeField] private AudioClip soundHamsterHealBig;
    public AudioClip SoundHamsterHealBig { get => soundHamsterHealBig; }

    private AudioSource audioSource;

    private string nameKeySettingSound = "hamster_sound";
    private bool isSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        ChangeSound();
    }

    public void ChangeSound()
    {
        isSound = PlayerPrefs.GetInt(nameKeySettingSound) == 1 ? true : false;
    }

    private void PlaySoundHamster(TypeHamster typeHamster)
    {
        if (!isSound) return;

        switch (typeHamster)
        {
            case TypeHamster.StandSmall:
                audioSource.PlayOneShot(soundHamsterStandSmall);
                break;
            case TypeHamster.StandBig:
                audioSource.PlayOneShot(soundHamsterStandBig);
                break;
            case TypeHamster.BombSmall:
                audioSource.PlayOneShot(soundHamsterBombSmall);
                break;
            case TypeHamster.BombBig:
                audioSource.PlayOneShot(soundHamsterBombBig);
                break;
            case TypeHamster.HealSmall:
                audioSource.PlayOneShot(soundHamsterHealSmall);
                break;
            case TypeHamster.HealBig:
                audioSource.PlayOneShot(soundHamsterHealBig);
                break;
        }
    }

    private void OnEnable()
    {
        Broadcast.PlaySoundHamster += PlaySoundHamster;
    }

    private void OnDisable()
    {
        Broadcast.PlaySoundHamster -= PlaySoundHamster;
    }
}
