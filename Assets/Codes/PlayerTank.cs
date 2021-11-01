using System;
using System.Collections.Generic;
using UnityEngine;


namespace Tanks2021
{

    internal sealed class PlayerTank : MonoBehaviour, IDamagable, ITakeTurns
    {
        public event Action TurnesChanged;

        [SerializeField] private int _maxHp = 10; // хп сделал int
        [SerializeField] private int _hp;
        [SerializeField] private Rigidbody _bullet;
        [SerializeField] private Transform _startPosition;
        [SerializeField] private float _speedBullet;

        private float _rotX = 0.0f; // rotation around the horisontal axis
        private float _rotY = 0.0f; // move forvard/backward        
                                   

        private Shooting _canon;

        [SerializeField] private Transform _tower;
        private DirectionTurner _turretTurner;
        [SerializeField] private Transform _directionOfView;

        [SerializeField] private float _speed = 2f;

        [SerializeField] private Transform _chassie;
        private DirectionTurner _chassieTurener;

        private bool _myTurn;
        public bool GetCondition() => _myTurn;

        void Start()
        {
            _hp = _maxHp;        
            _canon = new Shooting(_startPosition, _bullet, _speedBullet);
            _turretTurner = new DirectionTurner(_tower);
            _chassieTurener = new DirectionTurner(_chassie);
            _directionOfView.rotation = transform.rotation;
            TurnesChanged += StartTurn;


        }


        void Update()
        {
            if (_myTurn) 
            {
                GetControlls(); 
            }
            //void RotatesTower()
            //{
            //    //поворот башни 
            //    AngleRotate = Time.deltaTime * RotateSpeed * Input.GetAxis("Mouse X");
            //    //после поворота башни обнуляем значнеие 
            //    RotateTower = 0;
            //}
            CheckHealth();
            

        }

        private void FixedUpdate()
        {
            if (_myTurn)
            {
                Moving();
                _turretTurner.Turn(_directionOfView.forward, 1f);
            }
        }
        public void TakeDamage(int damage)
        {
            _hp -= damage;
            TurnesChanged.Invoke();


        }

        private void GetControlls()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _canon.Shoot();
            }
            
        }

        private void Moving()
        {
            _rotX += 90 * (Input.GetAxis("Horizontal2")) * Time.fixedDeltaTime;
            _rotY = Input.GetAxis("Vertical2") * Time.fixedDeltaTime * _speed;

            _directionOfView.localRotation = Quaternion.Euler(0f, _rotX, 0f);
            transform.Translate(_directionOfView.forward * _rotY, Space.World);
            _chassieTurener.Turn(_directionOfView.forward, _rotY * 90);
        }

        private void CheckHealth()
        {
            if (_hp == 0)
            {
                Debug.Log("Death!!!");
            }

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
