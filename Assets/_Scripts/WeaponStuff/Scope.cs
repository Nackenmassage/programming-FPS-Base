using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public Animator animator;
    public GameObject scopeOverlay;
    public GameObject weaponCamera;
    public Camera mainCamera;

    public float scopedFOV = 15f;
    public bool sniperEquipped = false;
    public bool deagleEquipped = false;

    private float normalFOV = 60f;
    private bool isScoped = false;

    private void Update()
    {
        if (sniperEquipped)
        {
            SniperScoped();
        }
        else if (deagleEquipped)
        {
            DeagleScoped();
        }
    }

    private void SniperScoped()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;
            animator.SetBool("IsScoped", isScoped);
        }

        if (isScoped)
        {
            StartCoroutine(OnSniperScoped());
        }
        else
        {
            OnUnscoped();
        }
    }

    IEnumerator OnSniperScoped()
    {
        yield return new WaitForSeconds(.15f);

        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);

        mainCamera.fieldOfView = scopedFOV;
    }

    private void DeagleScoped()
    {

    }

    void OnUnscoped()
    {
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);

        mainCamera.fieldOfView = normalFOV;
    }
}
