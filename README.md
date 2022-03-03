# Puerts Unity Dev Demo

该仓库由[puerts_unity_demo](https://github.com/chexiongsheng/puerts_unity_demo)精简而来，用于尝试解决开发过程中遇到的一些问题。
# 改动
## 直接加载output中的js文件

增加了一个[DevelopmentLoader](Assets/Scripts/DevelopmentLoader.cs)用于加载在TsProj/output中和TsProj/JsLib中的文件。这里主要是想直接使用`tsc -w`来编译Ts文件，加快迭代速度。

## Source Map 和 Unity Console Hyperlink 支持

这里使用了浏览器版本的[Source Map Support](TsProj/JsLib/Editor/browser-source-map-support.js)，不需要NodeJs和其他依赖，初始化的代码在[这里](TsProj/src/InitSourceMapSupport.ts)。
\
Hyperlink的C#回调在[这里](Assets/Scripts/Editor/SourceMapSupport.cs)，默认使用VsCode打开。
#

开发平台：Windows \
开发工具：VSCode1.63.0
