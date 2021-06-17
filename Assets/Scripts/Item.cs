using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [Header("Settings")]
    public Shop shop;
    public Text priceText;

    [Header("Item")]
    public int price = 5;
    public GameObject product;
    void Start()
    {
        priceText.text = price.ToString();
    }

    public void Buy()
    {
        shop.Buy(product, price);
    }
}
