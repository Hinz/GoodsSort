using UnityEngine;

public class PopEffectController : MonoBehaviour
{
    [SerializeField] GameObject triplePopEffect;

    void OnEnable()
    {
        MatchGroup.OnMatched += OnMatch;
    }

    void OnDisable()
    {
        MatchGroup.OnMatched -= OnMatch;
    }

    void OnMatch(Vector3 worldPosition)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPosition);
        var effect = Instantiate(triplePopEffect, screenPos, Quaternion.identity);
        Destroy(effect, 2f);
    }
}
