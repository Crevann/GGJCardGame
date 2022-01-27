using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    Animator anim;
    [SerializeField] Sprite cardBack;
    [SerializeField] float movementSpeed = 3;
    [SerializeField] Quaternion minRot, maxRot;
    protected Quaternion targetRot;
    protected Vector3 targetPos = Vector3.zero;
    protected bool thenDisable;

    // Start is called before the first frame update
    public virtual void Start()
    {
        if(targetPos == Vector3.zero) targetPos = transform.position;
        targetRot = transform.rotation;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (targetRot != transform.rotation) 
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, movementSpeed * Time.deltaTime);
        if ((targetPos - transform.position).sqrMagnitude > 0.01f) {
            transform.position = Vector3.Lerp(transform.position, targetPos, movementSpeed * Time.deltaTime);
         
        } else if (thenDisable) gameObject.SetActive(false);
    }
    public void MoveTo(Vector3 pos, bool thenDisable = false, bool rotate = false) {
        this.thenDisable = thenDisable;
        
        targetPos = pos;
        if (rotate) targetRot = Quaternion.Lerp(minRot, maxRot, Random.Range(0.0f, 1f));
        //TODO animation
    }

    public void RotateTo(Quaternion rot) {
        targetRot = rot;
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
