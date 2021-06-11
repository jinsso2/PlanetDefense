using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject itemPrefab;

    float delta = 0;
    void Start()
    {

    }

    void Update()
    {
        delta += Time.deltaTime;
        int i = Random.Range(0, 4);
        if (delta > 16)
        {
            delta = 0;
            i++;
            if (i < 4)
            {
                GameObject go = Instantiate(itemPrefab) as GameObject;
                switch (i)
                {
                    case 1:
                        go.transform.position = new Vector3(0, 2.3f, 0);
                        break;
                    case 2:
                        go.transform.position = new Vector3(2.3f, 0, 0);
                        break;
                    case 3:
                        go.transform.position = new Vector3(0, -2.3f, 0);
                        break;
                    case 4:
                        go.transform.position = new Vector3(-2.3f, 0, 0);
                        break;
                }         
            }
        }
    }
}
