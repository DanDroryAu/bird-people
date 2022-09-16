using UnityEngine;

public class BeakParts : MonoBehaviour
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
        Debug.Log(other);
        if (other.gameObject.tag == "Trash")
        {
            Debug.Log("Yummy trash");
            
            // reference of pivot point of wholeAssBeak
            // if angle of beak parts > something
            // function to lock the trash component to the pivotPoint
            
        } 
    }
}
