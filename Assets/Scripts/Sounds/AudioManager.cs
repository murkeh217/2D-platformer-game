using System;
using System.Media;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public static AudioManager Instance
    {
        get
        {
            return instance;
        }
    }

    public SoundType[] Sounds;
    public AudioSource soundEffect;
    public AudioSource soundMusic;
    public bool isMute;
    public float volume = 1f;   

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        SetVolume(0.5f);
        PlayMusic(global::Sounds.Music);
    }

    public void Mute(bool status) 
    {
        isMute = status;
    }

    public void SetVolume(float vol) {
        vol = volume;
        soundEffect.volume = volume;
        soundMusic.volume = volume;
    }
    public void PlayMusic(Sounds sound) 
    {

        if (isMute)
            return;

        AudioClip clip = GetSoundClip(sound);

        if (clip != null)
        {
            soundMusic.clip = clip;
            soundMusic.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("Clip not found for sound type: " + sound);
        }
    }

    public void Play(Sounds sound)
    {
        if (isMute)
            return;
        AudioClip clip = GetSoundClip(sound);

        if (clip != null)
        {
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("Clip not found for sound type: " + sound);
        }
    }

    private AudioClip GetSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(Sounds, i => i.soundType == sound);

        return item != null ? item.soundClip : null;
    }

}

[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundClip;
}

public enum Sounds
{
    ButtonClick,
    Music,
    PlayerMove,
    PlayerDeath,
    KeyCollect,
    LevelSound
}