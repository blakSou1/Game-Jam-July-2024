using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class Swimming : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Rigidbody _playerRigidbody;

        private void Awake()
        {
            TryGetComponent(out _playerRigidbody);
        }

        private void Swim()
        {
            var moveInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            _playerRigidbody.velocity = moveInput.normalized * _speed;

            if (moveInput != Vector3.zero)
            {
                var rotZ = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
            }
        }
            

        private void FixedUpdate()
        {
            Swim();
        }
    }
}
