using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 사용자의 인풋을 시스템에 적용하는 부분

    public delegate void OnFocusChanged(Interactable newFocus);
    public OnFocusChanged onFocusChanged;

    Camera cam;
   
    Animator animator;
   

    PlayerMotor motor;
    CharacterCombat combat;

    public LayerMask movementMask;
    public LayerMask interactionMask;

    public Interactable focus;

    private void Awake() 
    {
        cam = Camera.main;
        animator = GetComponentInChildren<Animator>();
        motor = GetComponent<PlayerMotor>();
        combat = GetComponent<CharacterCombat>();
    }
 
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, movementMask))
            {
                motor.MoveToTarget(hit.point);          
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, interactionMask))
            {
                SetFocus(hit.collider.GetComponent<Interactable>());            
            }
        } 
    }

    void SetFocus(Interactable newFocus)
    {
        onFocusChanged?.Invoke(newFocus);

        if (focus != newFocus && focus != null)
        {
            focus.OnDefocused();
        }

        focus = newFocus;

        if (focus != null)
        {
            focus.OnFocused(transform);
        }
    }       
}
