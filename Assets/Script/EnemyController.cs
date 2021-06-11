using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int rotateSpeed = 10;
    public float rand;
    public float enemyNum;
    public Transform target;
    GameObject enemyGen1, enemyGen2, enemyGen3, enemyGen4;

    Vector3 targetA = new Vector3(0, 0, 0);
    
    void Start()
    {
        rand = Random.Range(0.08f, 0.28f);
        enemyGen1 = GameObject.Find("EnemyGenerator1");
        enemyGen2 = GameObject.Find("EnemyGenerator2");
        enemyGen3 = GameObject.Find("EnemyGenerator3");
        enemyGen4 = GameObject.Find("EnemyGenerator4");
    }

    void Update()
    {
        // 목표를 바라보게
        if(target != null)
        {
            Vector2 direction = new Vector2(
                transform.position.x - target.position.x,
                transform.position.y - target.position.y
                );
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion angleAxis = Quaternion.AngleAxis(angle - 180f, Vector3.forward);
            Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, rotateSpeed * Time.deltaTime);
            transform.rotation = rotation;
        }
    }

    void FixedUpdate()
    {
        // 목표 지점으로 이동
        transform.position = Vector3.MoveTowards(transform.position, targetA, rand);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Planet")
        {
            Destroy(this.gameObject);
            enemyGen1.GetComponent<EnemyGenerator1>().enemyNum--;
        }
        if(collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
