using System.Collections;
using UnityEngine;
using TMPro;

public class Ambar : MonoBehaviour
{
    public static int money;
    public MoneyCollect moneyCollect;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private Animator anim;
    private void Start()
    {
        money = 0;
    } 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
            StartCoroutine(MoneyScore());
        }
    }  
    IEnumerator MoneyScore()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 15; i++)
        { 
            yield return new WaitForSeconds(0.1f);
            anim.SetBool("Cost",true);
            moneyCollect.MoneyMove(gameObject.transform.position);
            money++;
            moneyText.text = "" + money;
        }
        anim.SetBool("Cost", false);
    }
}
