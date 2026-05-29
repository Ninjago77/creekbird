
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject pipe = null;
    private float timer = 0;
    public float baseSpawnRate = 3f;     // The starting spawn rate (seconds between pipes)
    public float minSpawnRate = .35f;      // The absolute fastest the pipes can spawn
    public float difficultySpeed = 0.05f; // How fast the spawn rate drops per second
    public ManageLogic logic = null;
    private float currentSpawnRate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSpawnRate = baseSpawnRate;
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpawnRate > minSpawnRate)
        {
            currentSpawnRate -= difficultySpeed * Time.deltaTime;

            // Clamp it so it never goes below your minimum allowed rate
            currentSpawnRate = Mathf.Max(currentSpawnRate, minSpawnRate);
        }
        if (currentSpawnRate <= minSpawnRate)
        {
            logic.leftSpeed += difficultySpeed * Time.deltaTime;
        }
        if (timer >= currentSpawnRate)
        {
            SpawnPipe();
            timer = 0f;
        } 
        else
        {
            timer += Time.deltaTime;
        }
    }

    void SpawnPipe()
    {
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(-0.675f, -0.940f), transform.position.z), Quaternion.identity);

    }
}
