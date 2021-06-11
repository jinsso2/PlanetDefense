using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator1 : MonoBehaviour
{
    // 상단 생성 스크립트

    public GameObject enemyPrefab;
    GameObject enemyGen1, enemyGen2, enemyGen3, enemyGen4;

    public float RandomX;
    public float RandomY;
    public float maxEnemy;
    public float enemyNum;
    public float time = 0;
    float span = 2.5f;
    float delta = 0;

    void Start()
    {
        enemyGen2 = GameObject.Find("EnemyGenerator2");
        enemyGen3 = GameObject.Find("EnemyGenerator3");
        enemyGen4 = GameObject.Find("EnemyGenerator4");
    }

    // Update is called once per frame
    void Update()
    {
        RandomX = Random.Range(-13, 13);
        time += Time.deltaTime;
        if (time < 10)
        {
            maxEnemy = 10;
        }
        if(time > 20)
        {
            maxEnemy = 20;
            span = 2f;
            enemyGen2.GetComponent<EnemyGenerator2>().span = 2f;
            enemyGen3.GetComponent<EnemyGenerator3>().span = 2f;
            enemyGen4.GetComponent<EnemyGenerator4>().span = 2f;
        }
        if (time > 30)
        {
            maxEnemy = 30;
            span = 1.7f;
            enemyGen2.GetComponent<EnemyGenerator2>().span = 1.5f;
            enemyGen3.GetComponent<EnemyGenerator3>().span = 1.5f;
            enemyGen4.GetComponent<EnemyGenerator4>().span = 1.5f;
        }
        if(time > 40)
        {
            maxEnemy = 40;
        }
        if(time > 50)
        {
            maxEnemy = 50;
            span = 1.5f;
            enemyGen2.GetComponent<EnemyGenerator2>().span = 1.2f;
            enemyGen3.GetComponent<EnemyGenerator3>().span = 1.2f;
            enemyGen4.GetComponent<EnemyGenerator4>().span = 1.2f;
        }
        if (time > 60)
        {
            maxEnemy = 70;
            span = 1f;
            enemyGen2.GetComponent<EnemyGenerator2>().span = 0.7f;
            enemyGen3.GetComponent<EnemyGenerator3>().span = 0.7f;
            enemyGen4.GetComponent<EnemyGenerator4>().span = 0.7f;
        }
        if (time > 70)
        {
            maxEnemy += Time.deltaTime;
            span = 0.5f;
            enemyGen2.GetComponent<EnemyGenerator2>().span = 0.3f;
            enemyGen3.GetComponent<EnemyGenerator3>().span = 0.3f;
            enemyGen4.GetComponent<EnemyGenerator4>().span = 0.3f;
        }

        this.delta += Time.deltaTime;
        if (delta > this.span)
        {
            this.delta = 0;
            if (enemyNum < maxEnemy)
            {
                GameObject go = Instantiate(enemyPrefab) as GameObject;
                go.transform.position = new Vector3(RandomX, 10, 0);
                enemyNum++;
            }
        }
    }
}
