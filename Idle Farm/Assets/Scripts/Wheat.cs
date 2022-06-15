using System.Collections;
using UnityEngine;

public class Wheat : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private GameObject blockWheat;
    [SerializeField] private Transform mainTrans;
    private GameObject stack;
    private Collider col;
    private int rise = 6;
    private void Start()
    { 
        col = GetComponent<Collider>();
        StartCoroutine(Growing());
        stack = GameObject.FindGameObjectWithTag("Stack");
    }  
    public void TakeDamage(int damage)
    {
        if (hp > 0)
        {
            mainTrans.localScale = new Vector3(mainTrans.localScale.x, mainTrans.localScale.y - 0.19f, mainTrans.localScale.z);
        }
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
            Destroy(col);
            if (BlockManager.blockCount < 40)
            {
                Vector3 parentVec = new Vector3(stack.transform.position.x, stack.transform.position.y + BlockManager.distance, stack.transform.position.z);
                var child = Instantiate(blockWheat.transform, parentVec, stack.transform.rotation, stack.transform);
                BlockManager.blockCount++;
                BlockManager.distance = BlockManager.distance + 0.03f;
            }
        }
    } 
    IEnumerator Growing()
    {
        yield return new WaitForSeconds(0.05f);
        if (col == null)
        {
            rise = 0;
            yield return new WaitForSeconds(10);
            BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
            col = boxCollider.GetComponent<Collider>();
            col.isTrigger = true;
        }
        if (rise < 6)
        {
            hp++;
            rise++;
            mainTrans.localScale = new Vector3(mainTrans.localScale.x, mainTrans.localScale.y + 0.095f, mainTrans.localScale.z);
        }
        StartCoroutine(Growing());
    }
}
