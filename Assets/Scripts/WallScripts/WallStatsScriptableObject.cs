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
            _movementSpeed += 0.1f;
            if (_movementSpeed > 15)
            {
                _movementSpeed = 15;
            }
        }
    }
}