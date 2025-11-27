using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance { get; private set; }

    [System.Serializable]

    public class EffectData
    {
        public string effectName;
        public GameObject effectPrefads;
        public float defaultDuration = 2f;

    }

    [Header("이펙트 목록")]
    [SerializeField] private List<EffectData> effectList = new List<EffectData>();

    private Dictionary<string, EffectData> effectDictionary = new Dictionary<string, EffectData>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeDictionary()
    {
        effectDictionary.Clear();
        foreach (var effect in effectList)
        {
            if (!effectDictionary.ContainsKey(effect.effectName))
            {
                effectDictionary.Add(effect.effectName, effect);
            }
            else
            {
                Debug.LogWarning($"중복된 이펙트 이름 : {effect.effectName}");
            }
        }
    }

    public GameObject PlayEffect(string effecName, Vector3 position, Quaternion rotation)
    {
        if (effectDictionary.TryGetValue(effecName, out EffectData data))
        {
            GameObject effect = Instantiate(data.effectPrefads, position, rotation);
            Destroy(effect, data.defaultDuration);
            return effect;
        }
        else
        {
            Debug.LogWarning($"이펙트를 찾을 수 없습니다. : {effecName}");
            return null;
        }
    }

    public GameObject PlayEffect(string effecName, Vector3 position, Quaternion rotation, float duration)
    {
        if (effectDictionary.TryGetValue(effecName, out EffectData data))
        {
            GameObject effect = Instantiate(data.effectPrefads, position, rotation);
            Destroy(effect, duration);
            return effect;
        }
        else
        {
            Debug.LogWarning($"이펙트를 찾을 수 없습니다. : {effecName}");
            return null;
        }

    }

    public GameObject PlayEffect(string effecName, Vector3 position)
    {
        return PlayEffect(effecName, position, Quaternion.identity);
    }
    public GameObject PlayEffect(string effecName, Vector3 position, float duration)
    {
        return PlayEffect(effecName, position, Quaternion.identity, duration);
    }



    public void PlayEffectWithDelay(string effecName, Vector3 position, Quaternion rotaion, float delay, float duartion)
    {
        StartCoroutine(PlayEffectWithDelay(effecName, position, rotaion, delay, duartion));
    }

    private IEnumerator PlayEffectWithDelay(string effecName, Vector3 position, Quaternion rotaion, float delay, float duartion)
    {
        yield return new WaitForSeconds(delay);

        if (duartion > 0)
        {
            PlayEffect(effecName, position, rotaion, duartion);
        }
        else
        {
            PlayEffect(effecName, position, rotaion);
        }
        

        
    }

}






