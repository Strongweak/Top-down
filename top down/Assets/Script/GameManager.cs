using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform playerPos;
    public EnemyControl enemy;
    public PlayerControl thePlayer;
    public PlayerHealth health;
    public GameObject canvas;

    public float TimeToBegin;
    public float Rate;
    public float radius;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        thePlayer = FindObjectOfType<PlayerControl>();
        canvas.SetActive(false);
        InvokeRepeating("Spawn", TimeToBegin, Rate);
    }
    // Update is called once per frame
    void Update()
    {

    }
    void Spawn()
    {
        Vector3 randomPos = Random.insideUnitSphere * radius;
        Quaternion rotation = Quaternion.LookRotation(playerPos.position);
        randomPos += transform.position;


        Vector3 direction = randomPos - transform.position;
        direction.Normalize();

        float dotProduct = Vector3.Dot(transform.forward, direction);
        float dotProductAngle = Mathf.Acos(dotProduct / transform.forward.magnitude * direction.magnitude);

        randomPos.x = Mathf.Cos(dotProductAngle) * radius + playerPos.position.x;
        randomPos.y = 1f;
        randomPos.z = Mathf.Sin(dotProductAngle * (Random.value > 0.5f ? 1f : -1f)) * radius + playerPos.position.z;

        EnemyControl newEnemy = Instantiate(enemy, randomPos, rotation);
        newEnemy.transform.position = randomPos;


    }
    public void GameOver()
    {
        Time.timeScale = 0;
        canvas.SetActive(true);
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("RELOADED!!!");
    }
}
