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

        [SerializeField] private GameObject smoke1;
        [SerializeField] private GameObject smoke2;
        [SerializeField] private GameObject smoke3;


        public void TakeDamage(int damage)
        {
            Health -= damage;
            Debug.Log("damage taken");
            if (Health <= 75)
            {
                smoke1.SetActive(true);
            }

            if (Health <= 50)
            {
                smoke2.SetActive(true);
            }

            if (Health <= 25)
            {
                smoke3.SetActive(true);
            }
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