//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Entitas {

    public partial class Entity {

        public ButtonComponent button { get { return (ButtonComponent)GetComponent(ComponentIds.Button); } }
        public bool hasButton { get { return HasComponent(ComponentIds.Button); } }

        public Entity AddButton(string newPrefabName, string newButtonText) {
            var component = CreateComponent<ButtonComponent>(ComponentIds.Button);
            component.prefabName = newPrefabName;
            component.buttonText = newButtonText;
            return AddComponent(ComponentIds.Button, component);
        }

        public Entity ReplaceButton(string newPrefabName, string newButtonText) {
            var component = CreateComponent<ButtonComponent>(ComponentIds.Button);
            component.prefabName = newPrefabName;
            component.buttonText = newButtonText;
            ReplaceComponent(ComponentIds.Button, component);
            return this;
        }

        public Entity RemoveButton() {
            return RemoveComponent(ComponentIds.Button);
        }
    }

    public partial class Matcher {

        static IMatcher _matcherButton;

        public static IMatcher Button {
            get {
                if(_matcherButton == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Button);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherButton = matcher;
                }

                return _matcherButton;
            }
        }
    }
}
