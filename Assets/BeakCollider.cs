using UnityEngine;

public class BeakCollider : MonoBehaviour
{
    [SerializeField] private Transform wholeAssBeak;
    private GameObject myPrecious;
    [SerializeField] private Transform trashCan;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {            
        if (Input.GetMouseButtonUp(0) && myPrecious != null)
        {
            Debug.Log("You dropped your precious trash");
            myPrecious.transform.SetParent(trashCan);
            myPrecious.GetComponent<Rigidbody>().isKinematic = false;
        }

    }
    
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Trash" && Input.GetMouseButton(0))
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.SetParent(wholeAssBeak);
            myPrecious = other.gameObject;
        } 
    }
}