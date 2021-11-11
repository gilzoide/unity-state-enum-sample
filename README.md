# State Enum Sample
A sample Unity project using a state ScriptableObject + MonoBehaviours with UnityEvents.

It uses `OnValidate` to invoke events in Editor Mode when changing the state
values in `StateSO`.
Currently, state consists of two fields: an enum value and a boolean flag.
There are two MonoBehaviour scripts, one for handling each field separately.
