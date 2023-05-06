using System;
using DefaultNamespace;
using UnityEngine;

namespace Obstacles
{
    public abstract class Obstacle: MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float speed;
        [SerializeField] private int collisionDamage;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.velocity = new Vector2(0, -speed);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("collision enter");
            var player = col.gameObject.GetComponent<Player>();
            if (player)
            {
                player.TakeDamage(collisionDamage);
            }
            Destroy(gameObject);
        }
    }
}