using UnityEngine;

public class CharacterNearby : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Entity"))
        {
            _audioSource.PlayOneShot(_audioSource.clip);
            _animator?.SetBool("character_nearby", true);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Entity"))
        {
            _audioSource.PlayOneShot(_audioSource.clip);
            _animator?.SetBool("character_nearby", false);
        }
    }
}