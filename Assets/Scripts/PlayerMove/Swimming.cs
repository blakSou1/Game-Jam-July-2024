using UnityEngine;

namespace Assets.Scripts.PlayerMove
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Swimming : MonoBehaviour
    {
        [SerializeField] private float _speed = 20f;
        private Rigidbody2D _playerRigidbody;

        private void Awake()
        {
            _playerRigidbody = GetComponent<Rigidbody2D>();
        }

        private void Swim()
        {
            var moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
            _playerRigidbody.velocity = moveInput * _speed * Time.deltaTime;

            if(moveInput != Vector2.zero)
            {
                if(moveInput.x < 0)
                    transform.localScale = new Vector3(transform.localScale.x, -1, transform.localScale.z);
                else
                    transform.localScale = new Vector3(transform.localScale.x, 1, transform.localScale.z);
                float an = Mathf.Atan2(_playerRigidbody.velocity.y, _playerRigidbody.velocity.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(an, Vector3.forward);
            }
        }

        private void Update()
        {
            Swim();
        }
    }
}
