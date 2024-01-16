using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    public class WeaponRecoil : MonoBehaviour
    {
        [SerializeField] private float recoilForce = 0.5f; // ���� ������
        [SerializeField] private float recoilRotation = 1.0f; // ��������� �� ��� ������

        private Weapon weapon; // ��������� �� ���� Weapon
        private Vector3 originalPosition; // ��������� ������� ����

        private void Start()
        {
            weapon = GetComponent<Weapon>(); // �������� ��������� �� ��������� Weapon
            originalPosition = transform.localPosition; // �������� ��������� �������
        }

        public void ApplyRecoil()
        {
            // ����������� ��������� ������
            float recoilX = Random.Range(-recoilForce, recoilForce);
            float recoilY = Random.Range(-recoilForce, recoilForce);
            float recoilZ = Random.Range(-recoilForce, recoilForce);

            // ����������� ������ �� ������� ����
            transform.localPosition += new Vector3(recoilX, recoilY, recoilZ);

            // ����������� ��������� ������
            float recoilRotX = Random.Range(-recoilRotation, recoilRotation);
            float recoilRotY = Random.Range(-recoilRotation, recoilRotation);
            float recoilRotZ = Random.Range(-recoilRotation, recoilRotation);

            transform.localRotation *= Quaternion.Euler(recoilRotX, recoilRotY, recoilRotZ);
        }

        public void ResetRecoil()
        {
            // ��������� ����� �� ��������� �������
            transform.localPosition = originalPosition;
            transform.localRotation = Quaternion.identity;
        }

        // ����������� ��� ������
        public void OnFire()
        {
            // ���������, �� ����� ���� ���������� ������
            if (weapon != null && weapon.HasAmmunition())
            {
                ApplyRecoil(); // ����������� ������
                // ����� ����� ��������� ��� �����, ��� �������� ���� ������, �������, ����
            }
        }
    }
}
