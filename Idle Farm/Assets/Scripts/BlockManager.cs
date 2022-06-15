using UnityEngine;
using TMPro;

public class BlockManager : MonoBehaviour
{
    public static float distance;
    public static int blockCount;
    [SerializeField] private TextMeshProUGUI blockText;
    private void Start()
    {
        distance = 0; 
    }
    private void Update()
    {
        blockText.text = blockCount + "/40";
    }
}
