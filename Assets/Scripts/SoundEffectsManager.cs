using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
    [SerializeField] bool ambiancePlaying;
    [SerializeField] AudioSource ambianceSource;
    [SerializeField] AudioClip[] ambianceSounds;
    [SerializeField] AudioSource clackSource;
    [SerializeField] AudioClip clackSound;
    [SerializeField] AudioClip gulpSound;
    [SerializeField] AudioSource honkSource;
    [SerializeField] AudioClip[] honkSounds;
    [SerializeField] AudioSource trashSource;
    [SerializeField] AudioClip[] trashSounds;
    

    private void Start()
    {
        ambiancePlaying = true;
        StartCoroutine(PlayMusicLoop());
    }

    IEnumerator PlayMusicLoop()
    {
        yield return null;

        while (ambiancePlaying)
        {
            foreach (var sound in ambianceSounds)
            {
                ambianceSource.clip = sound;
                ambianceSource.Play();

                while (ambianceSource.isPlaying)
                {
                    yield return null;
                }
            }
        }
    }

    public void ToggleAmbianceMute()
    {
        ambianceSource.mute = !ambianceSource.mute;
    }
  
    public void PlayTrashRustle()
    {
        int trackIndex = UnityEngine.Random.Range(0, trashSounds.Length);
        AudioClip track = trashSounds[trackIndex];
        trashSource.PlayOneShot(track);
    } 
    
    public void PlayHonk()
    {
        int trackIndex = UnityEngine.Random.Range(0, honkSounds.Length);
        AudioClip track = honkSounds[trackIndex];
        
        if (!honkSource.isPlaying)
        {
            honkSource.PlayOneShot(track);
        }
    }
    
    public void PlayClack()
    {
        clackSource.PlayOneShot(clackSound);
    }
    
    public void PlayGulp()
    {
        clackSource.PlayOneShot(gulpSound);
    }
}
