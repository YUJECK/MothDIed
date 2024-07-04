using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using MothDIed.Core.GameObjects;
using MothDIed.GameObjects;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MothDIed.Scenes
{
    public class GameFabric
    {
        public event Action<Object> OnInstantiated;
        public event Action<Object> OnDestroyed;
        
        public event Action<GameObject> OnGameObjectInstantiated;
        public event Action<GameObject> OnGameObjectDestroyed;

        private GameFabricSceneModule[] modules;

        public void RefreshModules()
        {
            modules = Game.CurrentScene.Modules.GetAllOfType<GameFabricSceneModule>();
        }
        
        public virtual UniTask<TObject> Instantiate<TObject>(TObject original, Vector3 position)
            where TObject : Object
        {
            return Instantiate(original, position, Quaternion.identity, null);
        }

        public virtual UniTask<TObject> Instantiate<TObject>(TObject original, Vector3 position, Transform parent)
            where TObject : Object
        {
            return Instantiate(original, position, Quaternion.identity, parent);
        }

        public virtual UniTask<TObject> Instantiate<TObject>(TObject original, Vector3 position, Quaternion rotation)
            where TObject : MonoBehaviour
        {
            return Instantiate(original, position, rotation, null);
        }

        public virtual async UniTask<TObject> Instantiate<TObject>(TObject original, Vector3 position, Quaternion rotation,
            Transform parent)
            where TObject : Object
        {
            var instance = Object.Instantiate(original, position, rotation, parent);

            foreach (var module in modules)
            {
                await module.OnInstantiated(instance);
            }

            OnInstantiated?.Invoke(instance);
            InvokeGameObjectEventsIfGameObject();

            return instance;

            void InvokeGameObjectEventsIfGameObject()
            {
                if (instance is GameObject gameObject)
                {
                    OnGameObjectInstantiated?.Invoke(gameObject);
                }
                else if (instance is Component component)
                {
                    OnGameObjectInstantiated?.Invoke(component.gameObject);
                }
            }
        }

        public virtual async UniTask Destroy(Object toDestroy)
        {
            foreach (var module in modules)
            {
                await module.OnWillBeDestroyed(toDestroy);
            }
            
            OnDestroyed?.Invoke(toDestroy);
            
            if(toDestroy is GameObject gameObject)
            {
                OnGameObjectDestroyed?.Invoke(gameObject);
            }
            
            Object.Destroy(toDestroy);
        }
    }
}