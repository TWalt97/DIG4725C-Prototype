using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LimbPickupData", menuName = "Limb Pickup Data")]

public class LimbPickupData : ScriptableObject
{
    public string limbName;
    public string description;
    public int health;
    public GameObject gameObject;

    enum LimbType
    {
        Head, LeftArm, RightArm, Legs
    }

    [SerializeField]
    LimbType limbType = new LimbType();


}
