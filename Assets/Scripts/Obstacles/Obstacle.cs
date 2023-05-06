using UnityEngine;

namespace Obstacles
{
    public abstract class Obstacle: MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float speed;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.velocity = new Vector2(0, -speed);
        }
    }
}