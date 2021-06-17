using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogPerson : MonoBehaviour
{
    public GameObject messagePanel;
    public Text messageText;
    public float maxDist = 2f;
    [Header("Dialogs")]
    public Dialog goAway;
    public Dialog needPoints;
    public Dialog[] dialogs;

    private Transform player;
    private bool isDialogNow = false;

    void Start()
    {
        messagePanel.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && !isDialogNow)
        {
            if(Vector3.Distance(transform.position, player.position) < maxDist)
            {
                Chat();
            }
        }
    }

    void Toggle(bool state)
    {
        isDialogNow = state;
        messagePanel.SetActive(state);
        player.GetComponent<PlayerController>().enabled = !state;
        player.GetComponent<Shooting>().enabled = !state;
    }

    void Chat()
    {
        Toggle(true);
        for(int i = 0; i < dialogs.Length; i++)
        {
            if(!dialogs[i].isEnded)
            {
                if(GameManager.Instance.points >= dialogs[i].requiredPoints)
                {
                    StartCoroutine(BeginDialog(dialogs[i]));
                }
                else
                {
                    StartCoroutine(BeginDialog(needPoints));
                }
                return;
            }
        }
        StartCoroutine(BeginDialog(goAway));
    }

    IEnumerator BeginDialog(Dialog dia)
    {
        int index = 0;
        while (index < dia.msg.Length)
        {
            messageText.text = dia.msg[index];
            yield return new WaitUntil(() => (Input.GetMouseButtonUp(0)));
            yield return null;
            index++;
        }
        dia.isEnded = true;
        GameManager.Instance.ChangeGold(dia.goldPay);

        Toggle(false);
    }

}
