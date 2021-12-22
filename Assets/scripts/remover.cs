using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class remover : MonoBehaviour
{
    public GameObject[] arr_circle = new GameObject[136];
    public GameObject[] arr_num = new GameObject[136];
    public bool r_tf = false;
    int[] check_pos_x = new int[18];
    int[] check_pos_y = new int[8];
    int[] arr2remove = new int[136];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 136; i++)
        {
            arr_num[i] = GameObject.Find("make_circle").GetComponent<make_circle>().num_object_number[i];
            arr_circle[i] = GetComponent<make_circle>().num_object_circle[i];

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            r_tf = GameObject.Find("find_value").GetComponent<find_value>().tf;
            if (r_tf == true)
            {
                int i, j, x, y;
                int cnt = 0;
                int sum = 0;
                r_tf = true;
                i = GetComponent<find_value>().plus_xy[0];
                x = i / 8;
                j = GetComponent<find_value>().plus_xy[1];
                y = j / 8;
                if (x > y)
                {
                    for (int a = y; a < x + 1; a++)
                    {
                        check_pos_x[cnt] = a;
                        cnt++;
                    }
                }
                else
                {
                    for (int a = x; a < y + 1; a++)
                    {
                        check_pos_x[cnt] = a;
                        cnt++;
                    }
                }
                cnt = 0;
                x = i % 8;
                y = j % 8;
                if (x > y)
                {
                    for (int a = y; a < x + 1; a++)
                    {
                        check_pos_y[cnt] = a;
                        cnt++;
                    }
                }
                else
                {
                    for (int a = x; a < y + 1; a++)
                    {
                        check_pos_y[cnt] = a;
                        cnt++;
                    }
                }
                int k = 0;
                for (int a = 0; check_pos_x[a] != null; a++)
                {
                    for (int b = 0; check_pos_y[b] != null; b++)
                    {
                        arr2remove[k] = 8 * check_pos_x[a] + check_pos_y[b];
                        k++;
                    }
                }

                for (int a = 0; arr2remove[a] != null; a++)
                {
                    sum = sum + int.Parse(arr_num[arr2remove[a]].GetComponent<TextMesh>().text);
                }
                if (sum == 10)
                {
                    for (int a = 0; arr2remove[a] != null; a++)
                    {
                        arr_circle[arr2remove[a]].SetActive(false);
                    }
                }
            }

        }
    }
}
