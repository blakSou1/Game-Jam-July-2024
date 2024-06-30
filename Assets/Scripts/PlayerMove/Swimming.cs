using UnityEngine;

namespace Assets.Scripts.PlayerMove
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Swimming : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Rigidbody2D _playerRigidbody;

        private void Awake()
        {
            TryGetComponent(out _playerRigidbody);
        }

        private void Swim()
        {
            var moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

           _playerRigidbody.AddForce(moveInput * _speed);

            if (moveInput != Vector2.zero)
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
