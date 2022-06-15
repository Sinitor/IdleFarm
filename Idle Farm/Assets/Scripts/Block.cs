using UnityEngine;

public class Block : MonoBehaviour
{
    private Transform ambar;
    private bool isAmbar;
    private float speed;
    private Collider col;
    private void Start()
    {
        isAmbar = false;
        speed = Random.Range(3, 7);
        col = GetComponent<Collider>();
    }
    private void Update()
    {
        if (isAmbar == true)
        {
            Vector3 dir = ambar.position - transform.position;
            float distanceThisFrame = speed * Time.deltaTime;
            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
            Destroy(gameObject,3);
            BlockManager.blockCount = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ambar")
        {
            Destroy(col);
            ambar = other.transform;
            gameObject.transform.parent = null;
            isAmbar = true;
        }
    }
}
