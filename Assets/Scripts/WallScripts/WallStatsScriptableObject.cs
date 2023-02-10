using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Wall
{
    [CreateAssetMenu(fileName = "Stats", menuName = "ScriptableObjects/WallStatsScriptableObject", order = 1)]
    public class WallStatsScriptableObject : ScriptableObject
    {

        public static float _movementSpeed { get; private set; } = 5f;

        public void IncreaseMovementSpeed()
        {
            _movementSpeed += 0.2f;
            if (_movementSpeed > 12)
            {
                _movementSpeed = 12;
            }
        }
    }
}