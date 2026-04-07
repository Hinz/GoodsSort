using System;
using TMPro;
using UnityEngine;

public class GroupBlocker : MonoBehaviour
{
    [SerializeField] TMP_Text _countText;
    [SerializeField] MatchGroup _matchGroup;

    int _count;

    public void Initialize(int blockCount)
    {
        _count = blockCount;
        UpdateText();
        MatchGroup.OnMatched += OnMatch;
    }

    void OnMatch(Vector3 position)
    {
        _count--;
        UpdateText();

        if (_count <= 0)
        {
            _matchGroup.BlockerDeactivated();
            gameObject.SetActive(false);
        }
    }

    void UpdateText()
    {
        _countText.text = _count.ToString();
    }

    void OnDestroy()
    {
        MatchGroup.OnMatched -= OnMatch;
    }
}
