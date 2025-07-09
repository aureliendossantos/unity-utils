# Unity Utils

Various utility functions and classes I use across my Unity projects.

## Installation

This package needs [NaughtyAttributes](https://github.com/dbrizov/NaughtyAttributes). In Unity, go to **Package Manager > Install package from git URL**, then paste one URL after the other:

```
https://github.com/dbrizov/NaughtyAttributes.git#upm
```

```
https://github.com/aureliendossantos/unity-utils.git
```

Note that the package must be **manually updated** when a new version is available.

## Usage

### Utils

Add `using static Utils;` to access utility functions without the `Utils` prefix:

```csharp
using static Utils;

Color newColor = ChangeColorOpacity(myColor, 0.5f);
GameObject randomItem = RandomElement(myList);
```

### StateMachine

Inherit from `StateMachine` and override `InitialState`. Create states by inheriting from `State`:

```csharp
public class MyStateMachine : StateMachine
{
    protected IdleState idleState;
    protected override State InitialState => idleState;

    void Awake() {
        idleState = new(this);
    }
}

public class IdleState : State
{
    public IdleState(string name, StateMachine stateMachine) : base(name, stateMachine) { }

    public override void Enter() { /* On state entry */ }
    public override void UpdateLogic() { /* Update() */ }
    public override void UpdatePhysics() {/* LateUpdate() */}
    public override void Exit() { /* On state exit */ }
}
```
