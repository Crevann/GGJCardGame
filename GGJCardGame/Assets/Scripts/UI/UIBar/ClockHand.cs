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
        if (targetRotation != currentRotation) transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space)) {
            PlayerStats.Instance.soul++;
            Rotate();
                }
        if (Input.GetKeyDown(KeyCode.T)) {
            PlayerStats.Instance.soul--;
            Rotate();
                }
    }
    public void Rotate() {
        float a = Mathf.Clamp((float)-PlayerStats.Instance.soul + PlayerStats.Instance.body, -6, 6);
        targetRotation = onlyPositiveTargetRotations[(int)Mathf.Abs(a)];
        if (a < 0) targetRotation.z = onlyPositiveTargetRotations[0].z - targetRotation.z;
        //targetRotation = Quaternion.Lerp(maxRotationSoul, maxRotationBody, a);
        currentRotation = transform.rotation;
    }
}
