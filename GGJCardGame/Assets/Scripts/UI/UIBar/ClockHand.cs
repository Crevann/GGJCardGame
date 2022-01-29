using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockHand : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 3;
    //[SerializeField] Quaternion maxRotationSoul, maxRotationBody;
    Quaternion currentRotation;
    [SerializeField] Quaternion targetRotation;
    [SerializeField] Quaternion[] onlyPositiveTargetRotations = new Quaternion[7];
    void Start()
    {
        targetRotation = currentRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetRotation != currentRotation) 
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    public void Rotate() {
        float a = Mathf.Clamp((float)-PlayerStats.soul + PlayerStats.body, -6, 6);
        int i = (int)Mathf.Abs(a);
        targetRotation = onlyPositiveTargetRotations[i];
        if (a < 0) targetRotation.z = onlyPositiveTargetRotations[0].z - targetRotation.z;
        //targetRotation = Quaternion.Lerp(maxRotationSoul, maxRotationBody, a);
        currentRotation = transform.rotation;
    }
}
