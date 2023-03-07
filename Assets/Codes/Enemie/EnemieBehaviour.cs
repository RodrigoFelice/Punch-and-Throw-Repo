using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieBehaviour : MonoBehaviour
{
    [Header("Physics")]
    Rigidbody rb;

    [Header("Player Reference")]
    bool canTakeHit = true;
    Transform player;

    [Header("Outside References")]
    Animator anim;
    EnemiePath enemieAI;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        enemieAI = GetComponent<EnemiePath>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (canTakeHit && other.CompareTag("Hit")) TookAHit();

        if (canTakeHit && other.CompareTag("Finish")) enemieAI.HasReachedEndPoint();
    }

    void TookAHit()
    {
        enemieAI.DisableAISystem();
        PushEnemiesRagdoll(transform.position - player.transform.position, player.GetComponent<Strength_Attributes>().punchForce);
        
        canTakeHit = false;
        StartCoroutine(ChangeThisEnemieTag("Enemie",0.5f));
    }

    void PushEnemiesRagdoll(Vector3 direction, float forceToPush)
    {
        anim.enabled = false;
        
        foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>()) 
        {
            direction.y = 0.0f;
            direction.Normalize();
            rb.AddForce(direction * forceToPush, ForceMode.Impulse);
        }
    }

    IEnumerator ChangeThisEnemieTag(string newTagName, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        this.gameObject.tag = newTagName;
    }
  
    public void BeCollectedFromPlayer()
    {
        anim.enabled = true;
        ChangeScale_ChangeKinematic_ResetRotation(true);
        StartCoroutine(ChangeThisEnemieTag("Untagged",0f));
    }

    public void BeThrowedByPlayer()
    {
        ChangeScale_ChangeKinematic_ResetRotation(false);
        StartCoroutine(ChangeThisEnemieTag("EmptyBody",0f));
        PushEnemiesRagdoll(player.forward, player.GetComponent<Strength_Attributes>().throwStrength);

        if(this.gameObject != null)
        {
            Destroy(this.gameObject, 3f);
        }
        else return;
        
    }

    void ChangeScale_ChangeKinematic_ResetRotation(bool kinematicValue)
    {
        rb.isKinematic = kinematicValue;
        this.gameObject.transform.localScale = new Vector3(0.6f,0.6f,0.6f);
        this.gameObject.transform.rotation = Quaternion.identity;
    } 
}
