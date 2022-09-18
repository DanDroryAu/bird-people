using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotisserie : MonoBehaviour
{

    public Transform head;
    public float headSpeed;
    public float lowAngle;
    public float highAngle;
    public float currentAngleNormalized;
    public float maxAngleNormalized;
    // Start is called before the first frame update
    void Start()
    {
        maxAngleNormalized = highAngle - lowAngle;
    }

    // Update is called once per frame
    void Update()
    {

        // Debug.Log(this.transform.localRotation.eulerAngles.y);
        currentAngleNormalized = lowAngle - this.transform.localRotation.eulerAngles.y;

        if (Input.GetKey(KeyCode.W) && this.transform.localRotation.eulerAngles.y <= lowAngle) {
            this.transform.Rotate(new Vector3(-1f, 0, 0));
            head.Translate(Vector3.down * Time.deltaTime * headSpeed, Space.World);
        }
        
        if (Input.GetKey(KeyCode.S)  && this.transform.localRotation.eulerAngles.y >= highAngle) {
            this.transform.Rotate(new Vector3(1f, 0, 0));
            head.Translate(Vector3.up * Time.deltaTime * headSpeed, Space.World);
        }
        
        // if (Input.GetKey(KeyCode.A)) {
        //     this.transform.Rotate(new Vector3(0, -.2f, 0));
        // }
        
        // if (Input.GetKey(KeyCode.D)) {
        //     this.transform.Rotate(new Vector3(0, .2f, 0));
        // }
    }
}
