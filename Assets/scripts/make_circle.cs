using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class make_circle : MonoBehaviour
{
    public GameObject[] num_object_circle = new GameObject[136];
    public GameObject[] num_object_number = new GameObject[136];
    public GameObject Circle;
    public GameObject num;




    // Start is called before the first frame update
    void Start()
    {
        int j = 0;
        int k = 0;
        for (int i = 0; i < 136; i++)
        {
            if (i % 8 == 0 && i != 0)
            {
                j++;
                k = 0;
            }
            k = i % 8;
            if (i == 0)
            {
                continue;
            }
            num_object_circle[i] = (GameObject)Instantiate(Circle, new Vector2((float)-8.01 + j, (float)(2.52 - k)), Quaternion.identity);
        }

        j = 0;
        k = 0;
        for (int i = 0; i < 136; i++)
        {
            if (i % 8 == 0 && i != 0)
            {
                j++;
                k = 0;
            }
            k = i % 8;
            if (i == 0)
            {
                continue;
            }
            num_object_number[i] = Instantiate(num, new Vector2((float)-8.01 + j, (float)(2.52 - k)), Quaternion.identity);
        }




    }

    // Update is called once per frame
    void Update()
    {



    }
}
