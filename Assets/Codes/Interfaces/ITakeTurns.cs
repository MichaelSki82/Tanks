using System;

namespace Tanks2021
{
    public interface ITakeTurns
    {
        event Action TurnesChanged;
        bool GetCondition();

        void StartTurn();
        void EndTurn();
        
    }
}