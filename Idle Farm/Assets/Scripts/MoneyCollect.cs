using System.Collections;
using UnityEngine;

public class MoneyCollect : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject moneyPref;
    private Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }  
    public void MoneyMove(Vector3 _intial)
    {
        Vector3 targetPos = cam.ScreenToWorldPoint(new Vector3(target.position.x, target.position.y, cam.transform.position.z * -1));
        GameObject coin = Instantiate(moneyPref, transform);
        StartCoroutine(MoneyAnim(coin.transform, _intial, targetPos));
    }
    IEnumerator MoneyAnim(Transform obj, Vector3 starPos, Vector3 endPos)
    {
        float time = 0;
        while (time < 1)
        {
            time += speed * Time.deltaTime;
            obj.position = Vector3.Lerp(starPos, endPos, time);
            yield return new WaitForEndOfFrame();
        } 
        yield return null;
    }
}
