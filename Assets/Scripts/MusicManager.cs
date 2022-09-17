using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] bool playing;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioClip[] tracks;

    private void Start()
    {
        playing = true;
        StartCoroutine(PlayMusicLoop());
    }

    IEnumerator PlayMusicLoop()
    {
        yield return null;

        while (playing)
        {
            for (int i = 0; i < tracks.Length; i++)
            {
                musicSource.clip = tracks[i];
                musicSource.Play();

                while (musicSource.isPlaying)
                {
                    yield return null;
                }
            }
        }
    }

    public void ToggleSoundtrackMute()
    {
        musicSource.mute = !musicSource.mute;
    }
}
