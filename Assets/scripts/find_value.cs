using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class find_value : MonoBehaviour
{
    public GameObject[] arr = new GameObject[136];
    GameObject vec;
    public bool tf;
    public double pos_x;
    public double pos_y;
    int x = 0;
    int y = 0;
    int[] plus_xy = new int[2];
    int cnt = 0;
    int order = 0;



    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 136; i++)
        {
            arr[i] = GetComponent<make_circle>().num_object_number[i];

        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
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
                double k = 1.0;
                if (2.0 - k * i <= pos_y && pos_y <= 2.8 - k * i)
                {
                    y = i;
                    continue;
                }
            }

            for (int i = 0; i < 17; i++)
            {
                double k = 1.0;
                if (-8.5 + k * i <= pos_x && pos_x <= -7.5 + k * i)
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
                int a = plus_xy[0];
                int b = plus_xy[1];

                arr_x = int.Parse(arr[a].GetComponent<TextMesh>().text);
                arr_y = int.Parse(arr[b].GetComponent<TextMesh>().text);
                arr[4].GetComponent<TextMesh>().text = (arr_x + arr_y).ToString();
                tf = true;
            }

        }
    }
}

