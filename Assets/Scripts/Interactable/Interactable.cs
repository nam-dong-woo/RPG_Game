using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float size;
    public Transform guideTransform;
    public Transform playerTransform;

    bool isFocus = false;
    bool isInteracted = false;

    public virtual void Interact()
    {

    }

    private void Update() 
    {
        if (isFocus)
        {
            float distance = Vector3.Distance(guideTransform.position,
                playerTransform.position);
          
            if (distance < size)
            {
                isInteracted = true;
                Interact();
            }

        }

    }

    public void OnFocused(Transform tf)
    {
        isFocus = true;
        playerTransform = tf;
        isInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        playerTransform = null;
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(guideTransform.position, size);        
    }
}
