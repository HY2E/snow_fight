using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_man : MonoBehaviour
{

    public GameObject obMainMan;
    public GameObject snow;
    public GameObject obenemy;
    public bool attacked = false;
    public bool state = false;
    public int count = 0;
    private float hit;
    public float x;
    public float distancee;
    public float y;
    public float z;
    private float dest;
    private float spd;
    Vector3 target;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // distancee = obenemy.transform.position.x - obMainMan.transform.position.x;
        x = obenemy.transform.position.x;
        y = obenemy.transform.position.y;
        z = obenemy.transform.position.z;
        target = new Vector3(x,y,z);
        dest = obenemy.transform.position.x+3;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.A) &&
        ! animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            
            state = false;
            animator.SetTrigger("attack");
            attacked = true;
            animator.SetBool("move",true);
            // enemy.attacked = true;
            x = obenemy.transform.position.x;
            y = obenemy.transform.position.y;
            z = obenemy.transform.position.z;
            target = new Vector3(x,y,z);
            count += 1;
            
        }
        
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Run")){
            snow.transform.position = Vector3.MoveTowards(snow.transform.position,target, 10f* Time.deltaTime);
            // spd = (x - obMainMan.transform.position.x)/10f* Time.deltaTime+0.7f;
            // Invoke("setState",spd);
            if(count == 10){
                animator.SetBool("isDie",true);
            }
        }
        
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("HitE")){
            if(count %3 == 0){
                snow.transform.position = new Vector3(obMainMan.transform.position.x,obMainMan.transform.position.y,obMainMan.transform.position.z);    
                obenemy.transform.position = new Vector3(x+1,y,z);
                
            }
            
            
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")){
            snow.transform.position = new Vector3(obMainMan.transform.position.x,obMainMan.transform.position.y,obMainMan.transform.position.z);    
        }attacked = false;

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Die")){
            Invoke("dieenemy",1f);
        }
        
    }
    void dieenemy(){
        Destroy(obenemy);
    }

    public int getCount(){
        return count;
    }

    public bool Attack(){
        return attacked;
    }
}
