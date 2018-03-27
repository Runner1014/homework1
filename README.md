**1、解释 游戏对象（GameObjects）和 资源（Assets）的区别与联系。**

- **游戏对象**：出现在游戏场景中的实体，是一些资源的集合体，是资源整合的具体表现。
- **资源**：资源可以被多个对象利用，成为组件中的属性或者行为；还可以将游戏对象预设成资源，当做模板重复使用。

**2、下载几个游戏案例，分别总结资源、对象组织的结构（指资源的目录组织结构与游戏对象树的层次结构）**

- **资源**：一般包括脚本，声音，图像，预设，场景，材质等，在这些文件夹下可以继续划分；
- **游戏对象**：一般包括玩家，敌人，环境，摄像机等虚拟父类，这些父类本身为空对象，但他们的子类包含了游戏中出现的对象。

**3、编写一个代码，使用 debug 语句来验证 MonoBehaviour 基本行为或事件触发的条件**
```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	void Awake () {
		Debug.Log ("onAwake");
	}
	// Use this for initialization
	void Start () {
		Debug.Log("onStart");
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("onUpdate");
	}

	void FixedUpdate(){
		Debug.Log ("onFixedUpdate");
	}

	void LateUpdate(){
		Debug.Log ("onLateUpdate");
	}

	void OnGUI(){
		Debug.Log ("onGUI");
	}

	void OnDisable(){
		Debug.Log ("onDisable");
	}

	void OnEnable(){
		Debug.Log ("onEnable");
	}
}
```
**4、查找脚本手册，了解 GameObject，Transform，Component 对象**

- 分别翻译官方对三个对象的描述（Description）

 - GameObject ：GameObjects are the fundamental objects in Unity that represent characters, props and scenery. They do not accomplish much in themselves but they act as containers for Components, which implement the real functionality.
翻译：
游戏对象是Unity中表示游戏角色，游戏道具和游戏场景的基本对象。它们自身无法完成许多功能，但是它们充当了那些给予他们实体功能的组件的容器。

 - Transform ：The Transform component determines the Position, Rotation, and Scale of each object in the scene. Every GameObject has a Transform.
翻译: 
转换组件决定了游戏场景中每个游戏对象的位置，旋转度和大小。每个游戏对象都有转换组件。

 - Component ：Components are the nuts & bolts of objects and behaviors in a game. They are the functional pieces of every GameObject.
翻译: 
组件是游戏中对象和行为的细节。它是每个游戏对象的功能部分。



- 描述下图中 table 对象（实体）的属性、table 的 Transform 的属性、 table 的部件
本题目要求是把可视化图形编程界面与 Unity API 对应起来，当你在 Inspector 面板上每一个内容，应该知道对应 API。
例如：table 的对象是 GameObject，第一个选择框是 activeSelf 属性。

![这里写图片描述](https://pmlpml.github.io/unity3d-learning/images/ch02/ch02-homework.png)

答：
	**table对象的属性**：activeInHierarchy（表示GameObject是否在场景中处于active状态）、activeSelf（GameObject的本地活动状态）、isStatic（仅编辑器API，指定游戏对象是否为静态）、layer（游戏对象所在的图层。图层的范围为[0 … 31]）、scene（游戏对象所属的场景）、tag（游戏对象的标签）、transform（附加到这个GameObject的转换）

**table的Transform的属性**：Position、Rotation、Scale，从文档中可以了解更多关于Transform的属性

**table的部件**：Mesh Filter、Box Collider、Mesh Renderer


- 用 UML 图描述 三者的关系（请使用 UMLet 14.1.1 stand-alone版本出图）
![这里写图片描述](http://img.blog.csdn.net/20180327213628914?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvUnVubmVyMXN0/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

**5、整理相关学习资料，编写简单代码验证以下技术的实现：**

- 查找对象
```c#
//通过名字查找:
public static GameObject Find(string name)  
//通过标签查找单个对象：
public static GameObject FindWithTag(string tag)  
//通过标签查找多个对象：
public static GameObject[] FindGameObjectsWithTag(string tag)  
```
- 添加子对象
```
public static GameObject CreatePrimitive(PrimitiveTypetype)`  
```
- 遍历对象树
```c#
foreach (Transform child in transform) {  
	Debug.Log(child.gameObject.name);  
}  
```
- 清除所有子对象
```c#
foreach (Transform child in transform) {  
    Destroy(child.gameObject);  
} 
```
**6、资源预设（Prefabs）与 对象克隆 (clone)**

- 预设（Prefabs）有什么好处？

	预设相当于一个对象的模板，当某个对象需要重复出现时，用预设可以提高效率，方便管理。预设使得修改的复杂度降低，一旦需要修改所有相同属性的对象，只需要修改预设即可，所有通过预设实例化的对象都会做出相应变化。

- 预设与对象克隆 (clone or copy or Instantiate of Unity Object) 关系？

	修改预设会使通过预设实例化的所有对象都做出相应变化，而对象克隆本体和克隆出的对象是不相影响的。

- 制作 table 预制，写一段代码将 table 预制资源实例化成游戏对象
    ```c#
    void Start () {  
        GameObject anotherTable = (GameObject)Instantiate(table.gameObject);  
    }
    ``` 
    
**7、尝试解释组合模式（Composite Pattern / 一种设计模式）。**

	将对象组合成树形结构以表示“部分-整体”的层次结构，组合模式使得用户对单个对象和组合对象的使用具有一致性。组合模式实现的最关键的地方是——简单对象和复合对象必须实现相同的接口，这就是组合模式能够将组合对象和简单对象进行一致处理的原因。



- 使用 BroadcastMessage() 方法向子对象发送消息
    
父对象方法：
```c#
public class NewBehaviourScript : MonoBehaviour {
    void message() {
        Debug.Log("HelloWorld!");
    }
    void Start () {
        this.BroadcastMessage("message");
    }
}
```
 子对象方法：
```c#
public class NewBehaviourScript1 : MonoBehaviour {
    void message() {
        Debug.Log("HelloWorld!");
    }
}
```
