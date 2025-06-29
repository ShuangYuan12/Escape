using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity += Vector3.right * -1 * speed * Time.deltaTime;

        if (transform.position.x <= 1.5f && transform.position.x >= 0.1f)
        {
            transform.parent.GetComponent<knifeGameController>().hintActive();

            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("R");
                transform.parent.GetComponent<knifeGameController>().AfAvoidKnife();
                transform.parent.GetComponent<knifeGameController>().hintHide();
                Destroy(gameObject);
            }
        }

        else if (transform.position.x < 0.1f)
        {
            Debug.Log("fail");
            transform.parent.GetComponent<knifeGameController>().hintHide();
            transform.parent.GetComponent<knifeGameController>().failAvoidKnife();

            Destroy(gameObject);
        }
    }

    public void knifeFly(){
        transform
            .DOMoveX(0.25f, 0.3f);
            //.OnComplete(() => Destroy(gameObject));
    }
}
