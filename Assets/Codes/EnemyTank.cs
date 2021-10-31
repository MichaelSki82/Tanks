using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks2021
{
    public class EnemyTank : MonoBehaviour
    {
        [SerializeField] private float _hp;
        [SerializeField] private Rigidbody _bullet;
        [SerializeField] private Transform _startPosition;
        [SerializeField] private float _speedBullet;
        
        private float _pause = 3f;
      
        Shooting shoot;

        void Start()
        {

            
            shoot = new Shooting(_startPosition, _bullet, _speedBullet);

        }


        void Update()
        {


            if (Input.GetKeyDown(KeyCode.Space) && !IsInvoking("ShootEnemyTank"))
            {

                Invoke("ShootEnemyTank", _pause);
                                

            }

            
        }
        void ShootEnemyTank()
        {
            
            shoot.Shoot();
        }
    }
}


