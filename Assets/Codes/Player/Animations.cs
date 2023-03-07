using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    [Header("Animator")]
    Animator anim;

    [Header("Punch Settings")]
    bool isPunching;
    [SerializeField] float waitTime;
    [SerializeField] GameObject punchCollider;

    
    void Start() => anim = GetComponent<Animator>();

    public void MoveAnimation(Vector3 movement) => anim.SetFloat("Movement",movement.magnitude);
    
    public void CalledPunch()
    {
        if (!isPunching) StartCoroutine(Punch());
    } 


    IEnumerator Punch()
    {
        isPunching = true;
        anim.SetBool("Punching",isPunching);
        yield return new WaitForSeconds(waitTime);
        isPunching = false;
        anim.SetBool("Punching",isPunching);
    }


    public void ActivateCollider() => punchCollider.SetActive(true);
    
    public void DesactivateCollider() => punchCollider.SetActive(false);

}
