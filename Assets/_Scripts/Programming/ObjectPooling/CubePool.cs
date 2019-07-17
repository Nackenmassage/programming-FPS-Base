using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    [SerializeField] private Rigidbody moneyPrefab;
    private Stack<Rigidbody> money = new Stack<Rigidbody>(24);

    void Awake()
    {
        for (int i = 0; i < money.Count; i++)
        {
            print(i);
        }
    }

    void Update()
    {
        
    }
}
