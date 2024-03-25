using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GradualTextAppearance : MonoBehaviour
{

    public string[] messages;
    public float appearDelay = 1f;
    public float tipTextDelay;
    public float startDelay;

    public GameObject tipText;

    private bool textAppeared;
    private int i;

    private TextMeshProUGUI text;
    private float _timer;
    private bool _needAppear;
    private bool skip;
    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        Invoke("startCoroutine", startDelay);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (textAppeared == true)
            {
                i++;
                _needAppear = false;
                tipText.SetActive(false);
                skip = false;
                if (i < messages.Length)
                {
                    StartCoroutine(TextAppearance(messages[i], appearDelay));
                    textAppeared = false;
                }
                else
                {
                    text.text = "";
                    SceneManager.LoadScene("Main Scene");
                }
            }
            else
            {
                skip = true;
            }
        }

        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else if (_needAppear)
        {
            tipText.SetActive(true);
        }
    }

    public IEnumerator TextAppearance(string message, float appearDelay)
    {
        for (int i = 0; i <= message.Length; i++)
        {
            if (!skip)
            {
                text.text = message.Substring(0, i);
                yield return new WaitForSeconds(appearDelay);
            }
            else
            {
                text.text = message;
                break;
            }
        }

        textAppeared = true;
        _timer = tipTextDelay;
        _needAppear = true;
    }

    private void startCoroutine()
    {
        StartCoroutine(TextAppearance(messages[i], appearDelay));
    }
}
