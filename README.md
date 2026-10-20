# PCL-unlimited

[![Stars](https://img.shields.io/github/stars/hanguan512/PCL-unlimited?style=flat&label=Stars&labelColor=444444&color=eac54f)](https://github.com/hanguan512/PCL-unlimited)
[![Issues](https://img.shields.io/github/issues/hanguan512/PCL-unlimited?style=flat&label=Issues&labelColor=444444&color=1F883D)](https://github.com/hanguan512/PCL-unlimited/issues)

> **第三方修改版**：本仓库是 [Plain Craft Launcher (PCL)](https://github.com/Meloong-Git/PCL) 的第三方修改版，并非 PCL 官方发布，与 PCL 官方团队无关。

## 关于这个版本

PCL-unlimited 在 PCL 的基础上做了一些让启动器更自由、更好用的修改：

- **恢复 Minecraft 下载**：重新提供原版游戏与组件的下载入口；
- **联机功能**：基于开源 [EasyTier](https://github.com/EasyTier/EasyTier)（LGPL-3.0）的虚拟局域网，无需账号，凭邀请码加入；支持房间玩家列表、MC 用户名显示与房主踢出玩家；
- **内置联机组件**：EasyTier 与国内公共节点随程序内置，首次使用无需从 GitHub 下载；
- **第三方标识与免责声明**：窗口标题、程序集、关于页均标明第三方修改版，启动时展示免责声明；
- **关于页**：补充原项目、本仓库、维护者与许可信息。

## 游戏是自由的

我们相信，游戏应当是自由的。玩家有权获取、保存并游玩自己喜爱的游戏，而不应被平台、地区或商业限制所束缚。恢复 Minecraft 下载功能，正是为了让玩家能够更方便地获取游戏文件。

请在使用时遵守 Minecraft 最终用户许可协议（EULA）与所在地区的法律法规，并通过正版渠道支持游戏开发者。

## 下载与反馈

- 源码与发布：[hanguan512/PCL-unlimited](https://github.com/hanguan512/PCL-unlimited)
- 反馈 QQ 群：**839898455**
- 原项目：[Meloong-Git/PCL](https://github.com/Meloong-Git/PCL)

## 构建

需要 Visual Studio 2022 Build Tools（MSBuild）与 .NET SDK，并初始化 `MeloongCore` 子模块。具体命令见 [AGENTS.md](AGENTS.md)。

## 许可与版权

- **PCL 原项目**：版权归龙腾猫跃及贡献者所有，遵循仓库内 `LICENCE` 中的《PCL 分发有限许可》与《PCL 存储库合理使用指南》；
- **本修改版**：作为第三方二次创作免费分发，保留原项目署名与赞助链接，并公开源代码；
- **EasyTier**：Copyright © 2024-present Easytier Programme within The Commons Conservancy，LGPL-3.0，详见 [THIRD-PARTY-NOTICES.txt](THIRD-PARTY-NOTICES.txt) 与 [licenses/LGPL-3.0.txt](licenses/LGPL-3.0.txt)。

> 本软件按“现状”提供，使用产生的一切后果由使用者自行承担。请支持正版 Minecraft。
