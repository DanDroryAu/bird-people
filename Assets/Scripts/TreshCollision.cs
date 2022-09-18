using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreshCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude is > 3f and < 5f)
        {
            if (collision.gameObject.tag == "Trash" || collision.gameObject.tag == "Food") {
                EventManager.TriggerEvent(AudioEventName.PlayTrashRustle);
            }
        }
    }
}
