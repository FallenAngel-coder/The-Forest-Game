using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    public class WeaponRecoil : MonoBehaviour
    {
        [SerializeField] private float recoilForce = 0.5f; // Сила віддачі
        [SerializeField] private float recoilRotation = 1.0f; // Обертання під час віддачі

        private Weapon weapon; // Посилання на клас Weapon
        private Vector3 originalPosition; // Початкова позиція зброї

        private void Start()
        {
            weapon = GetComponent<Weapon>(); // Отримати посилання на компонент Weapon
            originalPosition = transform.localPosition; // Зберегти початкову позицію
        }

        public void ApplyRecoil()
        {
            // Генерування випадкової віддачі
            float recoilX = Random.Range(-recoilForce, recoilForce);
            float recoilY = Random.Range(-recoilForce, recoilForce);
            float recoilZ = Random.Range(-recoilForce, recoilForce);

            // Застосувати віддачу до позиції зброї
            transform.localPosition += new Vector3(recoilX, recoilY, recoilZ);

            // Застосувати обертання віддачі
            float recoilRotX = Random.Range(-recoilRotation, recoilRotation);
            float recoilRotY = Random.Range(-recoilRotation, recoilRotation);
            float recoilRotZ = Random.Range(-recoilRotation, recoilRotation);

            transform.localRotation *= Quaternion.Euler(recoilRotX, recoilRotY, recoilRotZ);
        }

        public void ResetRecoil()
        {
            // Повернути зброю до початкової позиції
            transform.localPosition = originalPosition;
            transform.localRotation = Quaternion.identity;
        }

        // Викликається при стрільбі
        public void OnFire()
        {
            // Перевірити, чи зброя може відбуватись віддача
            if (weapon != null && weapon.HasAmmunition())
            {
                ApplyRecoil(); // Застосувати віддачу
                // Можна також розширити цей метод, щоб обробити звук віддачі, анімацію, тощо
            }
        }
    }
}
