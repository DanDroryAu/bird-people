using System;
using Unity.VisualScripting;
using UnityEngine;

public class Beak : MonoBehaviour
{
    [SerializeField] float maxBeakAngle = 10f;
    [SerializeField] private float beakClosedAngle = 2f;
    [SerializeField] private float beakVelocity = 0.1f;
    [SerializeField] private float topBeakRotation = 0f;
    [SerializeField] private float bottomBeakRotation = 0f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private Transform topBeak;
    [SerializeField] private Transform bottomBeak;

    public float GetAngleDiff(float topAngle, float bottomAngle)
    {
        float normalizedTopAngle = Math.Abs(topAngle);
        float normalizedBottomAngle = Math.Abs(bottomAngle);
        if (topAngle < 0 || bottomAngle < 0)
        {
            return normalizedTopAngle + normalizedBottomAngle;
        }

        return Math.Abs(normalizedTopAngle - normalizedBottomAngle);
    }

// Start is called before the first frame update
    void Start()
    {
        Transform topBeak = transform.Find("TopBeak");
        Transform bottomBeak = transform.Find("BottomBeak");
    }

    
    // Update is called once per frame
        void FixedUpdate()
        {
            float horizontalVelocity = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
            float verticalVelocity = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;;
            transform.Rotate(0,-horizontalVelocity, 0);
            transform.Translate(0, verticalVelocity,0 );
            
            
            topBeakRotation = topBeak.rotation.eulerAngles.z;
            bottomBeakRotation = bottomBeak.rotation.eulerAngles.z;
            
            float angleDiff = GetAngleDiff(topBeakRotation, bottomBeakRotation);
            Debug.Log(angleDiff);
            if (Input.GetMouseButton(0))
            {
                if(angleDiff >= beakClosedAngle) {
                    topBeak.Rotate(0, 0, -beakVelocity);
                    bottomBeak.Rotate(0, 0, beakVelocity);
                }
            }
            else if (!Input.GetMouseButton(0))
            {
                if (angleDiff <= maxBeakAngle) {
                    topBeak.Rotate(0, 0, beakVelocity);
                    bottomBeak.Rotate(0, 0, -beakVelocity);
                }
            }

        }
    }
    