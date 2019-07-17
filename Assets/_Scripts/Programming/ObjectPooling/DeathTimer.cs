using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTimer : MonoBehaviour
{
    [SerializeField] private float lifeSpan = 1.5f;

    private float timer;

    private MoneyPool pool;
    public MoneyPool Pool
    {
        set { pool = value; }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= lifeSpan)
        {
            timer = 0f;
            pool.ReturnToPool(GetComponent<Rigidbody>());
        }
    }
}
