using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Game
{
    public class SpriteInfo : SerializedScriptableObject
    {
        [OdinSerialize]
        public string Id { get; private set; }
        
        [OdinSerialize][PreviewField]
        public Sprite Sprite { get; private set; }
    }
}