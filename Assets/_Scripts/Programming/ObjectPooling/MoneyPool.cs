using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPool : MonoBehaviour
{
    [SerializeField] private Rigidbody moneyPrefab;
    [SerializeField] private int maxCapacity = 92;
    private Stack<Rigidbody> money;
    private float numNewSpawns;

    void Awake()
    {
        money = new Stack<Rigidbody>(maxCapacity);
        for (int i = 0; i < maxCapacity; i++)
        {
            Rigidbody rb = Instantiate(moneyPrefab);
            rb.gameObject.SetActive(false);
            money.Push(rb);
            rb.GetComponent<DeathTimer>().Pool = this;
        }
    }

    public Rigidbody GetNext(Vector3 pos, Quaternion rot)
    {
        Rigidbody rb;
        if (money.Count != 0)
        {
            rb = money.Pop();
        }
        else
        {
            print("instantiated new cube" + numNewSpawns++);
            rb = Instantiate(moneyPrefab);
            rb.GetComponent<DeathTimer>().Pool = this;
        }
        rb.transform.position = pos;
        rb.transform.rotation = rot;
        rb.gameObject.SetActive(true);
        return rb;
    }

    public void ReturnToPool(Rigidbody rb)
    {
        rb.gameObject.SetActive(false);
        rb.velocity = Vector3.zero;
        rb.transform.position = Vector3.zero;
        rb.transform.rotation = Quaternion.identity;
        money.Push(rb);
    }
}
