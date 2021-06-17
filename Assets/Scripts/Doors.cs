using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    Animator anim;
    //Doors
    public float maxDist = 5f;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < maxDist)
        {
            anim.SetBool("character_nearby", true);
        }
        else
        {
            anim.SetBool("character_nearby", false);
        }
    }
}
