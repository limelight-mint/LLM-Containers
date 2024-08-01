## Unity Uni-Task lightweight content/data-related containers
<sub>Yes, IT IS better and faster than Unity coroutines</sub>

### Ok but how to actually use it?
> Required <a href="https://github.com/Cysharp/UniTask">UniTask</a> itself, so first-thing-first install a .unitypackage <a href="https://github.com/Cysharp/UniTask/releases">from this link</a>.
> Can be used for default .NET classes if you install UniTask as NuGet package. Also feel free to change whatever you want or collab.

Simple example where we have our popups inside `Popups` folder (`Assets/Resources/Popups/`), and we need to get our prefab which is `MonoContainer` inherited and called `Friend Invite Popup`:

![Popup Prefab screenshot](https://bunbun.cloud/assets/images/git/baseFactoryPrefab.png)

First create a factory, our base one or your custom one (you can inherit and override creation process for your needs):
```
_popupsFactory = new BaseResourceFactory("Popups", _popupScreenRoot.transform);
```

Lets get the `Friend Invite Popup` from `Resources/Popups/` and pass it whoever, since `MonoContainer.Data` inside is initialized and Unity `GameObject` already created:
```
var container = await _popupsFactory
.CreateInstance<FriendInvitePopup, InviteData>(new InviteData(_friend, _unixTimeRequestCreated));
```

> Remark: You can create new factories and override creation methods and you can pass any data to a container, just create class and inherit `ContainerData` (for example `public class LoginData : ContainerData`), or even pass a `null` or `new ContainerData()` if u dont need it for some reason
