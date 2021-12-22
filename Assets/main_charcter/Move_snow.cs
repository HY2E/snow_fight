using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_snow : MonoBehaviour
{
    public GameObject snow;
    Vector3 target = new Vector3(-100, -100f, -10);
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {
            transform.position = Vector3.MoveTowards(transform.position,target, 2f* Time.deltaTime);
        }
    }
}
