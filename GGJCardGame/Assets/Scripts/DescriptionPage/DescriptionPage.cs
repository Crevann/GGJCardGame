using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(TextMeshPro))]
public class DescriptionPage : MonoBehaviour
{
    [SerializeField] float minWritingSpeed = 0.01f;
    [SerializeField] float maxWritingSpeed = 0.5f;
    [SerializeField] float movementSpeed = 3f;
    [SerializeField] AnimationCurve curve;
    [SerializeField] Vector3 posUp;
    [SerializeField] Vector3 posDown;
    float writingSpeed = 0;
    string stringToWrite = null;
    bool up = true;
    [HideInInspector] public string StringToWrite {
        get { return stringToWrite; }
        set {
            if (value == null) up = false;
            else up = true;
            stringToWrite = value;
            counter = 0;
            t = 0;
            currentString = null;
            textMeshPro.text = null;
        }
    }
    string currentString = null;
    TextMeshPro textMeshPro;
    float t = 0;
    int counter = 0;

    private static DescriptionPage instance;
    public static DescriptionPage Instance {
        get {
            return instance;
        }
    }

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        textMeshPro = GetComponent<TextMeshPro>();
    }
    float CurveWeightedRandom(AnimationCurve curve) {
        return curve.Evaluate(Random.value);
    }
    // Update is called once per frame
    void Update()
    {
        if (stringToWrite != null && !up) {//write
            if((transform.position - posDown).sqrMagnitude > 0.1f) {
                up = true;
                return;
            }
            t += Time.deltaTime;
            if(t >= writingSpeed) {
                t = 0;
                currentString += stringToWrite[counter];
                textMeshPro.text = currentString;
                writingSpeed = Mathf.Lerp(minWritingSpeed, maxWritingSpeed, CurveWeightedRandom(curve));
                counter++;
                if (counter == stringToWrite.Length) stringToWrite = null;
            }
        }
        if(stringToWrite != null && up) {//go down
            t += Time.deltaTime * movementSpeed;
            transform.parent.position = Vector3.Lerp(posUp, posDown, t);
            if(t >= 1) {
                up = false;
                t = 0;
                transform.parent.position = Vector3.Lerp(posUp, posDown, 1);
            }
        }
        if(!up && currentString == null && stringToWrite == null) {
            //goUp
            t += Time.deltaTime * movementSpeed;
            transform.parent.position = Vector3.Lerp(posDown, posUp, t);
            if (t >= 1) {
                up = true;
                t = 0;
            }
        }
    }
}
