using UnityEngine;
using UnityEngine.UI;

public class GrenadeAmountText : MonoBehaviour
{
    public GrenadeCaster grenadeCaster;
    public Text grenadeAmountText;
    
    void Update()
    {
       grenadeAmountText.text = grenadeCaster.grenadeAmount.ToString();
    }
}
