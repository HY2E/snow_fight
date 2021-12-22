using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class find_value : MonoBehaviour
{

    public GameObject[] arr_circle = new GameObject[136];
    public GameObject[] arr_num = new GameObject[136];
    GameObject vec;
    public bool tf = false;
    public double pos_x;
    public double pos_y;
    int x = 0;
    int y = 0;
    public int[] plus_xy = new int[2];
    public int cnt = 0;
    int order = 0;
    int[] check_pos_x = new int[17];
    int[] check_pos_y = new int[8];
    int[] arr2remove = new int[136];
    int hy = 0;




    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 136; i++)
        {
            arr_num[i] = GetComponent<make_circle>().num_object_number[i];
            arr_circle[i] = GetComponent<make_circle>().num_object_circle[i] as GameObject;

        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
            tf = false;
            vec = GameObject.Find("get_object");
            pos_x = vec.GetComponent<get_object>().MousePosition.x;
            pos_y = vec.GetComponent<get_object>().MousePosition.y;
            tf = false;

            if (cnt == 2)
            {
                cnt = 0;
                order = 0;
            }
            for (int i = 0; i < 8; i++)
            {
                double k_y = 1.0;
                if (2.0 - k_y * i <= pos_y && pos_y <= 2.8 - k_y * i)
                {
                    y = i;
                    continue;
                }
            }

            for (int i = 0; i < 17; i++)
            {
                double k_x = 1.0;
                if (-8.5 + k_x * i <= pos_x && pos_x <= -7.5 + k_x * i)
                {
                    x = i;
                    continue;
                }
            }
            plus_xy[order] = (8 * x) + y;
            order++;
            cnt++;
            if (cnt == 2)
            {

                int arr_x, arr_y;
                int m = plus_xy[0];
                int n = plus_xy[1];

                int position = 0;

                arr_x = int.Parse(arr_num[m].GetComponent<TextMesh>().text);
                arr_y = int.Parse(arr_num[n].GetComponent<TextMesh>().text);


                int x_s, x_e, y_s, y_e, dir_x, dir_y;
                int cnt_t = 0;
                int sum = 0;

                x_s = m / 8;
                x_e = n / 8;
                dir_x = x_e - x_s;
                y_s = m % 8;
                y_e = n % 8;
                dir_y = y_e - y_s;
                if (dir_x > 0)
                {
                    dir_x = 1;
                }
                else
                {
                    dir_x = -1;
                }
                if (dir_y > 0)
                {
                    dir_y = 1;
                }
                else if (dir_y < 0)
                {
                    dir_y = -1;
                }

                else
                {
                    hy = 0;
                    while (x_s != x_e + dir_x)
                    {
                        sum += int.Parse(arr_num[x_s * 8 + y_s].GetComponent<TextMesh>().text);
                        arr2remove[hy] = x_s * 8 + y;
                        x_s += dir_x;
                        hy++;
                    }
                }
                if (sum == 0)
                {
                    hy = 0;
                    while (x_s != x_e + dir_x)
                    {
                        int y = y_s;
                        while (y != y_e + dir_y)
                        {
                            sum += int.Parse(arr_num[x_s * 8 + y].GetComponent<TextMesh>().text);
                            arr2remove[hy] = x_s * 8 + y;
                            y = y + dir_y;
                            hy++;
                        }
                        x_s += dir_x;
                    }
                }

                if (sum == 10)
                {
                    for (int tmp = 0; tmp < hy; tmp++)
                    {
                        arr_circle[arr2remove[tmp]].GetComponent<Renderer>().enabled = false;
                        arr_num[arr2remove[tmp]].GetComponent<TextMesh>().text = "0";
                        arr_num[arr2remove[tmp]].GetComponent<Renderer>().enabled = false;

                    }
                    sum = 0;
                    tf = true;
                }
                sum = 0;

            }

        }
    }
}

