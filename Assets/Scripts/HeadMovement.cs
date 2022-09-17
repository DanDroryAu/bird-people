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

    public Plane plane;
    public float headMovementSpeed = 20;
    
    public Vector2 previousMousePos;
    public float maxHeadDistance;
    public float elapsedTime = 0;
    public float startDelay = 2;
    public Transform headStartingPos;

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
        elapsedTime += Time.deltaTime;
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
            if (startDelay < elapsedTime) {
                transform.Translate(new Vector3(Input.GetAxis("Mouse X") * headMovementSpeed * Time.deltaTime, 0, Input.GetAxis("Mouse Y") * headMovementSpeed * Time.deltaTime), Space.World);
                if (Vector3.Distance(transformObject.position, headStartingPos.position) >= maxHeadDistance) {
                    Vector3 line = transformObject.position - headStartingPos.position;
                    
                    transformObject.position = headStartingPos.position + line.normalized * maxHeadDistance;
                } 
            }
            // if (plane.Raycast(ray, out distance))
            // {
            //     worldPosition = ray.GetPoint(distance);
            //     transform.position = new Vector3(worldPosition.x, 0, worldPosition.z);
            // }
        }
        
    }

    private void OnDrawGizmos() {
        Gizmos.DrawLine(headStartingPos.position, transformObject.position);
        
        Vector3 line = transformObject.position - headStartingPos.position;
        Vector3 rootedLine = line + headStartingPos.position;
        
        Gizmos.DrawLine(Vector3.zero, line);
                
        Gizmos.DrawSphere(line.normalized * maxHeadDistance, 0.1f);
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
         return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
     }
}
