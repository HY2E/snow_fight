using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject obenemy;
    public Main_man main_man;
    public float x;
    public float y;
    public float z;
    
    // Start is called before the first frame update
    void Start()
    {
        x = obenemy.transform.position.x;
        y = obenemy.transform.position.y;
        z = obenemy.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        x = obenemy.transform.position.x;
        y = obenemy.transform.position.y;
        z = obenemy.transform.position.z;
        Vector3 target = new Vector3(100, obenemy.transform.position.y, -10);
        if(main_man.state&&main_man.attacked){
            // obenemy.transform.position = Vector3.MoveTowards(obenemy.transform.position,target, 1f* Time.deltaTime);
            obenemy.transform.position = new Vector3(obenemy.transform.position.x+1,obenemy.transform.position.y,obenemy.transform.position.z);
            // obenemy.transform.Translate(new Vector3(-1,1,1)*Time.deltaTime);
            main_man.attacked = false;
        }
    }
}
