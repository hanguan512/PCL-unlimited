Imports Newtonsoft.Json.Linq

''' <summary>
''' 联机功能的内置配置，不依赖 PCL 官方服务器。
''' 联机基于开源项目 EasyTier（LGPL-3.0）实现：
''' 房间由随机网络名与网络密钥标识，设备身份由本机稳定标识生成，不需要任何账号。
''' </summary>
Friend Module ModLinkConfig

    ''' <summary>
    ''' 返回联机功能配置。
    ''' 节点会优先从社区节点 API 自动选择；若获取失败，则使用这里的回退节点。
    ''' 用户也可以在“设置 → 联机 → 自定义节点”中填写自己的 EasyTier 节点。
    ''' </summary>
    Public Function GetLinkConfig() As JObject
        Return JObject.Parse(
            "{" &
            """EasyTierVersion"":264," &
            """Argument"":""--console-log-level=warn --file-log-level=off""," &
            """DiscoverPeer"":""https://etnode.zkitefly.eu.org/node1""," &
            """DiscoverPeerId"":0," &
            """RandomPeer"":0," &
            """Peers"":[" &
            """https://etnode.zkitefly.eu.org/node1""" &
            "]," &
            """MandatoryPeers"":[]," &
            """PeersBlackList"":[]," &
            """Downloads"":[" &
            """https://github.com/EasyTier/EasyTier/releases/download/v2.6.4/easytier-windows-{arch}-v2.6.4.zip""," &
            """https://ghfast.top/https://github.com/EasyTier/EasyTier/releases/download/v2.6.4/easytier-windows-{arch}-v2.6.4.zip""," &
            """https://gh-proxy.com/https://github.com/EasyTier/EasyTier/releases/download/v2.6.4/easytier-windows-{arch}-v2.6.4.zip""" &
            "]" &
            "}")
    End Function

End Module
