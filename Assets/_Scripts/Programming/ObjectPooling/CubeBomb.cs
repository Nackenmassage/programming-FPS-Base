using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBomb : MonoBehaviour
{
    [SerializeField] private Rigidbody moneyPrefab;
    [SerializeField] private float spawnInterval = 0.5f;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnInterval)
        {
            timer = 0;
            Rigidbody rb = Instantiate(moneyPrefab, transform.position, Quaternion.identity);
            rb.AddForce(Random.insideUnitSphere * 20f, ForceMode.Impulse);
        }
    }
}
