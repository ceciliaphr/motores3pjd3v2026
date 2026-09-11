using UnityEngine;
using Unity.Cinemachine;

namespace StarterAssets
{
    [RequireComponent(typeof(CharacterController))]
    public class RespawnPlayer : MonoBehaviour
    {
        [Tooltip("The Y position threshold at which the player will respawn.")]
        public float yThreshold = -5f; 

        private Vector3 _startingPosition;
        private Quaternion _startingRotation;
        private CharacterController _characterController;
        public CinemachineCamera vCam;
        private ThirdPersonController _thirdPersonController;
        public AudioClip respawnSound;

        private void Start()
        {
            _startingPosition = transform.position;
            _startingRotation = transform.rotation;

            _characterController = GetComponent<CharacterController>();
            if (_characterController == null)
            {
                Debug.LogError("CharacterController component is required for RespawnPlayer script!");
            }

            _thirdPersonController = GetComponent<ThirdPersonController>();
            if (_thirdPersonController == null)
            {
                Debug.LogError("ThirdPersonController component is required for RespawnPlayer!");
            }
        }

        private void Update()
        {
            if (transform.position.y < yThreshold)
            {
                Respawn();
            }
        }

        private void Respawn()
        {
            if (_characterController != null)
            {
                _characterController.enabled = false;
            }

            transform.position = _startingPosition;
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);

            if (_characterController != null)
            {
                _characterController.enabled = true;
                ResetVerticalVelocity();
            }

            ThirdPersonController thirdPersonController = GetComponent<ThirdPersonController>();
            if (thirdPersonController != null)
            {
                thirdPersonController.ResetCameraRotation(90f);
            }

            if (respawnSound != null)
            {
                AudioSource.PlayClipAtPoint(respawnSound, transform.position);
            }
        }

        private void ResetVerticalVelocity()
        {
            if (TryGetComponent<ThirdPersonController>(out ThirdPersonController controller))
            {
                var verticalVelocityField = typeof(ThirdPersonController).GetField("_verticalVelocity",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

                if (verticalVelocityField != null)
                {
                    verticalVelocityField.SetValue(controller, 0f);
                }
            }
        }
    }
}