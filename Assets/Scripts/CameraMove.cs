using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Rotisserie rotis;
    public GameObject player;        //Public variable to store a reference to the player game object
    public float zoom = 1;

    private Vector3 offset;            //Private variable to store the offset distance between the player and camera
    private Vector3 startPos;

    // Use this for initialization
    void Start () 
    {
        startPos = transform.position;
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate () 
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.

        zoom = rotis.currentAngleNormalized  * 2 / rotis.maxAngleNormalized * -1 + 1;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position + (offset * zoom), 6 * Time.deltaTime);
    }
}