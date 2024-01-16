using UnityEngine;
using System.Collections;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// Magazine.
    /// </summary>
    public class Magazine : MagazineBehaviour
    {
        #region FIELDS SERIALIZED

        [Header("Settings")]

        [Tooltip("Total Ammunition.")]
        [SerializeField]
        private int ammunitionTotal = 10;

        [Tooltip("Maximum Reloads.")]
        [SerializeField]
        public int maximumReloads = 3; // Змінив модифікатор доступу на public, щоб зробити поле доступним для інших класів.

        [Header("Interface")]

        [Tooltip("Interface Sprite.")]
        [SerializeField]
        private Sprite sprite;

        #endregion

        private bool isReloading = false; // Перемінна, щоб відслідковувати процес перезарядки.

        #region GETTERS
        public override int GetMaximumReloads() => maximumReloads;
        /// <summary>
        /// Ammunition Total.
        /// </summary>
        public override int GetAmmunitionTotal() => ammunitionTotal;
        /// <summary>
        /// Sprite.
        /// </summary>
        public override Sprite GetSprite() => sprite;

        #endregion

        // Оновлення кожного кадру
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R) && !isReloading && maximumReloads > 0)
            {
                StartCoroutine(Reload()); // Почати процес перезарядки.
            }
            if (Input.GetKeyDown(KeyCode.R) && maximumReloads <= 0)
            {
                ammunitionTotal = 0;
            }
        }

        // Корутин для перезарядки
        private IEnumerator Reload()
        {
            isReloading = true; // Позначити, що почалася перезарядка.

            yield return new WaitForSeconds(2f); // Затримка на 2 секунди (можна змінити на бажану тривалість).

            maximumReloads--; // Зменшити кількість можливих перезарядок.
            isReloading = false; // Позначити, що перезарядка завершена.
        }
    }
}