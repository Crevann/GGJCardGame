using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepAudio : MonoBehaviour
{
    static public KeepAudio instance;
    private void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this){
            Destroy(gameObject);
        }
    }
}
