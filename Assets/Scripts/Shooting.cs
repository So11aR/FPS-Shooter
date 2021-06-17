using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float coolDown = 1f;
    public LineRenderer line;

    private bool isShooting;
    // Start is called before the first frame update
    void Start()
    {
        line.enabled = false;
    }
    IEnumerator LaserShoot()
    {
        isShooting = true;
        line.enabled = true;
        yield return new WaitForSeconds(1f);
        line.enabled = false;
        yield return new WaitForSeconds(coolDown);
        isShooting = false;
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !isShooting)
        {
            StartCoroutine(LaserShoot());
        }
    }
}
