using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeakCollider : MonoBehaviour
{
    [SerializeField] private Transform wholeAssBeak;
    private GameObject myPrecious;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {            
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("You dropped your precious trash");
            myPrecious.transform.SetParent(null);
            // myPrecious.attachedRigidbody.useGravity = true;
        }

    }
    
    void OnCollisionEnter(Collision other)
    {
        
        Debug.Log(other);
        if (other.gameObject.tag == "Trash" && Input.GetMouseButton(0))
        {
            Debug.Log("Yummy trash");
            other.transform.SetParent(transform);
            myPrecious = other.gameObject;
        } 
    }
}