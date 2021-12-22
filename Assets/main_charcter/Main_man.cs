using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_man : MonoBehaviour
{

    public GameObject obMainMan;
    public GameObject snow;
    public GameObject eattack;
    public GameObject obenemy;
    public bool attacked = false;
    public bool eattacked = false;
    public int count = 0;
    public int ecount = 0;
    public float x;
    public float y;
    public float z;
    public float ex;
    public float ey;
    public float ez;
    float timer;
    int watingTime;
    Vector3 target;
    Vector3 etarget;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // distancee = obenemy.transform.position.x - obMainMan.transform.position.x;
        x = obenemy.transform.position.x;
        y = obenemy.transform.position.y;
        z = obenemy.transform.position.z;
        ex = obMainMan.transform.position.x;
        ey = obMainMan.transform.position.y;
        ez = obMainMan.transform.position.z;
        timer = 0;
        watingTime = 10;
        target = new Vector3(x,y,z);
        etarget = new Vector3(ex,ey,ez);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // 공격 패턴 바꾸기 Input 지우고 대체
        if (Input.GetKeyDown(KeyCode.A) &&
        ! animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
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
        if (timer > watingTime &&
        ! animator.GetCurrentAnimatorStateInfo(0).IsName("EAttack"))
        {    
            animator.SetTrigger("eattack");
            eattacked = true;
            // enemy.attacked = true;
            ex = obMainMan.transform.position.x;
            ey = obMainMan.transform.position.y;
            ez = obMainMan.transform.position.z;
            etarget = new Vector3(ex,ey,ez);
            ecount += 1;
            timer = 0;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("ERun")){
            eattack.transform.position = Vector3.MoveTowards(eattack.transform.position,etarget, 10f* Time.deltaTime);
            if(ecount == 10){
                animator.SetBool("pDie",true);
            }
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Hit")){
            if(ecount %3 == 0){
                obenemy.transform.position = new Vector3(x,y,z);
                eattack.transform.position = new Vector3(x,y,z);
                obMainMan.transform.position = new Vector3(ex-1,ey,ez);   
            }
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")){
            eattack.transform.position = new Vector3(obenemy.transform.position.x,obenemy.transform.position.y,obenemy.transform.position.z);    
        }eattacked = false;
        
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("PDie")){
            Invoke("dieplayer",1f);
        }
    }
    
    void dieenemy(){
        Destroy(obenemy);
    }
    void dieplayer(){
        Destroy(obMainMan);
    }

}
