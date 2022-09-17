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
        EventManager.TriggerEvent("ToggleSoundtrackMute");
    }
    
    // SFX
    public void ToggleAmbianceMute()
    {
        EventManager.TriggerEvent("ToggleAmbianceMute");
    }
    
    public void PlayTrashRustle()
    {
        EventManager.TriggerEvent("PlayTrashRustle");
    }
    
    public void PlayClack()
    {
        EventManager.TriggerEvent("PlayClack");
    }
    
    public void PlayHonk()
    {
        EventManager.TriggerEvent("PlayHonk");
    }
}
