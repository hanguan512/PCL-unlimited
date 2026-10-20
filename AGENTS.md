# AGENTS.md

PCL-unlimited：龙腾猫跃 PCL2 的第三方修改版（fork 自 Meloong-Git/PCL）。主体是**老式（非 SDK）VB.NET WPF 工程**（`Plain Craft Launcher 2/`，.NET Framework 4.8），另有 SDK 风格 C# 工程 `PCLCS/` 与子模块 `MeloongCore/`。仓库无自动化测试，验证方式 = 编译 + 启动 exe 手动操作。

## 构建命令

前置（本机已装）：VS 2022 Build Tools（MSBuild 17.14）+ .NET 9 SDK；子模块需先初始化：

```powershell
git submodule update --init --recursive
$env:PATH = "C:\Program Files\dotnet;$env:PATH"   # 必需，否则 SDK 工程还原报 "No .NET SDKs were found"
& "C:\Program Files (x86)\Microsoft Visual Studio\2022\BuildTools\MSBuild\Current\Bin\MSBuild.exe" "Plain Craft Launcher 2.sln" /t:Restore,Build /p:Configuration=Release /p:Platform="Any CPU" /m /v:m /nologo
```

- 输出：`Plain Craft Launcher 2\bin\Plain Craft Launcher 2.exe`（单文件可独立运行，会在旁边生成 `PCL\`、`.minecraft\`）。
- `MSB3884`（缺 ruleset）警告可忽略。
- 不要用 `dotnet build` 构建主工程（非 SDK 风格）；CI（`.github/workflows/build.yml`）同样是 msbuild vbproj，产物取 `obj\<cfg>\` 下的 exe。
- 用户设置存于 exe 旁 `PCL\Setup.ini` 与注册表 `HKCU\Software\PCLDebug`，删除可重置测试状态。

## 编码陷阱（重要，容易踩）

- 源码为**混合编码**：大多为 UTF-8（无 BOM）。**禁止**用 PowerShell `Get-Content`/`Set-Content` 不带显式编码地改写源码——会按 ANSI 往返导致全部中文乱码（只能 `git checkout` 找回）；脚本改文件用 `[IO.File]::ReadAllText/WriteAllText` 并显式 UTF8。
- `.vb` 字符串里**不要写字面弯引号 `“”`、`·`、`→`**：会以 BC32017/BC30037 等莫名语法错误编译失败。仓库惯例：弯引号用 `vbLQ`/`vbRQ` 拼接，其余用 ASCII `-`。XAML（UTF-8）不受此限制。
- `git diff --check` 会把 CRLF 报成行尾空白，属常态噪音，忽略。

## 分支与发布

- `main` = 开发；`release` = 可分发状态（发版时 `git switch release && git merge main && git push`，再打 tag）。
- `dist/` 被 git 忽略；分发构建复制到 `dist\PCL-unlimited <版本>\`，包内必须附带 `LICENCE`、`THIRD-PARTY-NOTICES.txt`、`licenses/LGPL-3.0.txt`。

## 许可红线（不要破坏，详见 `LICENCE`）

- 关于页**首位**保留龙腾猫跃署名 + 赞助按钮；保留 `ModLaunch.vb` 的 `McLaunchPrecheck`；默认主题保持蓝色；保持“第三方修改版”标识与免费分发。

## 本 fork 特有架构

- `ModSecret.vb`：开源版的密钥/配置桩。`RestrictMcDownload=False` 恢复 MC 下载；`VersionBranchMain="OpenSource"` 控制 FormMain.xaml.vb（约 450 行）启动时的免责声明弹窗。
- `ModLinkConfig.vb`：联机内置配置（EasyTier v2.6.4 与社区节点 `https://etnode.zkitefly.eu.org/node1`），替代 PCL 官方 ServerConfig。
- `PageLinkMain.xaml.vb`：联机 = EasyTier 虚拟局域网。内置资源 `EasyTier.zip`（x86_64 精简包）首次使用时释放到 `%APPDATA%\PCL\EasyTier\` 并改名 `联机模块.exe / 联机模块 CLI.exe`；非 x86_64 或缺失时回退联网下载（`LinkConfig("Downloads")`）。踢出 = Windows 防火墙 COM（`CreateObject("HNetCfg.FwPolicy2")` 晚绑定，规则名 `PCL-unlimited Link Kick <ip>`，关房自动清理）。玩家名 hex 编码放进 EasyTier hostname（`PCL{H|C}-<hex名字>-<hash>`），`Peer` 类负责解码。
- 版本号：显示名 `ModBase.vb:VersionBaseName`（现为 `2.99.0.0-unlimited`）；`VersionCode` 413=Release / 414=Snapshot。

## 已知问题

- 无签名 exe 会被部分杀软启发式报毒（下载执行、隧道、防火墙修改等特征）。不要再引入 `netsh` 调用、运行时下载执行等行为；EasyTier 已内置进 exe。
