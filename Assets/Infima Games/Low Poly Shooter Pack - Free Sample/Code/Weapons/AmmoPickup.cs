using UnityEngine;
using TMPro;
using XEntity.InventoryItemSystem;

namespace InfimaGames.LowPolyShooterPack
{
    public class AmmoPickup : MonoBehaviour, IInteractable
    {
        public int additionalReloads = 5;
        public string[] magazineTags = new string[5]; // Масив для зберігання п'яти тегів
        public TextMeshProUGUI tagDisplayText; // Посилання на компонент TextMeshPro для виведення тегів

        private void Start()
        {
            // Перевірка, чи компонент TextMeshPro існує
            if (tagDisplayText != null)
            {
                string tagsText = "Ammunition:\n"; // Додавання символу перенесення рядка
                foreach (string tag in magazineTags)
                {
                    tagsText += tag + "\n"; // Додавання символу перенесення рядка між кожним тегом
                }
                // Виведення тегів на компоненті TextMeshPro
                tagDisplayText.text = tagsText;
            }
        }

        public void OnClickInteract(Interactor interactor)
        {
            Magazine[] magazines = interactor.GetComponentsInChildren<Magazine>(true);

            foreach (Magazine magazine in magazines)
            {
                // Перевірка, чи тег магазину належить до списку обраних тегів
                if (ArrayContainsTag(magazine.tag))
                {
                    AddAmmoToMagazine(magazine);
                }
            }

            Destroy(gameObject);
        }

        private bool ArrayContainsTag(string tag)
        {
            // Перевірка, чи тег належить до списку обраних тегів
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
