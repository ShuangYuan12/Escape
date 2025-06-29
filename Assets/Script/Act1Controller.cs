using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

enum Act1Status
{
    start,
    black,
    startToBlack,
    blackToCeiling,
    ceilingToBlack
}

public class Act1Controller : MonoBehaviour
{
    public RawImage cover;
    public RawImage startBtn;
    public RawImage ceiling;
    public NPCConversation c;
    //Act1Status act1Status = Act1Status.start;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // switch (act1Status)
        // {
        //     case Act1Status.startToBlack:
        //         GameManager.Fade(cover, Color.black, 2f);
        //         GameManager.Fade(startBtn, Color.black, 2f);
        //         if (cover.color.r < 0.05f)
        //         {
        //             cover.color = Color.black;
        //             startBtn.gameObject.SetActive(false);
        //             Invoke("startC", 1.5f);
        //             act1Status = Act1Status.black;
        //         }
        //         break;

        //     case Act1Status.blackToCeiling:
        //         GameManager.Fade(cover, Color.clear, 2.5f);
        //         if (cover.color.a < 0.05f)
        //         {
        //             cover.gameObject.SetActive(false);
        //         }
        //         break;

        //     case Act1Status.ceilingToBlack:
        //         GameManager.Fade(ceiling, Color.black, 2f);
        //         if (ceiling.color.r < 0.05f)
        //         {
        //             ceiling.color = Color.black;
        //             Invoke("sceneToEscape", 1f);
        //             act1Status = Act1Status.black;
        //         }
        //         break;

        //     default:
        //         break;
        // }
    }

    void startC()
    {
        Debug.Log("conversation");
        ConversationManager.Instance.StartConversation(c);
        ConversationManager.OnConversationEnded += ceilingToBlack;
    }
    
    public void startBtnClick()
    {
        //act1Status = Act1Status.startToBlack;
        cover.DOColor(Color.black, 2);
        startBtn
            .DOColor(Color.black, 2)
            .OnComplete(() =>
            {
                startBtn.gameObject.SetActive(false);
                Invoke("startC", 1.5f);
            });
    }

    public void toCeiling()
    {
        //act1Status = Act1Status.blackToCeiling;
        cover
            .DOFade(0, 1.5f)
            .OnComplete(() => cover.gameObject.SetActive(false));

    }

    public void ceilingToBlack()
    {
        //act1Status = Act1Status.ceilingToBlack;
        ceiling
            .DOColor(Color.black, 2)
            .OnComplete(() => Invoke("sceneToEscape", 1f));
    }

    public void sceneToEscape()
    {
        ConversationManager.OnConversationEnded -= ceilingToBlack;
        SceneManager.LoadScene("Escape");
    }
}
