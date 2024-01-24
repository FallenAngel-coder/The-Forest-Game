// Copyright 2021, Infima Games. All Rights Reserved.

using UnityEngine;
using InfimaGames.LowPolyShooterPack;
namespace InfimaGames.LowPolyShooterPack.Interface
{
    /// <summary>
    /// Player Interface.
    /// </summary>
    public class CanvasSpawner : MonoBehaviour
    {
        #region FIELDS SERIALIZED

        [Header("Settings")]
        
        [Tooltip("Canvas prefab spawned at start. Displays the player's user interface.")]
        [SerializeField]
        private GameObject canvasPrefab;
        public Character character;
        #endregion

        #region UNITY FUNCTIONS

        /// <summary>
        /// Awake.
        /// </summary>
        private void Awake()
        {
            //Spawn Interface.
            Instantiate(canvasPrefab);
            PauseMenu pauseMenu = canvasPrefab.GetComponentInChildren<PauseMenu>();
            pauseMenu.character = character;
    
        }

        #endregion
    }
}