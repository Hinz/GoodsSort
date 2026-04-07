using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

public class StarController : IStartable
{
    readonly ComboController _comboController;

    readonly List<GameObject> particles = new();

    [UnityEngine.SerializeField] GameObject starParticlePrefab;
    [UnityEngine.SerializeField] List<Transform> attractorTargets;

    public StarController(ComboController comboController)
    {
        _comboController = comboController;
    }

    public void Start()
    {
        MatchGroup.OnMatched += OnMatch;
    }

    void OnMatch(Vector3 worldPosition)
    {
        int count = GetParticleCount();
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPosition);

        for (int i = 0; i < count; i++)
        {
            if (starParticlePrefab == null || attractorTargets == null || attractorTargets.Count == 0) break;
            var particle = UnityEngine.Object.Instantiate(starParticlePrefab, screenPos, UnityEngine.Quaternion.identity);
            particles.Add(particle);
        }
    }

    int GetParticleCount()
    {
        int combo = _comboController.GetComboCount();
        if (combo >= 10) return 3;
        if (combo >= 5) return 2;
        return 1;
    }

    public void DestroyParticle()
    {
        if (particles.Count > 0)
        {
            UnityEngine.Object.Destroy(particles[0]);
            particles.RemoveAt(0);
        }
    }
}
