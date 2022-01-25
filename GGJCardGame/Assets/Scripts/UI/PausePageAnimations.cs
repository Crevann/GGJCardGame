using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum pageState
{
    start,
    idle,
    standBy,
    active
}

public class PausePageAnimations : MonoBehaviour
{
    [SerializeField]
    private Transform startPosition;
    [SerializeField]
    private Transform idlePosition;
    [SerializeField]
    private Transform activePosition;
    [SerializeField]
    private Transform standByPosition;
    [SerializeField]
    [Range(0.001f, 100)]
    private float transitionSpeed;

    private pageState state;
    private PauseLogic pauseInstance;
    private bool isActive;
    private Transform goalPos;

    [HideInInspector]
    public bool isSelected;

    public pageState State
    {
        get { return state; }
        set
        {
            if (state != value) SwitchState(value);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        isActive = true;
        isSelected = false;
    }

    private void OnEnable()
    {
        transform.position = startPosition.position;
        SwitchState(pageState.idle);
    }

    public void SwitchState(pageState _state)
    {
        state = _state;
        isActive = true;
        switch (state)
        {
            case pageState.start:
                goalPos = startPosition;
                break;
            case pageState.idle:
                goalPos = idlePosition;
                break;
            case pageState.standBy:
                goalPos = standByPosition;
                break;
            case pageState.active:
                goalPos = activePosition;
                break;
        }
    }

    public void ToggleActive()
    {
        isSelected = true;
        if (State == pageState.active)
        {
            State = pageState.idle;
        }

        else if (State == pageState.idle)
        {
            State = pageState.active;   
        }
        
    }

    void MoveTo(Transform target)
    {
        float deltaMove = target.position.y - transform.position.y;
        transform.position += new Vector3(0, Mathf.Sign(deltaMove), 0).normalized * transitionSpeed * Time.deltaTime;
        if (Mathf.Abs(deltaMove) < transitionSpeed * Time.deltaTime)
        {
            transform.position = target.position;
            isActive = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) return; 
        MoveTo(goalPos);
    }
}
