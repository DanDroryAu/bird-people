using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreshCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("Collision: " + collision.relativeVelocity.magnitude);
        if (collision.relativeVelocity.magnitude is > 3f and < 5f)
        {
            if (collision.gameObject.tag == "Trash" || collision.gameObject.tag == "Food") {
                Debug.Log("CollisionTag: " + collision.gameObject.tag);
                EventManager.TriggerEvent(AudioEventName.PlayTrashRustle);
            }
        }
    }
}
