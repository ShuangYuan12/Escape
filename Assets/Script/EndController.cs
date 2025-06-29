using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndController : MonoBehaviour
{
    public GameObject mrHe;
    public GameObject mrLi;
    public GameObject guyun;
    public GameObject knife;
    public RawImage gate;
    public RawImage clinic;
    public TextMeshProUGUI text;
    public GameObject btn;
    public NPCConversation cBE2;
    public NPCConversation cBE3;
    public NPCConversation cHE;
    public NPCConversation cTE;

    // Start is called before the first frame update
    void Start()
    {
        switch (GameManager.endScene)
        {
            case Scene.BE1:
                break;
            case Scene.BE2:
                BE2();
                break;
            case Scene.BE3:
                BE3();
                break;
            case Scene.TE:
                TE();
                break;
            case Scene.HE:
                HE();
                break;
            default:
                break;
        }
    }

    void BE2()
    {
        gate.gameObject.SetActive(true);
        text.text = "BAD END";
        ConversationManager.Instance.StartConversation(cBE2);
        ConversationManager.OnConversationEnded += BE2end;
    }

    void BE3()
    {
        gate.gameObject.SetActive(true);
        text.text = "BAD END";
        ConversationManager.Instance.StartConversation(cBE3);
        ConversationManager.OnConversationEnded += BE3end;
    }

    void HE()
    {
        gate.gameObject.SetActive(true);
        text.text = "HAPPY END";
        ConversationManager.Instance.StartConversation(cHE);
        ConversationManager.OnConversationEnded += HEend;
    }

    void TE()
    {
        clinic.gameObject.SetActive(true);
        text.text = "TRUE END";
        clinic
            .DOColor(Color.white, 1)
            .OnComplete(() =>
             {
                 ConversationManager.Instance.StartConversation(cTE);
                 ConversationManager.OnConversationEnded += TEend;
             });
    }

    public void gateAppear()
    {
        gate.DOColor(Color.white, 1);
    }

    void btnAppear()
    {
        btn.SetActive(true);
    }

    public void BE2end()
    {
        mrLi.SetActive(false);
        knife.SetActive(false);
        gate
            .DOColor(Color.black, 1.5f)
            .OnComplete(() => text.DOFade(1, 0.5f));

        Invoke("btnAppear", 3.5f);
        ConversationManager.OnConversationEnded -= BE2end;
    }

    public void BE3end()
    {
        guyun.SetActive(false);
        knife.SetActive(false);
        gate
            .DOColor(Color.black, 1.5f)
            .OnComplete(() => text.DOFade(1, 0.5f));

        Invoke("btnAppear", 3.5f);
        ConversationManager.OnConversationEnded -= BE3end;
    }

    public void HEend()
    {
        mrHe.SetActive(false);
        gate
            .DOColor(Color.black, 1.5f)
            .OnComplete(() => text.DOFade(1, 0.5f));

        Invoke("btnAppear", 3.5f);
        ConversationManager.OnConversationEnded -= HEend;
    }

    public void TEend()
    {
        clinic
            .DOColor(Color.black, 1.5f)
            .OnComplete(() => text.DOFade(1, 0.5f));

        Invoke("btnAppear", 3.5f);
        ConversationManager.OnConversationEnded -= TEend;
    }

    public void backToStart()
    {
        SceneManager.LoadScene("Start");
    }

}
