using UnityEngine;

public class BeakCollider : MonoBehaviour
{
    [SerializeField] private Transform wholeAssBeak;
    private GameObject myPrecious;
    [SerializeField] private Transform trashCan;
    private bool hasTrash = false;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {            
        if (Input.GetMouseButtonUp(0) && hasTrash)
        {
            Debug.Log("You dropped your precious trash");
            myPrecious.transform.SetParent(trashCan);
            myPrecious.GetComponent<Rigidbody>().isKinematic = false;
            hasTrash = false;
        }

    }
    
    void OnCollisionEnter(Collision other)
    {
        if ((other.gameObject.tag == "Trash" || other.gameObject.tag == "Food") && Input.GetMouseButton(0) && !hasTrash)
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.SetParent(wholeAssBeak);
            myPrecious = other.gameObject;
            hasTrash = true;
        } 
    }
}