using States;
using UnityEngine;
using VContainer;

namespace Enemy
{
    public sealed class PunchEnemyTrigger : MonoBehaviour
    {
        [Inject] private IStateService<EnemyContainer> enemyStateService;
        
        private void OnCollisionEnter(Collision other)
        {
            ContactPoint contact = other.contacts[0];
            enemyStateService.SetState<PunchEnemyState, PunchEnemyPayload>(new PunchEnemyPayload(contact.point));
        }
    }
}