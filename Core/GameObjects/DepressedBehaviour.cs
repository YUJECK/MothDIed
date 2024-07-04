using MothDIed.ServiceLocators;
using UnityEngine;

namespace MothDIed
{
    public abstract class DepressedBehaviour : MonoBehaviour
    {
        public readonly ServiceLocator<Component> CachedComponents = new();
        
        //If use extension system
        //public readonly ExtensionContainer ExtensionContainer = new ExtensionContainer();
    }
}