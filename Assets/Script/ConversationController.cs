using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEngine.UI;
using DG.Tweening;

public class ConversationController : MonoBehaviour
{
    public NPCConversation c3;
    public NPCConversation c31;
    public NPCConversation c32;
    public NPCConversation c33;
    public NPCConversation c3end;
    public NPCConversation cFail;
    public NPCConversation cGate;
    public NPCConversation c4;
    public NPCConversation c41;
    public NPCConversation c4r1;
    public NPCConversation c4r2;
    public NPCConversation c4r3;
    public NPCConversation c4Fail;
    public NPCConversation c5;
    public RawImage mask;
    public GameObject cam;
    public GameObject player;
    public GameObject mrLi;
    public GameObject guyun;
    public GameObject lightball;
    public GameObject originKnife;
    public GameObject knifeGame;
    public GameObject phone;
    public GameObject phoneGame;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.moveEnable(false, false);
        Invoke("startC3", 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDisable()
    {
        ConversationManager.OnConversationEnded -= toBE2;
        ConversationManager.OnConversationEnded -= toBE3;
        ConversationManager.OnConversationEnded -= toTE;
    }

    public void startC3()
    {
        ConversationManager.Instance.StartConversation(c3);
        ConversationManager.OnConversationEnded += Act3GameStart;
    }

    public void maskClear()
    {
        mask.DOFade(0, 1);
    }

    public void maskHalf()
    {
        mask.DOFade(0.9f, 0.5f);
    }

    public void maskHalfToClear()
    {
        mask.DOFade(0, 0.5f);
    }

    public void maskBlack(){
        mask.DOColor(Color.black, 0.2f);
    }

    public void Act3GameStart()
    {
        originKnife.SetActive(false);
        mrLi.SetActive(false);
        knifeGame.GetComponent<knifeGameController>().creatKnife();
    }

    public void Act4GameStart()
    {
        phoneGame.SetActive(true);
        phone.GetComponent<Phone>().putdownPhone();
        GameManager.moveEnable(true, true);
        guyun.transform.SetPositionAndRotation(new Vector3(-1.814f, 8.914f, -5.234f), Quaternion.Euler(0, 90, 0));
        guyun.SetActive(false);
    }

    public void goConversation(int c)
    {
        switch (c)
        {
            case 1:
                ConversationManager.Instance.StartConversation(c31);
                break;
            case 2:
                ConversationManager.Instance.StartConversation(c32);
                break;
            case 3:
                ConversationManager.OnConversationEnded -= Act3GameStart;
                ConversationManager.Instance.StartConversation(c33);
                ConversationManager.OnConversationEnded += turnaround;
                break;
            case 4:
                ConversationManager.Instance.StartConversation(cFail);
                ConversationManager.OnConversationEnded -= Act3GameStart;
                ConversationManager.OnConversationEnded += toBE2;
                break;
            case 5:
                ConversationManager.Instance.StartConversation(c3end);
                ConversationManager.OnConversationEnded += escape3;
                break;
            default:
                break;
        }
    }

    public void goConversationGu(int c)
    {
        switch (c)
        {
            case 1:
                ConversationManager.Instance.StartConversation(c4);
                ConversationManager.OnConversationEnded += guyunActive;
                break;
            case 2:
                ConversationManager.OnConversationEnded -= guyunActive;
                ConversationManager.Instance.StartConversation(c41);
                ConversationManager.OnConversationEnded += Act4GameStart;
                break;
            case 3:
                ConversationManager.OnConversationEnded -= Act4GameStart;
                ConversationManager.Instance.StartConversation(c4r1);
                ConversationManager.OnConversationEnded += playerMove;
                break;
            case 4:
                ConversationManager.Instance.StartConversation(c4r2);
                break;
            case 5:
                phoneGame.SetActive(false);
                player.transform.DORotate(new Vector3(0, -90, 0), 0.2f);
                guyun.SetActive(true);
                ConversationManager.OnConversationEnded -= playerMove;
                ConversationManager.OnConversationEnded += escape4;
                ConversationManager.Instance.StartConversation(c4r3);
                break;
            case 6:
                ConversationManager.Instance.StartConversation(c4Fail);
                ConversationManager.OnConversationEnded -= playerMove;
                ConversationManager.OnConversationEnded += toBE3;
                break;
        }
    }

    public void goConversationHe(int c)
    {
        switch (c)
        {
            case 1:
                ConversationManager.Instance.StartConversation(c5);
                ConversationManager.OnConversationEnded += toTE;
                break;
        }
    }

    public void toBE2()
    {
        mask
            .DOFade(1, 1)
            .OnComplete(() => GameManager.changeScene(Scene.BE2));
    }

    public void toBE3()
    {
        mask
            .DOFade(1, 1)
            .OnComplete(() => GameManager.changeScene(Scene.BE3));
    }

    public void toHE()
    {
        mask
            .DOFade(1, 1)
            .OnComplete(() => GameManager.changeScene(Scene.HE));
    }

    public void toTE()
    {
        mask
            .DOFade(1, 1)
            .OnComplete(() => GameManager.changeScene(Scene.TE));
    }

    public void escape3()
    {
        mrLi.SetActive(false);
        GameManager.moveEnable(true, true);
        ConversationManager.OnConversationEnded -= escape3;
    }

    public void escape4()
    {
        guyun.SetActive(false);
        player.GetComponent<Player>().moveToTop();
        ConversationManager.OnConversationEnded -= escape4;
    }

    public void turnaround()
    {
        GameManager.moveEnable(true, false);
        Invoke("liscared", 2f);
        ConversationManager.OnConversationEnded -= turnaround;

    }

    public void liscared()
    {
        mrLi.transform.SetPositionAndRotation(new Vector3(-0.5f, 5.9f, -5f), Quaternion.Euler(0, 0, 0));
        mrLi.SetActive(true);
        cam.GetComponent<CameraController>().camerarot();
        mrLi.transform.DOMove(new Vector3(0, 5.9f, -3.9f), 0.5f);
    }

    public void gateC()
    {
        ConversationManager.Instance.StartConversation(cGate);
    }

    void guyunActive()
    {
        guyun.SetActive(true);
    }

    void playerMove()
    {
        GameManager.moveEnable(true, true);
    }
}
