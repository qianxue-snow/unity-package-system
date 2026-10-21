# unity-package-system

**背包（物品栏）系统模块**练习：静态配置表 + 动态存档 + 面板管理三件套，是 `unity-task-system` 的姊妹篇。

```
Assets/Script/
  PackageTable.cs       ScriptableObject 配置表（Assets/Resources/TableData/PackageTable.asset）
  PackageLocalData.cs   玩家背包存档：JsonUtility 序列化 → PlayerPrefs
  PackageCell.cs        格子单元：等级信息、是否新获得、图标 Resources.Load
  PackageDetail.cs      详情：静态数据 + 动态数据 + 父物品逻辑（等级、简述…）
  PackagePanel.cs       背包面板：按 uid 找动态数据、刷详情、清滚动容器重建物品
  BasePanel.cs          面板基类
  UIManager.cs          面板管理：打开/关闭、缓存删除、检查是否已打开
  GameManager.cs        取背包表格 + 背包本地数据 + 背包静态数据
Assets/Editor/GMCmd.cs  编辑器工具：菜单「CMCmd/读取表格」「CMCmd/创建背包测试数据」
Assets/Resources/       食物 / 武器图标 PNG、PackagePanel/PackageUIItem/Stars 预制体、动画控制器
```

## 为什么这么拆

**配置（Table）/ 存档（LocalData）/ 表现（Cell·Detail·Panel）三层分离**：改数值不动存档，加格子不改数据。存档用 `JsonUtility` + `PlayerPrefs`，是最轻量的本地持久化写法。Editor 菜单负责造测试数据，不用手点预制体。

## 已知问题

- Unity **2022.3.48f1c1**，场景 `SampleScene`，单场景演示，没有游戏流程
- `Assets/TextMesh Pro`（3.4MB）是官方 TMP 包在工程内的导入副本，不是自己写的
- `.gitignore` 排除 `Library/`、`obj/`、`Logs/`、`UserSettings/`、`*.csproj`、`*.sln`
- 未做干净环境验证，clone 后能否一次跑通**【待验证】**

## 状态

学习存档，最后一次改动 2026-03-11。
