using System;
using UnityEngine;

namespace Common
{
    internal class CooldownExecutor
    {
        private readonly float _cooldown;
        private readonly Action _action;
        private float _nextSmackAllowedTime;

        public CooldownExecutor(float cooldown, Action action)
        {
            _cooldown = cooldown;
            _action = action;
        }

        public void Execute()
        {
            if (CooldownFinished())
            {
                SetCooldown();
                _action();
            }
        }

        private bool CooldownFinished() => _nextSmackAllowedTime <= Time.time;
        private void SetCooldown() => _nextSmackAllowedTime = Time.time + _cooldown;
    }
}