using System;
using Unity.VisualScripting;
using UnityEngine;

public class WholeBeak : MonoBehaviour
{
    [SerializeField] float maxBeakAngle = 10f;
    [SerializeField] private float beakClosedAngle = 2f;
    [SerializeField] private float beakVelocity = 0.1f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] private float rotateSpeed = 100f;
    
    [SerializeField] private Transform topBeak;
    [SerializeField] private Transform bottomBeak;
    
    [SerializeField] private Transform topBase;
    [SerializeField] private Transform topTip;
    [SerializeField] private Transform bottomBase;
    [SerializeField] private Transform bottomTip;

    
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

            Vector3 topBeakVector = topBase.position - topTip.position;
            Vector3 bottomBeakVector = bottomBase.position - bottomTip.position;

            float angleDiff = Vector3.Angle(topBeakVector, bottomBeakVector);

            if (Input.GetMouseButton(0))
            {
                if(angleDiff >= beakClosedAngle) {
                    topBeak.Rotate(-beakVelocity, 0, 0);
                    bottomBeak.Rotate(beakVelocity, 0, 0);
                }
            }
            else if (!Input.GetMouseButton(0))
            {
                if (angleDiff <= maxBeakAngle) {
                    topBeak.Rotate(beakVelocity, 0, 0);
                    bottomBeak.Rotate(-beakVelocity, 0, 0);
                }
            }

        }
    }
    