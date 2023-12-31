﻿using System;
using Pendulum.Views;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pendulum.Configs
{
    [CreateAssetMenu(fileName = "PendulumConfig", menuName = "Configs/Pendulum Config", order = 0)]
    public class PendulumConfig : ScriptableObject
    {
        [Range(0f, 90f)][SerializeField] private float _rangeAngle;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _minSpeed;
        [SerializeField] private PendulumView _pendulumPrefab;

        public float RangeAngle => _rangeAngle;
        public float MaxSpeed => _maxSpeed;
        public float MinSpeed => _minSpeed;
        public PendulumView PendulumPrefab => _pendulumPrefab;

        private void OnValidate()
        {
            _maxSpeed = Mathf.Max(_maxSpeed, _minSpeed);
            _minSpeed = Mathf.Min(_maxSpeed, _minSpeed);
        }
    }
}