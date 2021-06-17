using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [HideInInspector] public int points = 0;
    public Text scoreText;

    [HideInInspector] public int gold = 0;
    public Text goldText;
    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        ChangePoints(0);
        ChangeGold(0);
    }

    public void ChangePoints(int amount)
    {
        points += amount;
        scoreText.text = $"{points} Points";
    }

    public void ChangeGold(int amount)
    {
        gold += amount;
        goldText.text = $"{gold} Gold";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
