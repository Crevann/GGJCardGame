using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    Animator anim;
    [SerializeField] Sprite cardBack;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void InGame()
    {
        //shows itself to be choosen
    }

    public virtual void FlipCard()
    {
        anim.SetTrigger("flip");
    }

}
