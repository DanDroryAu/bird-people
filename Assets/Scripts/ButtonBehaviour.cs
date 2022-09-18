using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    public SoundManager soundManager;
    
    // Music
    public void ToggleSoundtrackMute()
    {
        EventManager.TriggerEvent(AudioEventName.ToggleSoundtrackMute);
    }
    
    // SFX
    public void ToggleAmbianceMute()
    {
        EventManager.TriggerEvent(AudioEventName.ToggleAmbianceMute);
    }
    
    public void PlayTrashRustle()
    {
        EventManager.TriggerEvent(AudioEventName.PlayTrashRustle);
    }
    
    public void PlayClack()
    {
        EventManager.TriggerEvent(AudioEventName.PlayClack);
    }
    
    public void PlayHonk()
    {
        EventManager.TriggerEvent(AudioEventName.PlayHonk);
    }
}
