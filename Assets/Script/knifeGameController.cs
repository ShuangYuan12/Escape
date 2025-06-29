using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifeGameController : MonoBehaviour
{
    public GameObject knifePrefab;
    public GameObject hint;
    public GameObject conversation;
    private int knifeN = 0;    

    public void creatKnife() {
        knifeN += 1;
        Debug.Log("creat" + knifeN);

        Vector3 pos = new Vector3(2f, 7.5f, -3);
        Quaternion rot = Quaternion.Euler(0, 170, -15);
        GameObject addknife = Instantiate(knifePrefab, pos, rot);
        addknife.transform.SetParent(transform);
    }

    public void hintActive() {
        hint.SetActive(true);
    }

    public void hintHide() {
        hint.SetActive(false);
    }

    public void AfAvoidKnife(){
        conversation.GetComponent<ConversationController>().goConversation(knifeN);
    }

    public void failAvoidKnife(){
        conversation.GetComponent<ConversationController>().goConversation(4);
    }
}
