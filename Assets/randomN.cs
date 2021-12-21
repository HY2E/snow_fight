using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomN : MonoBehaviour
{
    public TextMesh num;
    private int rnum;
    // Start is called before the first frame update
    void Start()
    {

        rnum = Random.Range(1, 10);
        num.text = rnum.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
