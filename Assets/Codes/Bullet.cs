using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks2021
{
    public class Bullet : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {

            Destroy(gameObject);

        }
    }

}

