using Punches;
using States;
using UnityEngine;

namespace Enemy
{
    public sealed class EnemyContainer : MonoBehaviour, IBlackboard
    {
        [field: SerializeField] public Transform Transform { get; private set; }
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
        
        [SerializeField] public Renderer renderer;
    }
}