using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeController : MonoBehaviour
{
    private float shakeTimeRemaining;
    private float shakePower;
    private float shakeFadeTime;

    private float shakeRotation;
    [SerializeField]
    private float rotationMultiplier;

    public void StartShake(float length, float power)
    {
        shakeTimeRemaining = length;
        shakePower = power;

        shakeFadeTime = power / length;

        shakeRotation = power * rotationMultiplier;
    }

    private void LateUpdate()
    {
        if (shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;

            float xShakeAmount = Random.Range(-1, 1) * shakePower;
            float yShakeAmount = Random.Range(-1, 1) * shakePower;

            transform.position += new Vector3(xShakeAmount, yShakeAmount, 0);

            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeTime * Time.deltaTime);

            shakeRotation = Mathf.MoveTowards(shakeRotation, 0f, shakeFadeTime * rotationMultiplier * Time.deltaTime);
        }

        transform.rotation = Quaternion.Euler(0f,0f, shakeRotation * Random.Range(-1, 1));
    }


}
