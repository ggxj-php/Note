# 文本处理工具

一个基于 .NET WinForms 的文本处理工具，提供文本批量去重和中文分词两大功能。

## 功能特点

### 1. 文本批量去重
- ✅ 递归遍历源文件夹
- ✅ 对每个文件按行去重（保留第一行，删除重复行）
- ✅ 保持原有目录结构
- ✅ 自动创建目标文件夹

### 2. 中文分词
- ✅ 基于 Jieba.NET 的中文分词
- ✅ 自动配置词典路径（跨电脑兼容）
- ✅ 分词结果使用 Tab 分隔显示
- ✅ 异常捕获和日志记录

### 3. 日志系统
- ✅ 操作日志实时记录
- ✅ 异常信息完整记录
- ✅ 按日期自动归档（`Log/yyyy-MM-dd.txt`）

## 技术栈

- **框架**: .NET 10.0 (net10.0-windows)
- **UI**: Windows Forms (WinForms)
- **分词库**: Jieba.NET 0.42.2
- **架构**: 接口 + 实现分离

## 项目结构

```
f:\Note/
├── API/                      # 接口定义
│   ├── JiebaInterface.cs     # 分词接口
│   ├── LogInterface.cs       # 日志接口
│   └── ReplaceInterface.cs   # 去重接口
├── Implements/               # 接口实现
│   ├── ImpJieba.cs           # 分词实现
│   │   ├── 动态配置词典路径（相对路径）
│   │   ├── 异常捕获和日志记录
│   │   └── 分词结果日志记录
│   ├── ImpLog.cs             # 日志实现
│   └── ImpReplace.cs         # 去重实现
├── UI/                       # UI 层
│   └── MainForm.cs           # WinForms 主窗体
│       ├── 批量去重功能区
│       ├── 中文分词功能区
│       └── 异常提示框
├── Log/                      # 日志目录
│   ├── 2026-06-04.txt        # 历史日志
│   └── 2026-06-05.txt        # 当天日志
├── Main.cs                   # 程序入口
└── Note.csproj               # 项目配置
```

## 使用方法

### 1. 编译项目

```bash
dotnet build
```

### 2. 运行程序

```bash
dotnet run
```

### 3. 功能使用

#### 文本批量去重
1. 在"源文件夹路径"输入源目录（如：`C:\source`）
2. 在"目标文件夹路径"输入目标目录（如：`C:\target`）
3. 点击"开始去重"按钮
4. 完成后会显示提示框

#### 中文分词
1. 在"输入文本"框输入中文内容（如：`我爱北京天安门`）
2. 点击"分词"按钮
3. 在"分词结果"区域查看结果（Tab 分隔）

## 词典配置

### 跨平台兼容性

词典文件在编译时自动从 NuGet 包复制到输出目录的 `Resources` 文件夹：

```xml
<ItemGroup>
  <None Include="$(NuGetPackageRoot)jieba.net\0.42.2\Resources\*" 
        CopyToOutputDirectory="PreserveNewest" 
        Link="Resources\%(Filename)%(Extension)" />
</ItemGroup>
```

### 动态路径配置

程序运行时自动查找词典路径：

```csharp
string appDir = AppDomain.CurrentDomain.BaseDirectory;
string dictPath = Path.Combine(appDir, "Resources");
JiebaNet.Segmenter.ConfigManager.ConfigFileBaseDir = dictPath;
```

**优点**：
- ✅ 编译时自动复制词典
- ✅ 运行时自动查找路径
- ✅ 跨电脑无需手动配置

## 日志记录

### 日志内容

所有操作和异常都会记录到日志文件：

```
[时间戳]分类 日志内容
```

**示例**：
```
[19:45:17]分词统计 目标文本:你好世界
[19:45:17]分词结果 分词数量:2 结果:你好|世界
[19:46:20]去重异常 错误信息:目录不存在 异常类型:DirectoryNotFoundException
```

### 日志位置

`./Log/yyyy-MM-dd.txt`（按日期自动归档）

## 依赖项

| 包名 | 版本 | 用途 |
|------|------|------|
| jieba.NET | 0.42.2 | 中文分词 |
| Newtonsoft.Json | 12.0.3 | JSON 处理 |

## 异常处理

程序实现了完整的异常捕获和日志记录：

- **ImpJieba.cs**: 分词异常 → 记录日志 → 抛出异常
- **MainForm.cs**: 
  - 去重异常 → 记录日志 → 显示错误提示框
  - 分词异常 → 记录日志 → 显示错误提示框

**日志格式**：
```
[分类] 错误信息:xxx 异常类型:xxx
```

## 编译说明

### 环境要求
- .NET 10.0 SDK 或更高版本
- Windows 操作系统

### 编译命令

```bash
# 清理并重新编译
dotnet clean
dotnet build

# 运行
dotnet run
```

### 输出目录

编译后的文件位于：
```
f:\Note\bin\Debug\net10.0-windows\
├── Note.exe           # 可执行文件
├── Resources/         # 词典文件夹（自动生成）
│   ├── dict.txt       # 主词典
│   ├── idf.txt        # IDF 文件
│   └── ...            # 其他词典文件
└── Log/               # 日志文件夹（运行时创建）
```

## 注意事项

1. **路径输入**：UI 中使用文本框输入路径，不支持浏览按钮
2. **日志记录**：所有操作和异常都会记录，便于排查问题
3. **词典兼容性**：词典文件由编译时自动复制，跨电脑使用时需确保 NuGet 包已安装
4. **异常处理**：操作失败时会显示详细错误信息，并记录到日志

## 许可证

MIT License
