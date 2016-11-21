# Unity Utility
This is a repository of a bunch of utility classes that I find useful to use in Unity and include in most of my projects. It has grown over time and will continue to grow. It includes both useful classes taken from the internet, and code written by me

## Outline
### CustomMonoBehaviour
MonoBehaviour-derived base class with useful methods for common calculations with vectors and transforms, as well as cached version of component access methods

### PooledMonoBehaviour
MonoBehaviour-derived base class that can be pooled. Derives from CustomMonoBehaviour. Must have an empty GameObject tagged "Pools" in your scene, then can get an instance of a pooled MonoBehaviour like:
Foo bar = fooPrefab.GetPooledInstance<Foo>();

### RangeDictionary
Dictionary which enables getting all values whose keys are between a maximum and minimum value

### MathExtensions
True modulus functions which always return a value between 0 and m, such that mod(-1, 4) returns 3 and mod(-2, 4) returns 2

### MonoBehaviourExtended
Helper functions for manipulating transforms and other extension methods

### Synchronized
Thread-safe versions of various data structures as well as System.Random and CustomMonoBehaviour

### Tuple
Tuples that work in Unity
