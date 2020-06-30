using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nokobot
{
    public class TouchController : MonoBehaviour
    {
        private static TouchController Instance;
        private Vector2 _swipeDirection;
        private Vector3 _lastSwipePosition;

        private float _pinchDirection;

        [SerializeField] private float _minDrag = 1f;

        [SerializeField] private float _minPinch = 1f;

        private void Awake()
        {
            Instance = this;
            _swipeDirection = Vector2.zero;
            _lastSwipePosition = Vector3.zero;
            _pinchDirection = 0f;
        }

        private void Update()
        {
            _HandleSwipe();
            _HandlePinch();
        }

        private void _HandleSwipe()
        {
            if (!Input.GetMouseButton(0))
            {
                _swipeDirection = Vector2.zero;
                return;
            }

            if (Input.touchCount != 1 && !Input.GetMouseButton(0))
            {
                _swipeDirection = Vector2.zero;
                return;
            }

            Vector3 position = Input.mousePosition;

            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                position = touch.position;
                if (touch.phase != TouchPhase.Moved)
                {
                    _lastSwipePosition = position;
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
                {
                    _lastSwipePosition = position;
                }
            }

            _swipeDirection = position - _lastSwipePosition;
            _lastSwipePosition = position;
        }

        private void _HandlePinch()
        {
            if (Input.touchCount != 2)
            {
                _pinchDirection = -Input.GetAxis("Mouse ScrollWheel") / 10f;
                return;
            }

            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            _pinchDirection = prevTouchDeltaMag - touchDeltaMag;
            _pinchDirection *= -1f;
        }

        public static Vector2 GetSwipe() => Instance._swipeDirection;

        public static bool IsSwipingUp() => Instance._swipeDirection.y > Instance._minDrag;

        public static bool IsSwipingDown() => Instance._swipeDirection.y < -Instance._minDrag;

        public static bool IsSwipingRight() => Instance._swipeDirection.x > Instance._minDrag;

        public static bool IsSwipingLeft() => Instance._swipeDirection.x < -Instance._minDrag;

        public static float GetPinch() => Instance._pinchDirection;

        public static bool IsPinchingIn() => Instance._pinchDirection > Instance._minPinch;

        public static bool IsPinchingOut() => Instance._pinchDirection < -Instance._minPinch;
    }
}
