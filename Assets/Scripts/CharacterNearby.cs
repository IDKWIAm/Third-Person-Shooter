using UnityEngine;

public class CharacterNearby : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = gameObject.transform.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Entity"))
        {
            _animator?.SetBool("character_nearby", true);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Entity"))
        {
            _animator?.SetBool("character_nearby", false);
        }
    }
}