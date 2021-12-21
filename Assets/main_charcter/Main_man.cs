using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_man : MonoBehaviour
{

    public GameObject obMainMan;
    public GameObject snow;
    Vector3 target = new Vector3(400, 0, -10);
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        obMainMan.transform.position = new Vector3(0,0,0);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) &&
        ! animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animator.SetTrigger("attack");
            animator.SetBool("move",true);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Run")){
            snow.transform.position = Vector3.MoveTowards(snow.transform.position,target, 10f* Time.deltaTime);
        }
    }
}
