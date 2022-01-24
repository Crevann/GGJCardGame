using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockHand : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 3;
    [SerializeField] Quaternion maxRotationSoul, maxRotationBody;
    Quaternion currentRotation;
    Quaternion targetRotation;
    void Start()
    {
        targetRotation = currentRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetRotation != currentRotation) transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    public void Rotate() {
        float a = (((float)-PlayerStats.Instance.soul + PlayerStats.Instance.body + 6) / 12);
        targetRotation = Quaternion.Lerp(maxRotationSoul, maxRotationBody, a);
        currentRotation = transform.rotation;
    }
}
