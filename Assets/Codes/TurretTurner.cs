using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks2021
{
    public class DirectionTurner
    {
       private Transform _tower;
       public DirectionTurner(Transform tower)
        {
            _tower = tower;

        }

        public void Turn(Vector3 direction, float turningSpeed)
        {
            Vector3 newdir = Vector3.RotateTowards(_tower.forward, direction, turningSpeed * Time.deltaTime, 0f);
            _tower.rotation = Quaternion.LookRotation(newdir);
        }
    }
}