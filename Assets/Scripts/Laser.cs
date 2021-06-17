using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float laserDist = 100f;
    public GameObject boom;
    private LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!line.enabled)
        {
            return;
        }
        line.SetPosition(0, transform.localPosition);
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, laserDist))
        {
            if(hit.collider)
            {
                float dist = Vector3.Distance(transform.position, hit.point);
                line.SetPosition(1, Vector3.forward * dist);
                Instantiate(boom, hit.point, Quaternion.identity);
                if(hit.collider.tag.Contains("Destroy"))
                {
                    hit.collider.tag = "Untagged";
                    Destroy(hit.collider.gameObject, 0.2f);
                    GameManager.Instance.ChangePoints(1);
                }
            }
        }
        else
        {
            line.SetPosition(1, Vector3.forward * laserDist);
        }
    }
}
