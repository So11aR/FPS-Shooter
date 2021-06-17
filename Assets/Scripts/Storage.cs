using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public string targetTag;
    public bool isDestroy = false;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag.Contains(targetTag))
        {
            GameManager.Instance.ChangePoints(1);
            if(isDestroy)
            {
                Destroy(other.gameObject);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag.Contains(targetTag))
        {
            GameManager.Instance.ChangePoints(-1);
        }
    }
}
    