using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class He : MonoBehaviour
{
    public Animator animator;
    public GameObject conversation;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("walk", true);

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveZ(-5, 2));
        sequence.InsertCallback(1.5f, () => animator.SetBool("walk", false));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
