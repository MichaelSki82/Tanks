using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Tanks2021
{
    public class TurnController : MonoBehaviour
    {
        public Action<int> turn;
        //private EventSystem _eventSystem;
        private List <ITakeTurns> _sides;
        int _currentTurn = 0;
        // Start is called before the first frame update
        void Start()
        {
            _sides = new List<ITakeTurns>();
            _sides.Add(FindObjectOfType<PlayerTank>());
            _sides.AddRange(FindObjectsOfType<EnemyTank>());
            Debug.Log(_sides.Count);
            GiveTurn(_currentTurn);

            for (var i = 0; i < _sides.Count; i++)
            {
                for (var j = 0; j < _sides.Count; j++)
                {
                    if (j != i)
                    _sides[j].TurnesChanged += _sides[i].EndTurn;
                    
                }
            }
            
        }

       
        void GiveTurn(int num)
        {
            for (var i = 0; i < _sides.Count; i++)
            {
                if (i == num)
                    _sides[i].StartTurn();
                else
                    _sides[i].EndTurn();
            }

        }

        private void OnDestroy()
        {

        }
    }
}