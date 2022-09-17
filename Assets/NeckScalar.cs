using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeckScalar : MonoBehaviour
{

    public GameObject neckStartingPos;
    public GameObject neckAttachmentPos;
    public GameObject neckEndPos;
    public GameObject[] NeckBones;
    public bool canStretch = true;

    public float maxNeckLength;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float currentDistance = Vector3.Distance(neckStartingPos.transform.position, neckAttachmentPos.transform.position);

        if (currentDistance > maxNeckLength && canStretch) {
            foreach(GameObject bone in NeckBones)
            {
                bone.transform.localScale = new Vector3(maxNeckLength / currentDistance, currentDistance / maxNeckLength, maxNeckLength / currentDistance);
            }
        }
    }
}
