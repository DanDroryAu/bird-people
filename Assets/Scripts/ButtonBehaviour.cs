using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    public SoundManager soundManager;
    
    // Getters
    private void GetSoundManager()
    {
        if (!soundManager)
        {
            soundManager = FindObjectOfType<SoundManager>();
        }
    }
    
    // Music
    public void ToggleSoundtrackMute()
    {
        GetSoundManager();
        soundManager.ToggleSoundtrackMute();
    }
    
    // SFX
    public void ToggleAmbianceMute()
    {
        GetSoundManager();
        soundManager.ToggleAmbianceMute();
    }
    
    public void PlayTrashRustle()
    {
        GetSoundManager();
        soundManager.PlayTrashRustle();
    }
    
    public void PlayClack()
    {
        GetSoundManager();
        soundManager.PlayClack();
    }
    
    public void PlayHonk()
    {
        GetSoundManager();
        soundManager.PlayHonk();
    }
}
