using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerHealth;

public class MonsterRespawn : MonoBehaviour
{
    public GameObject monsterPrefab;
    public float respawnTime = 3f;

    private void Start(){
        SpawnMonster();
    }

    private void SpawnMonster()
        { GameObject monster = Instantiate(monsterPrefab, transform.position, Quaternion.identity); 
        monster.GetComponent<Health>().OnDeath += RespawnMonster;}

    private void RespawnMonster(GameObject deadMonster)
    {
        Invoke("SpawnMonster", respawnTime);
    }
   
}   