using UnityEngine;

namespace Assets.Scripts.PlayerMove
{
    [RequireComponent(typeof(PlayerMovement), typeof(Swimming))]
    public class ControlChanger : MonoBehaviour
    {
        private PlayerMovement _movement;
        private Swimming _swimming;
        [SerializeField] private float _distance;
        [SerializeField] private LayerMask _water;

        private void Awake()
        {
            TryGetComponent(out _movement);
            TryGetComponent(out _swimming);
        }

        private void Update()
        {
            ChangeControl();
        }

        public void ChangeControl()
        {
            var hitInfo = Physics2D.Raycast(transform.position, Vector2.down, _distance, _water);
            if (hitInfo)
            {
                _swimming.enabled = true;
                _movement.enabled = false;
            }
            else
            {
                _swimming.enabled = false;
                _movement.enabled = true;
                transform.rotation = Quaternion.identity;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(transform.position, Vector2.down * _distance);
        }
    }
}
