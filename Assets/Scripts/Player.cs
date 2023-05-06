using System;
using System.Security.Cryptography;
using Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class Player : MonoBehaviour, IDamageable
    {
        [field:SerializeField]
        public int Health { get; private set; } = 100;
        public UnityEvent onDeath;

        public void TakeDamage(int damage)
        {
            Health -= damage;
            Debug.Log("damage taken");
            if (Health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            onDeath.Invoke();
        }
    }
}