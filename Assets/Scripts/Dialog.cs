using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [HideInInspector] public bool isEnded = false;
    public int requiredPoints = 0;
    public int goldPay = 0;
    [TextArea] public string[] msg;
 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
