using UnityEngine;

public class MiddleTrig : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private ManageLogic logic = null;
    void Start()
    {
        logic = FindAnyObjectByType<ManageLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logic.voids += 1;

        }
    }
}
