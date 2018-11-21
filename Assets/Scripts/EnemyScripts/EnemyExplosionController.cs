using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
public class EnemyExplosionController : MonoBehaviour {

 
    void Start()
    {
        Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
}
}