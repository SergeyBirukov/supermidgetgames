using Interfaces;
using UnityEngine;

namespace Obstacles
{
    public class IceObstacle : Obstacle, IDamageable
    {
        [SerializeField] private int health = 100;
        public int Health => health;

        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                DestroyIce();
            }
        }

        private void DestroyIce()
        {
            Destroy(gameObject);
        }
    }
}
