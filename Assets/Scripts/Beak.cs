using Unity.VisualScripting;
using UnityEngine;

public class Beak : MonoBehaviour
{
    [SerializeField] float maxBeakAngle = 10f;
    [SerializeField] private float beakClosedAngle = 2f;
    [SerializeField] private float beakVelocity = 0.1f;
    [SerializeField] private float topBeakRotation = 0f;
    [SerializeField] private float bottomBeakRotation = 0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Transform topBeak = transform.Find("TopBeak");
    }

    // Update is called once per frame
        void FixedUpdate()
        {
            topBeakRotation = transform.Find("TopBeak").transform.rotation.eulerAngles.z;
            bottomBeakRotation = transform.Find("BottomBeak").transform.rotation.eulerAngles.z;

            if (Input.GetMouseButton(0))
            {
                if(topBeakRotation >= beakClosedAngle) {
                    transform.Find("TopBeak").transform.Rotate(0, 0, -beakVelocity);
                    transform.Find("BottomBeak").transform.Rotate(0, 0, beakVelocity);
                }
            }
            else if (!Input.GetMouseButton(0))
            {
                if (topBeakRotation <= maxBeakAngle) {
                    transform.Find("TopBeak").transform.Rotate(0, 0, beakVelocity);
                    transform.Find("BottomBeak").transform.Rotate(0, 0, -beakVelocity);
                }
            }

        }
    }
    