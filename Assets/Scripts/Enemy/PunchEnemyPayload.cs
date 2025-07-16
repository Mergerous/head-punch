using UnityEngine;

namespace Enemy
{
    public class PunchEnemyPayload
    {
        public Vector3 point;

        public PunchEnemyPayload(Vector3 point)
        {
            this.point = point;
        }
    }
}