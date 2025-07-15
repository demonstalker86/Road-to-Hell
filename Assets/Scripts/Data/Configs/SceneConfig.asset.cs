using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;


#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(menuName = "Game/SceneConfig")]
public class SceneConfig : ScriptableObject
{
    [System.Serializable]
    public struct SceneMapping
    {
        public SceneType Type;
        public string SceneName;
    }

    [SerializeField] private SceneMapping[] _mappings = Array.Empty<SceneMapping>();

    private Dictionary<SceneType, string> _sceneDictionary;
    private bool _isInitialised;

    public string GetSceneName(SceneType type)
    {
        InitializeIfNeeded();

        if (_sceneDictionary.TryGetValue(type, out var sceneName))
        {
            return sceneName;
        }

        Debug.LogError($"»м€ сцены дл€ типа {type} не найдено в конфигурации!", this);

        return null;
    }

    private void InitializeIfNeeded()
    {
        if (_isInitialised)
        {
            return;
        }

        _sceneDictionary = new Dictionary<SceneType, string>();

        foreach (SceneMapping mapping in _mappings)
        {
            if (_sceneDictionary.TryAdd(mapping.Type, mapping.SceneName) == false)
            {
                Debug.LogWarning($"ќбнаружена повтор€юща€с€ запись дл€ типа {mapping.Type}", this);
            }
        }

        _isInitialised = true;
    }

    internal IEnumerable<SceneType> GetDuplicateTypes()
    {
        return _mappings
            .GroupBy(m => m.Type)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key);
    }

#if UNITY_EDITOR
    private void OnEnable() => InitializeIfNeeded();
    private void OnValidate() => InitializeIfNeeded();
    #endif
}

public enum SceneType
{
    None = 0,
    MyMenu,
    GameMode,
    Level1,
    Level2,
    Level3,
    DoomsDay,
    Motorcycle,
    Moonlight,
    TankParade,
    Poligon,
    WaterWorld,
    AirWorld,
    SpaceWorld
}

#if UNITY_EDITOR
[CustomEditor(typeof(SceneConfig))]
public class SceneConfigEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var config = (SceneConfig)target;

        var duplicates = config.GetDuplicateTypes();

        var duplicateList = duplicates.ToList();

        if (duplicateList.Any())
        {
            EditorGUILayout.HelpBox(
                $"ќбнаружены повтор€ющиес€ типы: {string.Join(", ", duplicateList)}",
                MessageType.Error
            );
        }
    }
}
#endif