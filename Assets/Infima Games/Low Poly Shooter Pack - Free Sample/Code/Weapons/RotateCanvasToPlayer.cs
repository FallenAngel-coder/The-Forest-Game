using UnityEngine;

public class RotateCanvasToPlayer : MonoBehaviour
{
    public string playerTag = "Player"; // “ег гравц€
    private Transform player; // ѕосиланн€ на тег гравц€

    void Start()
    {
        // «находимо гравц€ за тегом
        GameObject playerObject = GameObject.FindWithTag(playerTag);
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("√равець не знайдений! ѕерев≥рте тег гравц€.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            // ќтримуЇмо вектор, €кий вказуЇ з Canvas на гравц€
            Vector3 direction = player.position - transform.position;

            // ѕовертаЇмо Canvas в напр€мку гравц€ з оберненою ор≥Їнтац≥Їю
            transform.rotation = Quaternion.LookRotation(-direction);
        }
        else
        {
            Debug.LogWarning("√равець не вказаний! ƒодайте посиланн€ на гравц€ до скрипту.");
        }
    }
}
