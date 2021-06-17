using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    public Transform createPos;
    public float maxDist = 2f;
    private Transform player;
    private bool isShopping = false;

    void Start()
    {
        shopPanel.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && !isShopping)
        {
            if(Vector3.Distance(transform.position, player.position) < maxDist)
            {
                Toggle(true);
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape) && isShopping)
        {
            Toggle(false);
        }
    }

    void Toggle(bool state)
    {
        isShopping = state;
        shopPanel.SetActive(state);
        player.GetComponent<PlayerController>().enabled = !state;
        player.GetComponent<Shooting>().enabled = !state;
    }

    public void Buy(GameObject obj, int price)
    {
        if(GameManager.Instance.gold >= price)
        {
            Instantiate(obj, createPos.position, Quaternion.identity);
            GameManager.Instance.ChangeGold(-price);
        }    
    }
}
