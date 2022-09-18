using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;
using UnityEngine.Events;

public static class AudioEventName
{
    public static string ToggleSoundtrackMute = "ToggleSoundtrackMute";
    public static string ToggleAmbianceMute = "ToggleAmbianceMute";
    public static string PlayTrashRustle = "PlayTrashRustle";
    public static string PlayClack = "PlayClack";
    public static string PlayHonk = "PlayHonk";
    public static string PlayGulp = "PlayGulp";
}

public class SoundManager : MonoBehaviour
{
    [SerializeField] MusicManager musicManager;
    [SerializeField] SoundEffectsManager soundEffectsManager;
    
    void OnEnable ()
    {
        EventManager.StartListening(AudioEventName.ToggleSoundtrackMute, ToggleSoundtrackMute);
        EventManager.StartListening(AudioEventName.ToggleAmbianceMute, ToggleSoundtrackMute);
        EventManager.StartListening(AudioEventName.PlayTrashRustle, PlayTrashRustle);
        EventManager.StartListening(AudioEventName.PlayClack, PlayClack);
        EventManager.StartListening(AudioEventName.PlayHonk, PlayHonk);
        EventManager.StartListening(AudioEventName.PlayGulp, PlayGulp);
    }

    void OnDisable ()
    {
        EventManager.StopListening(AudioEventName.ToggleSoundtrackMute, ToggleSoundtrackMute);
        EventManager.StopListening(AudioEventName.ToggleAmbianceMute, ToggleSoundtrackMute);
        EventManager.StopListening(AudioEventName.PlayTrashRustle, PlayTrashRustle);
        EventManager.StopListening(AudioEventName.PlayClack, PlayClack);
        EventManager.StopListening(AudioEventName.PlayHonk, PlayHonk);
        EventManager.StopListening(AudioEventName.PlayGulp, PlayGulp);
    }
    
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
    
    public void PlayGulp()
    {
        soundEffectsManager.PlayGulp();
    }
}
