using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float health = 100;

    [SerializeField] private Text healthUI;

    //public void UpdateHealth()
    //{
    //    healthUI.text = health.ToString("0");
    //}
}
