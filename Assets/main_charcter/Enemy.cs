using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject obenemy;
    public Main_man main_man;
    // public bool attacked;
    int cur = 0;
    Animator animator1;

    // Start is called before the first frame update
    void Start()
    {
    

        animator1 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (main_man.Attack()){
            animator1.SetBool("attacked",true);
        }
        
    }
}
