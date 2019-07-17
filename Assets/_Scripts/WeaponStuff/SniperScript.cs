using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SniperScript : MonoBehaviour
{
    [SerializeField] private CameraShake cameraShake;
    [SerializeField] private Scope scope;
    [SerializeField] private Camera fpsCam;
    [SerializeField] private GameObject impactEffect;
    [SerializeField] private AudioSource barrettSound;
    [SerializeField] private AudioClip barrettSoundClip;
    [SerializeField] private Text magazineSizeText;

    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 100f;
    [SerializeField] private float impactForce = 60f;
    [SerializeField] private float shootingTimer = 2f;
    [SerializeField] private float ammunition = 6f;

    private IEnumerator reloadingCoroutine;

    private bool reloading = false;

    private void Start()
    {
        barrettSound = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        scope.sniperEquipped = true;
    }

    private void OnDisable()
    {
        scope.sniperEquipped = false;
    }

    private void Update()
    {
        
        shootingTimer -= Time.deltaTime;
        ReloadingUpdate();
        ShootingUpdate();
        UITextUpdate();
    }

    private void ReloadingUpdate()
    {
        if (Input.GetButtonDown("Reload"))
        {
            reloadingCoroutine = Reloading();
            StartCoroutine(reloadingCoroutine);
        }
    }

    private IEnumerator Reloading()
    {
        reloading = true;
        yield return new WaitForSeconds(3f);
        reloading = false;
        ammunition = 6f;
    }

    private void ShootingUpdate()
    {
        if (Input.GetButtonDown("Fire1") && shootingTimer <= 0 && ammunition > 0)
        {
            Shoot();
            cameraShake.Shake(0.15f, 0.2f);
            barrettSound.PlayOneShot(barrettSoundClip);
            shootingTimer = 2f;
            ammunition--;
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }

    private void UITextUpdate()
    {
        if (reloading)
        {
            magazineSizeText.text = "Reloading";
        }
        else
        {
            magazineSizeText.text = ammunition.ToString() + "/6";
        }
    }
}
