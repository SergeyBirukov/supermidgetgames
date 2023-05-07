using System;
using UnityEngine;

namespace Puzzles.Microwave
{
    public class LineDrawer : MonoBehaviour
    {
        private LineRenderer _lineRenderer;
        private GameObject _startingObject;
        private Camera _mainCamera;

        // Start is called before the first frame update
        void Start()
        {
            _mainCamera = Camera.main;
            _lineRenderer = GetComponent<LineRenderer>();
            _lineRenderer.positionCount = 2;
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void OnMouseDown()
        {
            _startingObject = FindStartingNode();
        }

        private void OnMouseUp()
        {
            if (_startingObject == null) return;
            var endingObject = FindStartingNode();
            if (endingObject == null) return;
            _lineRenderer.SetPosition(0, _startingObject.transform.position);
            _lineRenderer.SetPosition(1, endingObject.transform.position);
        }

        private GameObject FindStartingNode()
        {
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            var rayHit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (rayHit.collider == null) return null;
            Debug.Log($"Found {rayHit.collider.gameObject}");
            return rayHit.collider.gameObject;

        }
    }
}