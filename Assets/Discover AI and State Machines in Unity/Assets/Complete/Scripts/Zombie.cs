using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public float deathTime = 5f; // Час після смерті, коли почнеться рух вниз
    private bool isDead = false; // Змінна для визначення, чи ворог помер

    private StateMachine brain;
    private Animator animator;
    [SerializeField]
    private UnityEngine.UI.Text stateNote;
    private UnityEngine.AI.NavMeshAgent agent;
    private Player player;
    private bool playerIsNear;
    private bool withinAttackRange;
    private float changeMind;
    private float attackTimer;
    public int enemyHealth = 300;

    private bool playerIsBehind; // Оголошуємо змінну на рівні класу

    public GameObject[] itemsPrefabs; // Масив з префабами предметів, які можуть випадати
    public float radiusA = 20f;
    public int arcAngleA = 60;
    public float radiusB = 5f;
    public int arcAngleB = 300;

    public float radiusAttack = 2f; // Радіус кола

    public float damage; // Оголошення змінної damage


    public void TakeDamage(float damageValue)
    {
        Debug.Log("Code reached the Zombie method");
        enemyHealth -= (int)damageValue; // Використай передане значення damage
        if (enemyHealth <= 0)
        {
            brain.PushState(Death, OnDeathEnter, null);
        }
        else
        {
            brain.PushState(Chase, OnChaseEnter, OnChaseExit);
        }
    }

    void Start()
    {
        player = FindObjectOfType<Player>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = transform.GetChild(0).GetComponent<Animator>();
        brain = GetComponent<StateMachine>();
        playerIsNear = false;
        playerIsBehind = false;
        withinAttackRange = false;
        brain.PushState(Idle, OnIdleEnter, OnIdleExit);
    }

    void Update()
    {
        Vector3 directionToPlayer = player.transform.position - transform.position;
        float angle = Vector3.Angle(transform.forward, directionToPlayer);

        // Гравець в полі зору спереду до 90 градусів
        playerIsNear = directionToPlayer.magnitude < radiusA && angle < arcAngleA / 2f;

        // Гравець в полі зору ззаду в межах вказаного кута
        playerIsBehind = directionToPlayer.magnitude < radiusB && angle > (180 - arcAngleB / 2f) && angle < (180 + arcAngleB / 2f);

        withinAttackRange = Vector3.Distance(transform.position, player.transform.position) < radiusAttack;

        // Перевірка звуку гравця
        if (player.tag == "PlayerSound") // Замість "PlayerSoundTag" вкажіть тег, який використовується для звуку гравця
        {
            brain.PopState(); // Зупинка поточного стану
            brain.PushState(Chase, OnChaseEnter, OnChaseExit); // Перехід до стану переслідування
        }
    }


    #region Gizmos

    private void OnDrawGizmos()
    {
        float startAngle = -arcAngleA / 2f; // Початковий кут
        float endAngle = arcAngleA / 2f; // Кінцевий кут

        Vector3 center = transform.position;

        // Малюємо криву дуги
        for (float angle = startAngle; angle <= endAngle; angle += 0.1f)
        {
            Gizmos.color = Color.yellow; // Змінюємо колір на жовтий

            Vector3 point = center + Quaternion.Euler(0f, angle, 0f) * transform.forward * radiusA;
            Gizmos.DrawLine(point, center + Quaternion.Euler(0f, angle + 0.1f, 0f) * transform.forward * radiusA);
        }

        // Малюємо прямі лінії з центру кола до крайніх точок дуги
        Vector3 startPoint = center + Quaternion.Euler(0f, startAngle, 0f) * transform.forward * radiusA; // Крайня точка початкового кута
        Vector3 endPoint = center + Quaternion.Euler(0f, endAngle, 0f) * transform.forward * radiusA; // Крайня точка кінцевого кута


        Gizmos.color = Color.yellow; // Змінюємо колір на жовтий
        Gizmos.DrawLine(center, startPoint); // З'єднання центру з крайньою точкою початкового кута
        Gizmos.DrawLine(center, endPoint); // З'єднання центру з крайньою точкою кінцевого кута



        // Нові змінні для другої дуги
        float startAngleB = -arcAngleB / 2f + 180;
        float endAngleB = arcAngleB / 2f + 180;


        // Малюємо другу дугу
        for (float angle = startAngleB; angle <= endAngleB; angle += 0.1f)
        {
            Vector3 pointB = center + Quaternion.Euler(0f, angle, 0f) * transform.forward * radiusB;
            Gizmos.DrawLine(pointB, center + Quaternion.Euler(0f, angle + 0.1f, 0f) * transform.forward * radiusB);
        }

        // Лінії від центру до крайніх точок другої дуги
        Vector3 startPointB = center + Quaternion.Euler(0f, startAngleB, 0f) * transform.forward * radiusB;
        Vector3 endPointB = center + Quaternion.Euler(0f, endAngleB, 0f) * transform.forward * radiusB;


        Gizmos.color = Color.yellow; // Змінюємо колір на жовтий
        Gizmos.DrawLine(center, startPointB);
        Gizmos.DrawLine(center, endPointB);




        Gizmos.color = Color.red; // Задаємо колір атаки

        // Отримуємо позицію об'єкта
        Vector3 position = transform.position;

        // Малюємо 2D коло
        const int segments = 50; // Кількість сегментів (точок) для наближення кола
        float angleStep = 360f / segments; // Кут між кожним сегментом

        Vector3 prevPoint = Vector3.zero;
        for (int i = 0; i <= segments; i++)
        {
            float angle = angleStep * i;
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radiusAttack;
            float z = Mathf.Cos(Mathf.Deg2Rad * angle) * radiusAttack;

            Vector3 point = position + new Vector3(x, 0f, z);

            if (i > 0)
            {
                Gizmos.DrawLine(prevPoint, point);
            }

            prevPoint = point;
        }

    }

    #endregion

    void OnIdleEnter()
    {
        stateNote.text = "Idle";
        agent.ResetPath();
    }
    void Idle()
    {
        changeMind -= Time.deltaTime;
        if (playerIsNear || playerIsBehind)
        {
            brain.PushState(Chase, OnChaseEnter, OnChaseExit);
        }
        else if (changeMind <= 0)
        {
            brain.PushState(Wander, OnWanderEnter, OnWanderExit);
            changeMind = Random.Range(4, 10);
        }
    }
    void OnIdleExit()
    {

    }

    void OnChaseEnter()
    {
        animator.SetBool("Chase", true);
        stateNote.text = "Chase";
    }
    void Chase()
    {
        agent.SetDestination(player.transform.position);
        if (Vector3.Distance(transform.position, player.transform.position) > 40f)
        {
            brain.PopState();
            brain.PushState(Idle, OnIdleEnter, OnIdleExit);
        }
        if (withinAttackRange)
        {
            brain.PushState(Attack, OnEnterAttack, null);
        }
    }
    void OnChaseExit()
    {
        animator.SetBool("Chase", false);
    }

    void OnWanderEnter()
    {
        stateNote.text = "Wander";
        animator.SetBool("Chase", true);
        Vector3 wanderDirection = (Random.insideUnitSphere * 4f) + transform.position;
        NavMeshHit navMeshHit;
        NavMesh.SamplePosition(wanderDirection, out navMeshHit, 3f, NavMesh.AllAreas);
        Vector3 destination = navMeshHit.position;
        agent.SetDestination(destination);
    }
    void Wander()
    {
        if (agent.remainingDistance <= .25f)
        {
            agent.ResetPath();
            brain.PushState(Idle, OnIdleEnter, OnIdleExit);
        }
        if (playerIsNear || playerIsBehind)
        {
            brain.PushState(Chase, OnChaseEnter, OnChaseExit);
        }
    }
    void OnWanderExit()
    {
        animator.SetBool("Chase", false);
    }

    void OnEnterAttack()
    {
        agent.ResetPath();
        stateNote.text = "Attack";
    }
    void Attack()
    {
        attackTimer -= Time.deltaTime;
        if (!withinAttackRange)
        {
            brain.PopState();
        }
        else if (attackTimer <= 0)
        {
            animator.SetTrigger("Attack");
            player.Hurt(2, 1);
            attackTimer = 2f;
        }
    }



    void Death()
    {
        if (!isDead)
        {
            isDead = true;
            agent.enabled = false; // Вимкни NavMeshAgent, щоб зупинити навігацію
            stateNote.text = "Death";
            animator.SetBool("Death", true);

            StartCoroutine(MoveDownAfterDelay(deathTime)); // Рух вниз після певного часу

            Collider myCollider = GetComponent<Collider>(); // Отримати компонент колайдера
            if (myCollider != null)
            {
                Destroy(myCollider); // Видалити колайдер через 2 секунди після смерті
            }
        }
    }

    IEnumerator MoveDownAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        float elapsedTime = 0f;
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos - Vector3.up * 1f; // Позиція нижче від початкової

        while (elapsedTime < 2f) // Протягом 2 секунд
        {
            transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / 2f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    void OnDeathEnter()
    {
        stateNote.text = "Death";
        animator.SetBool("Death", true);
        Destroy(gameObject, 15f); // Приклад: знищення об'єкта через 2 секунди

        Death(); // Виклик методу смерті
        DropItems(); // Замість Death();
    }


    public void DropItems()
    {
        NavMeshHit hit;
        for (int i = 0; i < itemsPrefabs.Length; i++)
        {
            Vector3 randomPos = transform.position + Random.insideUnitSphere * 1; // Генерація випадкової позиції в радіусі 5 одиниць
            if (NavMesh.SamplePosition(randomPos, out hit, 1f, NavMesh.AllAreas)) // Знаходження точки на поверхні NavMesh у радіусі 5 одиниць
            {
                Vector3 spawnPos = hit.position; // Отримання позиції на поверхні NavMesh
                Instantiate(itemsPrefabs[i], spawnPos, Quaternion.identity);
            }
        }
    }

}
