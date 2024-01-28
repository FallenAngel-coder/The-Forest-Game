// Copyright 2021, Infima Games. All Rights Reserved.

using System.Linq;
using UnityEngine;
using System;

namespace InfimaGames.LowPolyShooterPack
{
    [RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
    public class Movement : MovementBehaviour
    {
        #region FIELDS SERIALIZED

        [Header("Audio Clips")]

        [Tooltip("The audio clip that is played while walking.")]
        [SerializeField]
        private AudioClip audioClipWalking;

        [Tooltip("The audio clip that is played while running.")]
        [SerializeField]
        private AudioClip audioClipRunning;

        [Header("Speeds")]

        [SerializeField]
        private float speedWalking = 5.0f;

        [Tooltip("How fast the player moves while running."), SerializeField]
        private float speedRunning = 9.0f;

        [Header("Jump")]

        [Tooltip("The force applied when the player jumps.")]
        [SerializeField]
        private float jumpForce = 10.0f;

        [Header("Gravity")]

        [Tooltip("The strength of gravity.")]
        [SerializeField]
        private float gravity = 9.8f;

        [Header("Crouch")]

        [Tooltip("The speed at which the player moves while crouching.")]
        [SerializeField]
        private float crouchSpeed = 3.0f;

        [Tooltip("The speed at which the player moves while crouching and running.")]
        [SerializeField]
        private float crouchRunningSpeed = 6.0f;

        [Tooltip("The height the player should crouch to.")]
        [SerializeField]
        private float crouchHeight = 0.5f;



        [Header("Jump and Landing Sounds")]

        [Tooltip("The audio clip that is played when the player jumps.")]
        [SerializeField]
        private AudioClip audioClipJump;

        [Tooltip("The audio clip that is played when the player lands.")]
        [SerializeField]
        private AudioClip audioClipLanding;

        // Boolean to check if the player is jumping.
        private bool isJumping;

        // Boolean to check if the player has just landed.
        private bool justLanded;

        #endregion

        #region PROPERTIES

        //Velocity.
        private Vector3 Velocity
        {
            //Getter.
            get => rigidBody.velocity;
            //Setter.
            set => rigidBody.velocity = value;
        }

        #endregion

        #region FIELDS

        /// <summary>
        /// Attached Rigidbody.
        /// </summary>
        private Rigidbody rigidBody;
        /// <summary>
        /// Attached CapsuleCollider.
        /// </summary>
        private CapsuleCollider capsule;
        /// <summary>
        /// Attached AudioSource.
        /// </summary>
        private AudioSource audioSource;

        /// <summary>
        /// True if the character is currently grounded.
        /// </summary>
        private bool grounded;

        /// <summary>
        /// Player Character.
        /// </summary>
        private CharacterBehaviour playerCharacter;
        /// <summary>
        /// The player character's equipped weapon.
        /// </summary>
        private WeaponBehaviour equippedWeapon;

        /// <summary>
        /// Array of RaycastHits used for ground checking.
        /// </summary>
        private readonly RaycastHit[] groundHits = new RaycastHit[8];

        public bool isInLock = false;
        #endregion

        #region UNITY FUNCTIONS

        /// <summary>
        /// Awake.
        /// </summary>
        protected override void Awake()
        {
            //Get Player Character.
            playerCharacter = ServiceLocator.Current.Get<IGameModeService>().GetPlayerCharacter();
        }

        /// Initializes the FpsController on start.
        protected override void Start()
        {
            //Rigidbody Setup.
            rigidBody = GetComponent<Rigidbody>();
            rigidBody.constraints = RigidbodyConstraints.FreezeRotation;
            //Cache the CapsuleCollider.
            capsule = GetComponent<CapsuleCollider>();

            //Audio Source Setup.
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = audioClipWalking;
            audioSource.loop = true;

            // Handle Jumping
            HandleJump();

            // Handle Crouching
            HandleCrouch();

            // Play Jump and Landing Sounds
            PlayJumpAndLandingSounds();
        }

        /// Checks if the character is on the ground.
        private void OnCollisionStay()
        {
            //Bounds.
            Bounds bounds = capsule.bounds;
            //Extents.
            Vector3 extents = bounds.extents;
            //Radius.
            float radius = extents.x - 0.01f;

            //Cast. This checks whether there is indeed ground, or not.
            Physics.SphereCastNonAlloc(bounds.center, radius, Vector3.down,
                groundHits, extents.y - radius * 0.5f, ~0, QueryTriggerInteraction.Ignore);

            //We can ignore the rest if we don't have any proper hits.
            if (!groundHits.Any(hit => hit.collider != null && hit.collider != capsule))
                return;

            //Store RaycastHits.
            for (var i = 0; i < groundHits.Length; i++)
                groundHits[i] = new RaycastHit();

            //Set grounded. Now we know for sure that we're grounded.
            grounded = true;
        }

        protected override void FixedUpdate()
        {
            //Move.
            MoveCharacter();

            //Unground.
            grounded = false;
        }

        /// Moves the camera to the character, processes jumping and plays sounds every frame.
        protected override void Update()
        {
            //Get the equipped weapon!
            equippedWeapon = playerCharacter.GetInventory().GetEquipped();
            if (Input.GetKeyDown(KeyCode.Tab))
                isLocked = !isLocked;
            // Play Sounds!
            PlayFootstepSounds();

            // Handle Jumping
            HandleJump();

            // Handle Crouching
            HandleCrouch();
        }

        #endregion

        #region METHODS
        private bool isLocked = false;
        private bool isCrouching = false;
        public Stamina stamina;
        private void MoveCharacter()
        {
            if (grounded)
            {
                if (!isLocked)
                {
                    #region Calculate Movement Velocity

                    // Get Movement Input!
                    Vector2 frameInput = playerCharacter.GetInputMovement();
                    // Calculate local-space direction by using the player's input.
                    var movement = new Vector3(frameInput.x, 0.0f, frameInput.y);

                    // Running and crouching speed calculation.
                    if (playerCharacter.IsRunning() && !isCrouching && stamina.currentStamina > 0)
                        movement *= speedRunning;
                    else if (isCrouching)
                    {
                        // If crouching, use crouch speed.
                        movement *= crouchSpeed;
                        if (playerCharacter.IsRunning() && stamina.currentStamina > 0)
                        {
                            // If crouching and running, use crouchRunningSpeed.
                            movement *= crouchRunningSpeed;
                        }
                    }
                    else
                    {
                        // Multiply by the normal walking speed.
                        movement *= speedWalking;
                    }

                    // World space velocity calculation. This allows us to add it to the rigidbody's velocity properly.
                    movement = transform.TransformDirection(movement);

                    #endregion

                    // Update Velocity.
                    Velocity = new Vector3(movement.x, Velocity.y, movement.z); // Тут ми зберігаємо Y компоненту швидкості, щоб зберігати гравітацію.

                    // Apply Gravity
                    if (!grounded)
                    {
                        // Додаємо гравітацію вниз, віднімаючи від Y-компоненти швидкості.
                        Velocity += Vector3.down * gravity * Time.deltaTime;
                    }
                }
            }
        }

        private void PlayFootstepSounds()
        {
            if (!isLocked)
            {
                // Check if we're moving on the ground. We don't need footsteps in the air.
                if (grounded && rigidBody.velocity.sqrMagnitude > 0.1f)
                {
                    // Select the correct audio clip to play.
                    audioSource.clip = playerCharacter.IsRunning() ? audioClipRunning : audioClipWalking;
                    // Play it!
                    if (!audioSource.isPlaying)
                        audioSource.Play();
                }
                // Pause it if we're doing something like flying, or not moving!
                else if (audioSource.isPlaying)
                    audioSource.Pause();
            }
        }

        private void HandleJump()
        {
            if (!isLocked)
            {
                bool jumpInput = Input.GetKey(KeyCode.Space);
                // Check if the player wants to jump and is grounded and not already jumping.
                if (grounded && jumpInput && !isJumping)
                {
                    isJumping = true;
                    float jumpVelocity = Mathf.Sqrt(2 * jumpForce * Mathf.Abs(Physics.gravity.y));
                    rigidBody.velocity = new Vector3(rigidBody.velocity.x, jumpVelocity, rigidBody.velocity.z);
                    // Play jump sound.
                    audioSource.PlayOneShot(audioClipJump);
                }

                // Check if the player has just landed.
                if (grounded && !jumpInput && isJumping)
                {
                    isJumping = false;
                    // Play landing sound.
                    justLanded = true;
                }
            }
        }

        private void HandleCrouch()
        {
            if (!isLocked)
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    // Crouch when the Left Control key is held down.
                    capsule.height = crouchHeight;
                    isCrouching = true;
                }
                else
                {
                    // Stand up when the Left Control key is released.
                    capsule.height = 2.0f; // Assuming a standard capsule height of 2.0 units.
                    isCrouching = false;
                }
            }
        }

        private void PlayJumpAndLandingSounds()
        {
            if (justLanded)
            {
                audioSource.PlayOneShot(audioClipLanding);
                justLanded = false;
            }
        }

        #endregion
    }
}
