using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Phone : MonoBehaviour
{
    public AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void passPhone(){
        transform.DOLocalMoveZ(0.4f, 0.7f);
    }

    public void putdownPhone(){
        audioSource.Stop();
        transform.DOLocalMove(new Vector3(-0.0251f, 0.73f, 0.089f), 0.5f);
    }

    public void takePhone(){
        audioSource.Play();
        transform.DOLocalMove(new Vector3(-0.003f, 1.569f, 0.3927f), 0.5f);
        transform.DOLocalRotate(new Vector3(-27.56f, 171.53f, 174.27f), 0.1f);
    }
}
