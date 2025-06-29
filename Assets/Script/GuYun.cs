using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GuYun : MonoBehaviour
{
    //centerPos(12, 8.903, -8.371) rot(0, 90, 0)
    public Animator animator;
    public GameObject conversation;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("walk", true);

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(new Vector3(12, 8.903f, -8.371f), 2));
        sequence.InsertCallback(1.5f, () => animator.SetBool("walk", false));
        sequence.AppendInterval(0.2f);
        sequence.Append(transform.DORotate(new Vector3(0, 90, 0), 0.5f));
        sequence.AppendInterval(0.2f);
        sequence.AppendCallback(() => conversation.GetComponent<ConversationController>().goConversationGu(2));
    }

}
