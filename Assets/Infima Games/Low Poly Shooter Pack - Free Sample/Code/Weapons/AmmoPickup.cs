using UnityEngine;
using TMPro;
using XEntity.InventoryItemSystem;

namespace InfimaGames.LowPolyShooterPack
{
    public class AmmoPickup : MonoBehaviour, IInteractable
    {
        public int additionalReloads = 5;
        public string[] magazineTags = new string[5]; // ����� ��� ��������� �'��� ����
        public TextMeshProUGUI tagDisplayText; // ��������� �� ��������� TextMeshPro ��� ��������� ����

        private void Start()
        {
            // ��������, �� ��������� TextMeshPro ����
            if (tagDisplayText != null)
            {
                string tagsText = "Ammunition:\n"; // ��������� ������� ����������� �����
                foreach (string tag in magazineTags)
                {
                    tagsText += tag + "\n"; // ��������� ������� ����������� ����� �� ������ �����
                }
                // ��������� ���� �� ��������� TextMeshPro
                tagDisplayText.text = tagsText;
            }
        }

        public void OnClickInteract(Interactor interactor)
        {
            Magazine[] magazines = interactor.GetComponentsInChildren<Magazine>(true);

            foreach (Magazine magazine in magazines)
            {
                // ��������, �� ��� �������� �������� �� ������ ������� ����
                if (ArrayContainsTag(magazine.tag))
                {
                    AddAmmoToMagazine(magazine);
                }
            }

            Destroy(gameObject);
        }

        private bool ArrayContainsTag(string tag)
        {
            // ��������, �� ��� �������� �� ������ ������� ����
            foreach (string magazineTag in magazineTags)
            {
                if (tag == magazineTag)
                {
                    return true;
                }
            }
            return false;
        }

        private void AddAmmoToMagazine(Magazine magazine)
        {
            magazine.maximumReloads += additionalReloads;
        }
    }
}
