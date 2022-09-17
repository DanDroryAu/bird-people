using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggerTest : MonoBehaviour
{
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            EventManager.TriggerEvent("PlayClack");
        }
    }
}
