using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks2021
{
    public class EnemyTank : MonoBehaviour, IDamagable, ITakeTurns
    {
        public event Action TurnesChanged;

        [SerializeField] private int _maxHp = 10; // хп сделал int
        [SerializeField] private int _hp;
        
        [SerializeField] private Rigidbody _bullet;
        [SerializeField] private Transform _startPosition;
        [SerializeField] private float _speedBullet;

        private DirectionTurner _turretTurner;
        
        private float _pause = 1f;
      
        private Shooting shoot;
        float _fireRate = 3f;
        float _currentTime = 3f;

        private Transform _target;
        [SerializeField] private Transform _tower;


        private bool _myTurn;
        public bool GetCondition() => _myTurn;



        void Start()
        {
            _target = FindObjectOfType<PlayerTank>().transform; // Поиск танка игрока при старте сцены
            shoot = new Shooting(_startPosition, _bullet, _speedBullet);
            _turretTurner = new DirectionTurner(_tower);
            TurnesChanged += StartTurn;


        }


        void Update()
        {

            //if (inv)
            if (_myTurn && !IsInvoking("ShootEnemyTank"))
            {
                if (_currentTime >= _fireRate)
                {
                    ShootEnemyTank();
                    _currentTime = 0f;
                }
                _currentTime += Time.deltaTime;

            }


        }

        private void FixedUpdate()
        {
            _turretTurner.Turn(_target.position - transform.position, 1f);
        }
        void ShootEnemyTank()
        {
            
            shoot.Shoot();
        }

        public void TakeDamage(int damage)
        {
            _hp -= damage;
            TurnesChanged.Invoke();

            //Debug.Log("Больно!");

        }

        public void StartTurn()
        {
            _myTurn = true;
            Debug.Log(gameObject.name + " turn start");

        }

        public void EndTurn()
        {
            _myTurn = false;
            Debug.Log(gameObject.name + " turn end");

        }

        
    }
}


