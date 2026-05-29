using UnityEngine;

public class Pipe : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private ManageLogic logic = null;
    private float speed;

    void Start()
    {
        logic = FindAnyObjectByType < ManageLogic > ();
        speed = logic.leftSpeed;
        //transform.position = new Vector3(0.486f,Random.Range(-0.658f, -0.965f),transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left*speed*Time.deltaTime;

        if (transform.position.x < -1.2f)
        {
            //logic.voids += 1;
            Destroy(gameObject);
        }
    }
}
