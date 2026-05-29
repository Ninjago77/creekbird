using UnityEditor.UI;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject pipe = null;
    private float timer = 0;
    public float spawnRate = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= spawnRate)
        {
            Instantiate(pipe, new Vector3(transform.position.x, Random.Range(-0.658f, -0.965f), transform.position.z), Quaternion.identity);
            timer = 0f;
        } 
        else
        {
            timer += Time.deltaTime;
        }
    }
}
