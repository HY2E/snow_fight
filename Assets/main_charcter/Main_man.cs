using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_man : MonoBehaviour
{

    public GameObject obMainMan;
    public GameObject snow;
    public bool attacked = false;
    public bool state = false;
    public Enemy enemy;
    private float spd;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // obMainMan.transform.position = new Vector3(0,0,0);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(enemy.x, enemy.y, enemy.z);
        if (Input.GetKeyDown(KeyCode.A) &&
        ! animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            state = false;
            animator.SetTrigger("attack");
            attacked = true;
            animator.SetBool("move",true);
            
        }
        
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Run")){
            snow.transform.position = Vector3.MoveTowards(snow.transform.position,target, 10f* Time.deltaTime);
            spd = (enemy.x - obMainMan.transform.position.x)/10f* Time.deltaTime-0.2f;
            Invoke("setState",spd);
            
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")){
            snow.transform.position = new Vector3(obMainMan.transform.position.x,obMainMan.transform.position.y,obMainMan.transform.position.z);
            
            
        }        // attacked = false;
    }
    void setState(){
        state = true;
    }
}
