using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float attackSpeed;

    public enum Classification
    {
        Mammal,
        Reptile,
        Aquatic,
    }
    public Classification classification;

    public enum CreatureType
    {
        Minor,
        Major
    }
    public CreatureType creatureType;
    
    [SerializeField] List<GameObject> drops;

    private void OnEnable()
    {
        //Set current room
    }

    private void SpawnDrop(GameObject objToSpawn)
    {
        //Drops the specified object
    }

    private void CalculateStats()
    {
        //Pulls stats from FloorManager based on CreatureType enum
    }
}
