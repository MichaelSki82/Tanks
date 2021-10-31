using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tanks2021
{

    internal sealed class PlayerTank : MonoBehaviour
    {
        
        [SerializeField] private float _hp;
        [SerializeField] private Rigidbody _bullet;
        [SerializeField] private Transform _startPosition;
        [SerializeField] private float _speedBullet;
        private float _rotateTower = 0;

      

        Shooting shoot;

        void Start()
        {

                      
            shoot = new Shooting(_startPosition, _bullet, _speedBullet);
                        
        }

    
        void Update()
        {
           

            if (Input.GetKeyDown(KeyCode.Space))
            {

                shoot.Shoot();
                
            }

            //void RotatesTower()
            //{
                
            //    //поворот башни 
                
            //    AngleRotate = Time.deltaTime * RotateSpeed * Input.GetAxis("Mouse X");
                

            //    //после поворота башни обнуляем значнеие 
            //    RotateTower = 0;
            //}
        }
    }
}
