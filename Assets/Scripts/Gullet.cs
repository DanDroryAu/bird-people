using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gullet : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trash" || other.tag  == "Food")
        {
            Destroy(other.gameObject);
            Debug.Log("VICTORY SCREECH");
            EventManager.TriggerEvent(AudioEventName.PlayGulp);
        }
    }
}
