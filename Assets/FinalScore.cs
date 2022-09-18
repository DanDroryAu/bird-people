using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FinalScore : MonoBehaviour
{

    [SerializeField] TMP_Text finalText;

    // Start is called before the first frame update
    void Start()
    {
        finalText.text = "Final Score: " + GameManager.Instance.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
