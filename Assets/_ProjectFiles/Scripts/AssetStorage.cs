using System.Collections.Generic;
using System.Linq;
using Egsp.Core;
using JetBrains.Annotations;
using UnityEngine;

namespace Game
{
    public class AssetStorage : SerializedSingleton<AssetStorage>
    {
        [SerializeField] private List<SpriteInfo> spriteInfos = new List<SpriteInfo>();

        [CanBeNull]
        public Sprite GetSpriteById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            Debug.Log("Поиск спрайта по идентификатору: "+ id);
            
            var sprite = spriteInfos.FirstOrDefault(x => x.Id == id)?.Sprite;
            return sprite;
        }
    }
}