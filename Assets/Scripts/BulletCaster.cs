using UnityEngine;

public class BulletCaster : MonoBehaviour
{
    public float shotSoundVolume = 1f;
    public float fireRate = 0.05f;

    public Bullet BulletPrefab;
    public Transform bulletSource;
    public Animator AimAnimator;

    public GameObject aimText;
    public GameObject shootText;
    public GameObject pickUpText;
    public GameObject interactText;
    public GrenadeCaster grenadeCaster;

    private float _timer;

    private AudioSource _audioSource;
    private Animator _charAnimator;

    private bool _buttonIsDown;

    private void Start()
    {
        InitVariables();
    }

    void Update()
    {
        AimAnimator.SetBool("Aiming", false);
        _charAnimator.SetBool("Aiming", false);
        _charAnimator?.SetFloat("ShootingOrNot", 0);


        _timer -= Time.deltaTime;
        if (Input.GetMouseButton(0) && _charAnimator?.GetFloat("RunningOrNot") < 0.5)
        {
            _charAnimator?.SetFloat("ShootingOrNot", 1);
            if (_timer <= 0)
            {
                _timer = fireRate;
                Shoot();
            }
        }
        Aiming();
    }

    private void InitVariables()
    {
        _audioSource = GetComponent<AudioSource>();

        if (transform.childCount == 0) return;
        var child = transform.GetChild(0).gameObject;

        _charAnimator = child.GetComponent<Animator>();
        if (!_charAnimator)
            _charAnimator = child.AddComponent<Animator>();
    }

    private void Aiming()
    {
        if (Input.GetMouseButton(1) && _charAnimator?.GetFloat("RunningOrNot") < 0.5)
        {
            AimAnimator.SetBool("Aiming", true);
            _charAnimator?.SetBool("Aiming", true);

            if (aimText != null && _buttonIsDown)
            {
                Destroy(aimText);
                shootText.SetActive(true);
            }
        }
    }

    private void Shoot()
    {
        _audioSource.PlayOneShot(_audioSource.clip, shotSoundVolume);

        var bullet = Instantiate(BulletPrefab, bulletSource.position, bulletSource.rotation);

        if (shootText != null && aimText == null)
        {
            Destroy(shootText);
            if (!grenadeCaster._pickUpTextShowed)
            {
                pickUpText.SetActive(true);
            }
        }
    }

    public void ButtonIsDown()
    {
        _buttonIsDown = true;
    }
}
