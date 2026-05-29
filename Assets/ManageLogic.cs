using UnityEngine;
using UnityEngine.UI;


public class ManageLogic : MonoBehaviour
{
    public int voids = 0;
    public float time = 0;
    public Text voidScore = null;
    public Text timeScore = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

    }
}
