using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks2021
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private int _damage = 5;


        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IDamagable>(out IDamagable target))
            {
                target.TakeDamage(_damage);
                //Debug.Log("Попал!");
                
            }
            Destroy(gameObject);

        }
    }

}

