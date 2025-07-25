using UnityEngine;

namespace Player
{
    public sealed class PlayerPunchController : MonoBehaviour
    {
        private const float DISTANCE_MIN_VALUE = 0.1f;
        
        [Header("Options")]
        [SerializeField] private float sensitivity = 100f;
        [SerializeField] private float backwardSpeed = 5f;
        [Header("Components")]
        [SerializeField] private Transform leftGlove;
        [SerializeField] private Transform leftDestination;
        [SerializeField] private Transform rightGlove;
        [SerializeField] private Transform rightDestination;

        private Vector3 sourcePosition;
        private Vector3 leftInitialPosition;
        private Vector3 rightInitialPosition;
        private bool isLeft;
        private bool isSwiped;

        private void Awake()
        {
            leftInitialPosition = leftGlove.position;
            rightInitialPosition = rightGlove.position;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                isSwiped = true;
                sourcePosition = Input.mousePosition;
                isLeft = sourcePosition.x < Screen.width / 2f;
            }

            if (isSwiped && Input.GetMouseButton(0))
            {
                (Vector3 rhs, Transform source, Vector3 initialPosition, Transform destination) = isLeft
                    ? (Vector3.up + Vector3.right, leftGlove, leftInitialPosition, leftDestination)
                    : (Vector3.up + Vector3.left, rightGlove, rightInitialPosition, rightDestination);
                    
                Vector3 direction = Input.mousePosition - sourcePosition;
                float dot = Vector3.Dot(direction.normalized, rhs);
                
                source.position = Vector3.Lerp(initialPosition, destination.position, Mathf.Sign(dot) * direction.magnitude / sensitivity);
                
                if (Vector3.Distance(source.position, destination.position) < DISTANCE_MIN_VALUE)
                {
                    isSwiped = false;
                }
            }
            else
            {
                leftGlove.position = Vector3.Lerp(leftGlove.position, leftInitialPosition, Time.deltaTime * backwardSpeed);
                rightGlove.position = Vector3.Lerp(rightGlove.position, rightInitialPosition, Time.deltaTime * backwardSpeed);
            }
        }
    }
}