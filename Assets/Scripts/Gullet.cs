using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trash")
        {
            Destroy(other.gameObject);
            Debug.Log("VICTORY SCREECH");
            
        }
    }
}
