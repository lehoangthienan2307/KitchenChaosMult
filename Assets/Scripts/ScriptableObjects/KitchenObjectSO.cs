using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class KitchenObjectSO : ScriptableObject
{
    //just read no write so dont have to be private 

    public Transform prefab;
    public Sprite sprite;
    public string objectName;
}
