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

        static readonly NewPatientComponent newPatientComponent = new NewPatientComponent();

        public bool isNewPatient {
            get { return HasComponent(ComponentIds.NewPatient); }
            set {
                if(value != isNewPatient) {
                    if(value) {
                        AddComponent(ComponentIds.NewPatient, newPatientComponent);
                    } else {
                        RemoveComponent(ComponentIds.NewPatient);
                    }
                }
            }
        }

        public Entity IsNewPatient(bool value) {
            isNewPatient = value;
            return this;
        }
    }

    public partial class Matcher {

        static IMatcher _matcherNewPatient;

        public static IMatcher NewPatient {
            get {
                if(_matcherNewPatient == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.NewPatient);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherNewPatient = matcher;
                }

                return _matcherNewPatient;
            }
        }
    }
}
