using TMPro;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public GameObject player;
    public GameObject[] enemies;
    public GameObject[] grenades;
    public GameObject[] healers;

    private PlayerHealth _playerHealth;
    private GrenadeCaster _grenadeCaster;
    private TextMeshProUGUI _taskText;

    private void Start()
    {
        _playerHealth = player.GetComponent<PlayerHealth>();
        _grenadeCaster = player.GetComponent<GrenadeCaster>();
        _taskText = player.transform.GetChild(3).GetChild(1).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();


        CheckData();
    }

    public void SaveData(Transform spawnPointPos)
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] == null)
            {
                PlayerPrefs.SetInt("Enemy " + i, 1);
            }
        }

        for (int i = 0; i < grenades.Length; i++)
        {
            if (grenades[i] == null)
            {
                PlayerPrefs.SetInt("Grenade " + i, 1);
            }
        }

        for (int i = 0; i < healers.Length; i++)
        {
            if (healers[i] == null)
            {
                PlayerPrefs.SetInt("Healer " + i, 1);
            }
        }

        PlayerPrefs.SetFloat("Spawn Point Pos X", spawnPointPos.position.x);
        PlayerPrefs.SetFloat("Spawn Point Pos Y", spawnPointPos.position.y);
        PlayerPrefs.SetFloat("Spawn Point Pos Z", spawnPointPos.position.z);

        PlayerPrefs.SetFloat("Health", _playerHealth.health);
        PlayerPrefs.SetInt("Grenade Amount", _grenadeCaster.grenadeAmount);

        PlayerPrefs.SetString("Saved Task", _taskText.text);
        RectTransform parentRectTransform = _taskText.transform.parent.GetComponent<RectTransform>();
        PlayerPrefs.SetFloat("Saved Task Height", parentRectTransform.rect.height);
    }

    private void CheckData()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (PlayerPrefs.HasKey("Enemy " + i))
            {
                Destroy(enemies[i]);
            }
        }

        for (int i = 0; i < grenades.Length; i++)
        {
            if (PlayerPrefs.HasKey("Grenade " + i))
            {
                Destroy(grenades[i]);
            }
        }

        for (int i = 0; i < healers.Length; i++)
        {
            if (PlayerPrefs.HasKey("Healer " + i))
            {
                Destroy(healers[i]);
            }
        }
    }
}
