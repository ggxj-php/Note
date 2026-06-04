# 文本批量去重工具

一个基于 .NET 的文本批量去重工具，支持递归遍历文件夹并对每个文件进行按行去重操作。

## 功能特点

- ✅ 递归遍历文件夹
- ✅ 按行去重（保留第一行，删除重复行）
- ✅ 保持目录结构不变
- ✅ 操作日志记录
- ✅ 支持 Jieba.NET 中文分词测试

## 项目结构

```
├── API/                    # 接口定义
│   ├── LogInterface.cs     # 日志接口
│   └── ReplaceInterface.cs # 去重接口
├── Implements/             # 实现类
│   ├── ImpLog.cs           # 日志实现
│   └── ImpReplace.cs       # 去重实现
├── debug.cs                # 主程序入口
└── Note.csproj             # 项目配置
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

### 3. 使用流程

```
=== 文本批量去重工具 ===
请输入源文件夹路径: C:\source
请输入目标文件夹路径: C:\target

开始批量去重...
处理: C:\source\file1.txt -> C:\target\file1.txt
处理: C:\source\subdir\file2.txt -> C:\target\subdir\file2.txt
批量去重完成
```

## 日志记录

操作日志会自动保存到 `./Log/yyyy-MM-dd.txt` 文件中。

## 依赖

- .NET 10.0 或更高版本
- Jieba.NET 0.42.2（可选，用于中文分词测试）

## 安装 Jieba.NET

```bash
dotnet add package jieba.NET
```

安装后需要将 Jieba.NET 的字典文件复制到输出目录。

## 许可证

MIT License
