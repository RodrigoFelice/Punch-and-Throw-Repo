using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Detection : MonoBehaviour
{
   [SerializeField] GameObject containerReference;
    bool canGetEnemies;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Money"))
        {
            Destroy(other.gameObject);
            GetComponent<Money_System>().ChangeAmountOfMoney(10);
        }

        if (other.CompareTag("Enemie"))
        {
            canGetEnemies = containerReference.GetComponent<ContainerSettings>().CanGetMoreEnemiesAtTheStack();
            
            if (canGetEnemies)
            {
                other.GetComponent<EnemieBehaviour>().BeCollectedFromPlayer();
                containerReference.GetComponent<ContainerOfEnemies>().GotAnEnemy(other.gameObject);
            }
        }
    }
}
