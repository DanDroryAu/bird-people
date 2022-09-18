using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gullet : MonoBehaviour
{
    public float yHeightActivation = 6;


    void OnTriggerEnter(Collider other)
    {
        if (transform.position.y >= yHeightActivation) {
            if (other.tag  == "Food")
            {
                Destroy(other.gameObject);
                GameManager.Instance.EatFood();
                Debug.Log("VICTORY SCREECH");
                EventManager.TriggerEvent(AudioEventName.PlayGulp);
            }

            if (other.tag == "Trash") {
                Destroy(other.gameObject);
                Debug.Log("UGH VOM");
                EventManager.TriggerEvent(AudioEventName.PlayVom);
            }
        }
    }
}
