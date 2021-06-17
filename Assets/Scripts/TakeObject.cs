using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObject : MonoBehaviour
{
    private Transform handObject;
    public float takeDist = 3f;
    public float dropForce = 1000f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(handObject)
            {
                handObject.parent = null;
                handObject.gameObject.AddComponent<Rigidbody>();
                handObject = null;
            }
            else
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position, transform.forward, out hit, takeDist))
                {
                    if(hit.transform.tag.Contains("Take"))
                    {
                        handObject = hit.transform;
                        handObject.parent = transform;
                        Destroy(handObject.GetComponent<Rigidbody>());
                    }
                }   
            }
        }

        if(Input.GetKeyDown(KeyCode.Q) & handObject)
        {   
            handObject.parent = null;
            handObject.gameObject.AddComponent<Rigidbody>();
            handObject.GetComponent<Rigidbody>().AddForce(transform.forward * dropForce);
            handObject = null;
        }
    }
}
