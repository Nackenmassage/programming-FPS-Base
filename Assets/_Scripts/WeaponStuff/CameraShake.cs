using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;

    private Vector3 originalPos;
    private float timeAtCurrentFrame;
    private float timeAtLastFrame;
    private float fakeDelta;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        timeAtCurrentFrame = Time.realtimeSinceStartup;
        fakeDelta = timeAtCurrentFrame - timeAtLastFrame;
        timeAtLastFrame = timeAtCurrentFrame;
    }

    public void Shake (float duration, float amount)
    {
        instance.originalPos = instance.gameObject.transform.localPosition;
        instance.StopAllCoroutines();
        instance.StartCoroutine(instance.cShake(duration, amount));
    }

    public IEnumerator cShake(float duration, float amount)
    {
        float endTime = Time.time + duration;

        while(duration > 0)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * amount;

            duration -= fakeDelta;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
