using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBomb : MonoBehaviour
{
    [SerializeField] private Rigidbody moneyPrefab;
    [SerializeField] private float spawnInterval = 0.5f;
    private MoneyPool pool;

    private float timer;

    private void Start()
    {
        pool = GameObject.Find("MoneyPool").GetComponent<MoneyPool>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            Rigidbody rb = pool.GetNext(transform.position, Quaternion.identity);
            rb.AddForce(Random.insideUnitSphere * 20f, ForceMode.Impulse);
        }
    }
}
