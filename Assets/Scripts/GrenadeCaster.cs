using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public float force = 10f;
    public int grenadeAmount = 0;

    public GameObject grenadePrefab;
    public Transform grenadeSourceTransform;

    public GameObject finishText;
    public GameObject throwGrenadeText;
    public GameObject pickUpText;
    public GameObject tutorialEnemy;

    public bool _pickUpTextShowed;
    private bool _grenadeTextChanged;

    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            if (grenadeAmount > 0)
            {
                grenadeAmount -= 1;
                var grenade = Instantiate(grenadePrefab, grenadeSourceTransform.position, grenadeSourceTransform.rotation);
                grenade.transform.Rotate(90, 0, 0);
                grenade.transform.GetComponent<Rigidbody>().AddForce(grenadeSourceTransform.forward * force);

                if (throwGrenadeText != null && _pickUpTextShowed)
                {
                    throwGrenadeText.SetActive(false);
                    finishText.SetActive(true);
                    if (tutorialEnemy != null)
                    {
                        tutorialEnemy.SetActive(true);
                    }
                }
            }
        }
        if (grenadeAmount > 0)
        {
            if (pickUpText != null && !_grenadeTextChanged)
            {
                pickUpText.SetActive(false);
                throwGrenadeText.SetActive(true);
                _pickUpTextShowed = true;
                _grenadeTextChanged = true;
            }
        }
    }
}
