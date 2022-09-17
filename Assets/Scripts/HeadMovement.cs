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
    public float horizontalMouse;
    public float verticalMouse;

    Plane plane = new Plane(Vector3.up, 0);

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
        float horizontalMouse = Input.GetAxis("Mouse X");
        float verticalMouse = Input.GetAxis("Mouse Y");
    }

    // Update is called once per frame
    void Update()
    {   
        float horizontalMouse = Input.GetAxis("Mouse X");
        float verticalMouse = Input.GetAxis("Mouse Y");
        Vector3 mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // head moves with mouse
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance)){
            worldPosition = ray.GetPoint(distance);
        }
            
        // head rotates with mouse
        if(Input.GetKey(KeyCode.Space)){
            // pitch - movement along the X axis, up and down
            verticalRotation -= verticalMouse * 45f;
            verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

            // yaw - movement along the Y axis, left and right
            float delta = horizontalMouse * 20.0f;
            float horizontalRotation = transform.localEulerAngles.y + delta;
            // allowing roll/tilt of head
            transform.localEulerAngles = new Vector3(-verticalRotation, horizontalRotation, -horizontalRotation);  

            Debug.Log(verticalMouse);
            // head goes down to pick up trash
            transform.position += new Vector3(horizontalMouse * 2f, -verticalMouse * 5f, verticalMouse * 8f);
        } 
        else {
            transform.position = worldPosition;
        }
    }
}
