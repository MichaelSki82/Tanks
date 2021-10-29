
using UnityEngine;


namespace Tanks2021
{
    internal sealed class Shooting
    {

        private Rigidbody _bullet;
        private Transform _startPosition;
        private float _speedBullet;

        public Shooting(Transform startPosition, Rigidbody bullet, float speedBullet)
        {
            _startPosition = startPosition;
            _speedBullet = speedBullet;
            _bullet = bullet;
        }


        public void Shoot()
        {

            var temAmmunition = Object.Instantiate(_bullet, _startPosition.position, _startPosition.rotation);
            temAmmunition.AddForce(_startPosition.forward * _speedBullet);

        }
    }

}

