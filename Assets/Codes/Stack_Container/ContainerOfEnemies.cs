using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerOfEnemies : MonoBehaviour
{
    [Header("Stack Settings")]
    Transform container; 
    [SerializeField] float verticalSpacing = 0.5f; 
   
    [Header("Stack List")]
    public List<GameObject> enemiesStack = new List<GameObject>();

    [Header("Player Stack Child")]
    Vector3 nextPosition;
    [SerializeField] Transform playerContainerReference;

    [Header("Follow Attributes")]
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float followSpeed = 0.5f;
    

    void Start() => container = this.gameObject.transform;   

    void Update()
    {
        nextPosition = playerContainerReference.position;
        transform.rotation = playerContainerReference.rotation;

        if (Vector3.Distance(transform.position, nextPosition) > 0)
        {
            transform.position = Vector3.Lerp(transform.position, nextPosition, followSpeed * Time.deltaTime * moveSpeed);
        }
        else transform.position = nextPosition;
    }

    public void GotAnEnemy(GameObject enemieGot)
    {
        Vector3 newPosition = container.position + Vector3.up * verticalSpacing * container.childCount;
        enemieGot.transform.SetParent(container);
        enemieGot.transform.position = newPosition;

        enemiesStack.Add(enemieGot);
    }

    public void ThrowEnemie()
    {
        if(enemiesStack.Count > 0)
        {
            int index = enemiesStack.Count - 1;
            enemiesStack[index].transform.SetParent(null);
            enemiesStack[index].GetComponent<EnemieBehaviour>().BeThrowedByPlayer();
            enemiesStack.RemoveAt(index);
        }
    }  
    
}
