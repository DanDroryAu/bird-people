using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovement : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    public Rigidbody rigidBody;
    private float verticalRotation = 0;
    public Transform transformObject;
    public LayerMask hitLayers;
    public Vector3 worldPosition;

    Plane plane = new Plane(Vector3.up, Vector3.zero);
    public float headMovementSpeed = 20;
    
    public Vector2 previousMousePos;

    public enum RotationAxes {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;

    void Awake()
    {
        mainCamera = Camera.main;
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // if (plane.Raycast(ray, out distance))
        // {
        //     worldPosition = ray.GetPoint(distance);
        //     transform.position = worldPosition;
        // }
                
        if(Input.GetKey(KeyCode.Space)) {
            if(axes == RotationAxes.MouseX){
                transform.Rotate(0, 0, Input.GetAxis("Mouse Y") * 15f - 90);
            } else if (axes == RotationAxes.MouseY){
                verticalRotation -= Input.GetAxis("Mouse X") * 15f;
                verticalRotation = Mathf.Clamp(verticalRotation, -45.0f, 45.0f);

                float horizontalRotation = transform.localEulerAngles.y;

                transform.localEulerAngles = new Vector3(verticalRotation, horizontalRotation, -90);
            } else {
                verticalRotation -= Input.GetAxis("Mouse X") * 15f;
                verticalRotation = Mathf.Clamp(verticalRotation, -45.0f, 45.0f);

                float delta = Input.GetAxis("Mouse Y") * 9.0f;
                float horizontalRotation = transform.localEulerAngles.y + delta;
                transform.localEulerAngles = new Vector3(verticalRotation, horizontalRotation, -90);    
            }
        } else {
            Debug.Log(Input.GetAxis("Mouse X"));
            //transform.Translate(new Vector3(-Input.GetAxis("Mouse X") * headMovementSpeed * Time.deltaTime, Input.GetAxis("Mouse Y") * headMovementSpeed * Time.deltaTime, 0), Space.Self);
            if (plane.Raycast(ray, out distance))
            {
                worldPosition = ray.GetPoint(distance);
                transform.position = new Vector3(worldPosition.x, 0, worldPosition.z);
            }
        }
        
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
         return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
     }
}
