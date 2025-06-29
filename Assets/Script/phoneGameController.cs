using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class phoneGameController : MonoBehaviour
{
    int wallN = 1;
    bool isRing = false;
    int time = 5;
    public GameObject phone;
    public GameObject timePanel;
    public TextMeshProUGUI timeText;
    public GameObject conversation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isRing == true && Input.GetKeyDown(KeyCode.R))
        {
            phone.GetComponent<Phone>().putdownPhone();
            CancelInvoke();
            timePanel.SetActive(false);
            conversation.GetComponent<ConversationController>().goConversationGu(wallN + 2);
            wallN += 1;
            time = 3;
            isRing = false;
        }
        else if (isRing == true && Input.GetKeyDown(KeyCode.T))
        {
            phone.GetComponent<Phone>().putdownPhone();
            timePanel.SetActive(false);
            CancelInvoke();
            conversation.GetComponent<ConversationController>().goConversationGu(6);
            isRing = false;
        }
    }

    public void phoneRing()
    {
        isRing = true;
        phone.GetComponent<Phone>().takePhone();
        timePanel.SetActive(true);
        InvokeRepeating("timing", 0, 1);
    }

    void timing()
    {
        timeText.text = time.ToString();
        time -= 1;

        if (time < 0)
        {
            CancelInvoke();
            conversation.GetComponent<ConversationController>().goConversationGu(6);
        }
    }
}
