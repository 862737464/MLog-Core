using MLog;
using MLog.Test;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            基本使用();
            写入指定文件夹下();
            不同日志级别和格式();
            设置日志级别();
            异常捕获();
            简单的泛型实体();
            性能测试();
        }
        static void 基本使用()
        {
            Log.Debug().Debug($"{"Hello, World!"}");
            Log.Info().Info("Hello, World!");
            Log.Warn().Warn("Hello, World!");
            Log.Error().Error("Hello, World!");
            Log.Info().Fatal("Hello, World!");
        }
        static void 写入指定文件夹下()
        {
            Log.Info("我是文件夹").Info("Hello, World!");
        }
        static void 不同日志级别和格式() 
        {
            string value1 = "测试数据1";
            int value2 = 42;
            // Debug - 白色占位符
            Log.Debug("我是业务名\\Debug").Debug($"调试信息: {value1}, {value2}");
            // Info - 绿色占位符
            Log.Info("我是业务名\\Info").Info(string.Format("普通信息: {0}, {1}", value1, value2));
            // Warn - 黄色占位符
            Log.Warn("我是业务名\\Warn").Warn($"警告信息: {value1}, {value2}");
            // Error - 洋红色占位符
            Log.Error("我是业务名\\Error").Error($"错误信息: {value1}, {value2}");
            // Fatal - 红色占位符
            Log.Fatal("我是业务名\\Fatal").Fatal($"致命错误: {value1}, {value2}");
        }
        static void 设置日志级别() 
        {
            LogHelper.SetLogLevel(LogType.INFO);
            // 禁用控制台输出
            LogHelper.EnableConsoleOutput(false);
            // 测试日志
            string value = "测试数据";
            // 不会显示，因为级别低于 Info
            Log.Debug().Debug($"调试信息: {value}");
            // 会显示，因为级别大于等于 Info
            Log.Info().Info($"普通信息: {value}");
            Log.Warn().Warn($"警告信息: {value}");
            Log.Error().Error($"错误信息: {value}");
            Log.Fatal().Fatal($"致命错误: {value}");
        }
        static void 异常捕获() 
        {
            try
            {
                Convert.ToInt16("asd");
            }
            catch (Exception ex)
            {
                // Fatal - 红色占位符
                Log.Error().Error(ex);
            }
        }
        static void 性能测试() 
        {
            LogPerformanceTest.RunTest();
        }
        static void 简单的泛型实体() 
        {
            LoginService login = new LoginService();
            login.Start();
        }
    }
}
