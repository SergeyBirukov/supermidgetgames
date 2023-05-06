using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class BackgroundImage: MonoBehaviour
    {
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private Transform startPos;
        [SerializeField] private Transform endPos;
        [SerializeField] private float speed;

        private void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            rigidbody2D.velocity = new Vector2(0, -speed);
        }

        private void Update()
        {
            if (transform.position.y <= endPos.position.y)
            {
                ToStartPos();
            }
        }

        private void ToStartPos()
        {
            transform.position = startPos.position;
            rigidbody2D.velocity = new Vector2(0, -speed);
        }
    }
}