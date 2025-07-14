using UnityEngine;

[CreateAssetMenu(menuName = "Game/SceneConfig")]
public class SceneConfig : ScriptableObject
{
    [System.Serializable]
    public struct Mapping
    {
        public Type Type;
        public string Name;
    }

    [SerializeField] private Mapping[] _mapping;

    public string Get(Type type)
    {
        foreach (Mapping mapping in _mapping)
        {
            if (mapping.Type == type)
            {
                return mapping.Name;
            }
        }
        
        return null;    
    }
}

public enum Type
{
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
