using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateThingsSystem : MonoBehaviour
{
    
    public void CreatePrefabObject(GameObject newItem, Transform newItem_Position)
    {
        Vector3 newPosition = new Vector3(newItem_Position.position.x, this.gameObject.transform.position.y, newItem_Position.position.z);
        Instantiate(newItem, newPosition , this.gameObject.transform.rotation);
    }
}
