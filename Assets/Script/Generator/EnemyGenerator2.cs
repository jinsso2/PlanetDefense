using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator2 : MonoBehaviour
{
    // 상단 생성 스크립트

    public GameObject enemyPrefab;
    GameObject enemyMax;

    public float RandomX;
    public float RandomY;
    public float maxEnemy;
    public float time = 0;
    public float span = 2.5f;
    float delta = 0;

    void Start()
    {
        enemyMax = GameObject.Find("EnemyGenerator1");
    }

    // Update is called once per frame
    void Update()
    {
        RandomY = Random.Range(-10, 10);
        time += Time.deltaTime;
        

        this.delta += Time.deltaTime;
        if (delta > this.span)
        {
            this.delta = 0;
            if (enemyMax.GetComponent<EnemyGenerator1>().enemyNum < enemyMax.GetComponent<EnemyGenerator1>().maxEnemy)
            {
                GameObject go = Instantiate(enemyPrefab) as GameObject;
                go.transform.position = new Vector3(13, RandomY, 0);
                enemyMax.GetComponent<EnemyGenerator1>().enemyNum++;
            }
        }
    }
}
