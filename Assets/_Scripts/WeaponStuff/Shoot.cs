using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    [System.Serializable]
    public class GunSettings
    {
        public float bulletSpeed = 100f;
        public float magazineSize = 20f;
        public float shootingTimer = 0.2f;
    }

    GunSettings gunSettings = new GunSettings();

    bool reloadInput, burstFireInput, singleFireInput, fireStanceInput;
    bool fireStance;

    public AudioClip deagleShotClip;

    [SerializeField] CameraShake cameraShake;
    [SerializeField] private Animation CameraShakeAnimation;
    [SerializeField] private Rigidbody projectile;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private AudioSource deagleShotSound;

    [SerializeField] Text FireStanceText;
    [SerializeField] Text MagazineSizeText;

    private Animation DeagleShotAnimation;
    private AnimationClip animClip;

    private void Awake()
    {
        DeagleShotAnimation = gameObject.GetComponent<Animation>();
        deagleShotSound = gameObject.GetComponent<AudioSource>();
    }

    private void Start()
    {
        reloadInput = false;
        fireStance = false;
    }

    private void Update()
    {
        Shooting();
        Reloading();
        GetInput();
    }

    private void Shooting()
    {
        if (fireStanceInput)
        {
            fireStance = !fireStance;
        }

        gunSettings.shootingTimer -= Time.deltaTime;

        if (singleFireInput && gunSettings.magazineSize > 0 && gunSettings.shootingTimer <= 0)
        {
            Rigidbody clone;
            clone = Instantiate(projectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation);

            clone.velocity = transform.TransformDirection(Vector3.right * gunSettings.bulletSpeed);

            DeagleShotAnimation.Play();
            cameraShake.Shake(0.15f, 0.2f);
            deagleShotSound.PlayOneShot(deagleShotClip);

            gunSettings.magazineSize -= 1;
            gunSettings.shootingTimer = 0.2f;
        }
        else if (burstFireInput && gunSettings.magazineSize > 0 && gunSettings.shootingTimer <= 0)
        {
            Rigidbody clone;
            clone = Instantiate(projectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation);

            clone.velocity = transform.TransformDirection(Vector3.right * gunSettings.bulletSpeed);

            DeagleShotAnimation.Play();
            cameraShake.Shake(0.15f, 0.2f);
            deagleShotSound.PlayOneShot(deagleShotClip);


            gunSettings.magazineSize -= 1;
            gunSettings.shootingTimer = 0.4f;
        }

        MagazineSizeText.text = gunSettings.magazineSize + "/20";
    }

    private void Reloading()
    {
        if (reloadInput)
        {
            gunSettings.magazineSize = 20f;
        }
    }

    private void GetInput()
    {
        reloadInput = Input.GetKeyDown("r");
        fireStanceInput = Input.GetKeyDown("u");

        if (!fireStance)
        {
            singleFireInput = Input.GetMouseButtonDown(0);
            FireStanceText.text = "Single-Fire";
        }
        else
        {
            burstFireInput = Input.GetMouseButton(0);
            FireStanceText.text = "Full-Auto";
        }
    }
}
