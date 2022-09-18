using System;
using Unity.VisualScripting;
using UnityEngine;

public class WholeBeak : MonoBehaviour
{
    [SerializeField] float maxBeakAngle = 10f;
    [SerializeField] private float beakClosedAngle = 2f;
    [SerializeField] private float beakVelocity = 0.1f;

    [SerializeField] private Transform topBeak;
    [SerializeField] private Transform bottomBeak;
    
    [SerializeField] private Transform topBase;
    [SerializeField] private Transform topTip;
    [SerializeField] private Transform bottomBase;
    [SerializeField] private Transform bottomTip;

    [SerializeField] private bool isBeakClackReady = false;

    
// Start is called before the first frame update
    void Start()
    {
        Transform topBeak = transform.Find("TopBeak");
        Transform bottomBeak = transform.Find("BottomBeak");
    }

    
    // Update is called once per frame
        void FixedUpdate()
        {
            Vector3 topBeakVector = topBase.position - topTip.position;
            Vector3 bottomBeakVector = bottomBase.position - bottomTip.position;

            float angleDiff = Vector3.Angle(topBeakVector, bottomBeakVector);
            
            if(angleDiff < beakClosedAngle && isBeakClackReady) {
                EventManager.TriggerEvent(AudioEventName.PlayClack);
                isBeakClackReady = false;
            }

            if (Input.GetMouseButton(0))
            {
                if(angleDiff >= beakClosedAngle) {
                    // Reset beak clack
                    isBeakClackReady = true;
                    
                    topBeak.Rotate(-beakVelocity, 0, 0);
                    bottomBeak.Rotate(beakVelocity, 0, 0);
                }
            }
            else if (!Input.GetMouseButton(0))
            {
                if (angleDiff <= maxBeakAngle) {
                    // Honk randomly on beaking opening 
                    float honkRange = UnityEngine.Random.Range(0, 50);
                    bool isHonkActivated = honkRange < 1;
                    
                    if (isHonkActivated)
                    {
                        EventManager.TriggerEvent(AudioEventName.PlayHonk);
                    }
                    
                    // Open beak on LMB release
                    topBeak.Rotate(beakVelocity, 0, 0);
                    bottomBeak.Rotate(-beakVelocity, 0, 0);
                }
            }

        }
    }
    