using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] MusicManager musicManager;
    [SerializeField] SoundEffectsManager soundEffectsManager;
    
    // Music
    public void ToggleSoundtrackMute()
    {
        musicManager.ToggleSoundtrackMute();
    }
    
    // SFX
    public void ToggleAmbianceMute()
    {
        soundEffectsManager.ToggleAmbianceMute();
    }
    
    public void PlayTrashRustle()
    {
        soundEffectsManager.PlayTrashRustle();
    }
    
    public void PlayClack()
    {
        soundEffectsManager.PlayClack();
    }
    
    public void PlayHonk()
    {
        soundEffectsManager.PlayHonk();
    }
}
