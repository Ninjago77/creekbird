
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

    // 1. Keep difficulty scaling in Update so movement stays perfectly smooth
    void Update()
    {
        if (currentSpawnRate > minSpawnRate)
        {
            currentSpawnRate -= difficultySpeed * Time.deltaTime;
            currentSpawnRate = Mathf.Max(currentSpawnRate, minSpawnRate);
        }
        //else
        //{
        //    if (logic != null)
        //    {
        //        // Smooth movement depends on Time.deltaTime
        //        logic.leftSpeed += difficultySpeed * Time.deltaTime;
        //    }
        //}

        //if (logic.time > 60)
        //{
        //    logic.leftSpeed += difficultySpeed * Time.deltaTime;
        //}
    }

    // 2. Move ONLY the spawning timer to FixedUpdate for absolute browser precision
    void FixedUpdate()
    {
        // In FixedUpdate, use Time.fixedDeltaTime
        timer += Time.fixedDeltaTime;

        if (timer >= currentSpawnRate)
        {
            SpawnPipe();
            timer = 0f; // This is now safe because fixedDeltaTime never spikes!
        }
    }

    void SpawnPipe()
    {
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(-0.675f, -0.940f), transform.position.z), Quaternion.identity);

    }
}
