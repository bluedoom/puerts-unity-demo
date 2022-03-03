import { System } from "csharp";

require('./browser-source-map-support')


const findPath = new RegExp(`/*\\w+:*[\\\\/](\\w+[\\\\/])*(\\w+\\.\\w+:\\d+:\\d*)`);
//@ts-ignore
sourceMapSupport.install({
    // 浏览器版本需要你自己提供map数据，这里直接用.Net的API来加载。
    retrieveSourceMap: function(source: string) {
        if(System.IO.File.Exists(`${source}.map`))
        {
            return {
                url: source,
                map: System.IO.File.ReadAllText(`${source}.map`),
              };
        }
    },
    // 这个是用来把文件路径转换为 Unity Console Hyperlink，这个功能并非官方支持：https://github.com/bluedoom/node-source-map-support
    postprocessLocation :function (line:string) {
        let match = findPath.exec(line);
        if (match != null) {
            let path = match[0];
            line = line.replace(match[0], `<a path="${path.startsWith("/") ? path.slice(1) : path}"> ${match[2]}</a>`);
        }
        return line;
    }
});