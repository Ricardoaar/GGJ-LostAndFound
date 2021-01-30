using UnityEngine;

namespace _scripts
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Custom/lvl", order = 0)]
    public class LvlConfigurator : ScriptableObject
    {
        public Color PlayerColor;
    }
}