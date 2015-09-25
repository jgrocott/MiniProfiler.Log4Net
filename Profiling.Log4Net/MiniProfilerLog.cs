﻿using log4net;
using StackExchange.Profiling;

namespace Profiling.Log4Net
{
    /// <summary>
    /// MiniProfiler Extension for log by Log4net
    /// </summary>
    public static class MiniProfilerLog
    {
        /// <summary>
        /// Setup profiler with log4Net-logger and log level
        /// </summary>
        /// <param name="logger">Instance of log4net <see cref="ILog"/>. Default with name 'Log4NetProfiler'</param>
        /// <param name="profilerLogLevel">Level which identified as Profiler message writable. Default == <see cref="Log4NetLevels.Debug"/></param>
        public static void SetUpLog4Net(ILog logger = null, Log4NetLevels profilerLogLevel = Log4NetLevels.Debug)
        {
            var currentProvider = MiniProfiler.Settings.ProfilerProvider as Log4NetProfilerProvider;

            if (logger == null || currentProvider == null || !currentProvider.IsSameLogger(logger, profilerLogLevel))
            {
                var provider = new Log4NetProfilerProvider(logger ?? LogManager.GetLogger("Log4NetProfiler"), profilerLogLevel);
                MiniProfiler.Settings.ProfilerProvider = provider;
            }
        }
    }
}