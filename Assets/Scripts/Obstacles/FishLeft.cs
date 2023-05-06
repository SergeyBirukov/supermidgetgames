using Interfaces;
using UnityEngine;

namespace Obstacles
{
    public class FishLeft: Obstacle, IDamageable
    {
        [SerializeField] private int health = 100;
        public int Health => health;
        
        public override void SetupMoveDirection()
        {
            _rigidbody2D.velocity = new Vector2(speed, 0);
        } 
        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}