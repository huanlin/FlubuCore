using System;
using System.Collections.Generic;
#if !NETSTANDARD1_6
using System.Drawing;
#endif
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using FlubuCore.Context;
using FlubuCore.Infrastructure;
using FlubuCore.Scripting;
using FlubuCore.Tasks;

namespace FlubuCore.Targeting
{
    public class Target : TaskBase<int, Target>, ITargetInternal
    {
        private readonly Dictionary<string, TaskExecutionMode> _dependencies = new Dictionary<string, TaskExecutionMode>();

        private readonly List<TaskGroup> _taskGroups = new List<TaskGroup>();

        private readonly CommandArguments _args;

        private readonly TargetTree _targetTree;

        private readonly List<(Func<ITaskContext, bool> condition, string failMessage)> _musts = new List<(Func<ITaskContext, bool> condition, string failMessage)>();

        private List<LambdaExpression> _requiredParameters = new List<LambdaExpression>();

        private bool _logExecutionInfo = true;

        internal Target(TargetTree targetTree, string targetName, CommandArguments args)
        {
            if (string.IsNullOrEmpty(targetName))
            {
                throw new ScriptException("Target name must not be null or empty.");
            }

            if (targetName.Any(x => char.IsWhiteSpace(x)))
            {
                throw new ScriptException("Target name must not contain whitespaces.");
            }

            _targetTree = targetTree;
            TargetName = targetName;
            _args = args;
        }

        public Dictionary<string, TaskExecutionMode> Dependencies => _dependencies;

        public List<TaskGroup> TasksGroups => _taskGroups;

        /// <summary>
        ///     Gets a value indicating whether this target is hidden. Hidden targets will not be
        ///     visible in the list of targets displayed to the user as help.
        /// </summary>
        /// <value><c>true</c> if this target is hidden; otherwise, <c>false</c>.</value>
        public bool IsHidden { get; private set; }

        public string TargetName { get; }

        public override string TaskName => TargetName;

        public override bool IsTarget { get; } = true;

        protected override bool LogDuration { get; set; } = true;

        protected override string Description { get; set; }

        string ITargetInternal.Description
        {
            get { return Description; }
        }

        public ITargetInternal SetLogDuration(bool logDuration)
        {
            LogDuration = logDuration;
            return this;
        }

        public ITargetInternal SetLogExecutionInfo(bool logExecutionInfo)
        {
            _logExecutionInfo = logExecutionInfo;
            return this;
        }

        /// <summary>
        ///     Specifies targets on which this target depends on.
        /// </summary>
        /// <param name="targetNames">The dependency target names.</param>
        /// <returns>This same instance of <see cref="ITargetInternal" />.</returns>
        public ITargetInternal DependsOn(params string[] targetNames)
        {
            foreach (string dependentTargetName in targetNames)
            {
                _dependencies.Add(dependentTargetName, TaskExecutionMode.Sync);
            }

            return this;
        }

        /// <summary>
        ///     Specifies targets on which this target depends on.
        /// </summary>
        /// <param name="targetNames">The dependency target names.</param>
        /// <returns>This same instance of <see cref="ITargetInternal" />.</returns>
        public ITargetInternal DependsOnAsync(params string[] targetNames)
        {
            foreach (string dependentTargetName in targetNames)
            {
                _dependencies.Add(dependentTargetName, TaskExecutionMode.Async);
            }

            return this;
        }

        public ITargetInternal DependenceOf(params string[] targetNames)
        {
            if (targetNames != null)
            {
                foreach (var targetName in targetNames)
                {
                    var target = _targetTree.GetTarget(targetName);
                    target.DependsOn(TargetName);
                }
            }

            return this;
        }

        public ITargetInternal DependenceOfAsync(params string[] targetNames)
        {
            if (targetNames != null)
            {
                foreach (var targetName in targetNames)
                {
                    var target = _targetTree.GetTarget(targetName);
                    target.DependsOnAsync(TargetName);
                }
            }

            return this;
        }

        public ITargetInternal DoAsync(Action<ITaskContextInternal> targetAction, Action<DoTask> taskAction = null, TaskGroup taskGroup = null)
        {
            var task = new DoTask(targetAction);
            taskAction?.Invoke(task);
            AddTaskToTaskGroup(taskGroup, task, TaskExecutionMode.Async);

            return this;
        }

        public ITargetInternal DoAsync<T>(Action<ITaskContextInternal, T> targetAction, T param, Action<DoTask2<T>> taskAction = null, TaskGroup taskGroup = null)
        {
            var task = new DoTask2<T>(targetAction, param);
            taskAction?.Invoke(task);
            AddTaskToTaskGroup(taskGroup, task, TaskExecutionMode.Async);
            return this;
        }

        public ITargetInternal DoAsync<T, T2>(Action<ITaskContextInternal, T, T2> targetAction, T param, T2 param2, Action<DoTask3<T, T2>> taskAction = null, TaskGroup taskGroup = null)
        {
            var task = new DoTask3<T, T2>(targetAction, param, param2);
            taskAction?.Invoke(task);
            AddTaskToTaskGroup(taskGroup, task, TaskExecutionMode.Async);
            return this;
        }

        public ITargetInternal DoAsync<T1, T2, T3>(Action<ITaskContextInternal, T1, T2, T3> targetAction, T1 param, T2 param2, T3 param3, Action<DoTask4<T1, T2, T3>> taskAction = null, TaskGroup taskGroup = null)
        {
            var task = new DoTask4<T1, T2, T3>(targetAction, param, param2, param3);
            taskAction?.Invoke(task);
            AddTaskToTaskGroup(taskGroup, task, TaskExecutionMode.Async);
            return this;
        }

        public ITargetInternal DoAsync<T1, T2, T3, T4>(Action<ITaskContextInternal, T1, T2, T3, T4> targetAction, T1 param, T2 param2, T3 param3, T4 param4, Action<DoTask5<T1, T2, T3, T4>> taskAction = null, TaskGroup taskGroup = null)
        {
            var task = new DoTask5<T1, T2, T3, T4>(targetAction, param, param2, param3, param4);
            taskAction?.Invoke(task);
            AddTaskToTaskGroup(taskGroup, task, TaskExecutionMode.Async);
            return this;
        }

        public ITargetInternal DoAsync<T1, T2, T3, T4, T5>(Action<ITaskContextInternal, T1, T2, T3, T4, T5> targetAction, T1 param, T2 param2, T3 param3, T4 param4, T5 param5, Action<DoTask6<T1, T2, T3, T4, T5>> taskAction = null, TaskGroup taskGroup = null)
        {
            var task = new DoTask6<T1, T2, T3, T4, T5>(targetAction, param, param2, param3, param4, param5);
            taskAction?.Invoke(task);
            AddTaskToTaskGroup(taskGroup, task, TaskExecutionMode.Async);
            return this;
        }

        public ITargetInternal DoAsync(Func<ITaskContextInternal, Task> targetAction, Action<DoTaskAsync> taskAction = null, TaskGroup taskGroup = null)
        {
            var task = new DoTaskAsync(targetAction);
            taskAction?.Invoke(task);
            AddTaskToTaskGroup(taskGroup, task, TaskExecutionMode.Async);
            return this;
        }

        public ITargetInternal DoAsync<T>(Func<ITaskContextInternal, T, Task> targetAction, T param, Action<DoTaskAsync2<T>> taskAction = null, TaskGroup taskGroup = null)
        {
            var task = new DoTaskAsync2<T>(targetAction, param);
            taskAction?.Invoke(task);
            AddTaskToTaskGroup(taskGroup, task, TaskExecutionMode.Async);
            return this;
        }

        public ITargetInternal DoAsync<T, T2>(Func<ITaskContextInternal, T, T2, Task> targetAction, T param, T2 param2, Action<DoTaskAsync3<T, T2>> taskAction = null, TaskGroup taskGroup = null)
        {
            var task = new DoTaskAsync3<T, T2>(targetAction, param, param2);
            taskAction?.Invoke(task);
            AddTaskToTaskGroup(taskGroup, task, TaskExecutionMode.Async);
            return this;
        }

        public ITargetInternal DoAsync<T1, T2, T3>(Func<ITaskContextInternal, T1, T2, T3, Task> targetAction, T1 param, T2 param2, T3 param3, Action<DoTaskAsync4<T1, T2, T3>> taskAction = null, TaskGroup taskGroup = null)
        {
            var task = new DoTaskAsync4<T1, T2, T3>(targetAction, param, param2, param3);
            taskAction?.Invoke(task);
            AddTaskToTaskGroup(taskGroup, task, TaskExecutionMode.Async);
            return this;
        }

        public ITargetInternal DoAsync<T1, T2, T3, T4>(Func<ITaskContextInternal, T1, T2, T3, T4, Task> targetAction, T1 param, T2 param2, T3 param3, T4 param4, Action<DoTaskAsync5<T1, T2, T3, T4>> taskAction = null, TaskGroup taskGroup = null)
        {
            var task = new DoTaskAsync5<T1, T2, T3, T4>(targetAction, param, param2, param3, param4);
            taskAction?.Invoke(task);
            AddTaskToTaskGroup(taskGroup, task, TaskExecutionMode.Async);
            return this;
        }

        public ITargetInternal DoAsync<T1, T2, T3, T4, T5>(Func<ITaskContextInternal, T1, T2, T3, T4, T5, Task> targetAction, T1 param, T2 param2, T3 param3, T4 param4, T5 param5, Action<DoTaskAsync6<T1, T2, T3, T4, T5>> taskAction = null, TaskGroup taskGroup = null)
        {
            var task = new DoTaskAsync6<T1, T2, T3, T4, T5>(targetAction, param, param2, param3, param4, param5);
            taskAction?.Invoke(task);
            AddTaskToTaskGroup(taskGroup, task, TaskExecutionMode.Async);
            return this;
        }

        public ITargetInternal Do(Action<ITaskContextInternal> targetAction, Action<DoTask> taskAction = null, TaskGroup taskGroup = null)
        {
            var task = new DoTask(targetAction);
            taskAction?.Invoke(task);
            AddTaskToTaskGroup(taskGroup, task, TaskExecutionMode.Sync);
            return this;
        }

        public ITargetInternal Do<T>(Action<ITaskContextInternal, T> targetAction, T param, Action<DoTask2<T>> taskAction = null, TaskGroup taskGroup = null)
        {
            var task = new DoTask2<T>(targetAction, param);
            taskAction?.Invoke(task);
            AddTaskToTaskGroup(taskGroup, task, TaskExecutionMode.Sync);
            return this;
        }

        public ITargetInternal Do<T, T2>(Action<ITaskContextInternal, T, T2> targetAction, T param, T2 param2, Action<DoTask3<T, T2>> taskAction = null, TaskGroup taskGroup = null)
        {
            var task = new DoTask3<T, T2>(targetAction, param, param2);
            taskAction?.Invoke(task);
            AddTaskToTaskGroup(taskGroup, task, TaskExecutionMode.Sync);
            return this;
        }

        public ITargetInternal Do<T1, T2, T3>(Action<ITaskContextInternal, T1, T2, T3> targetAction, T1 param, T2 param2, T3 param3, Action<DoTask4<T1, T2, T3>> taskAction = null, TaskGroup taskGroup = null)
        {
            var task = new DoTask4<T1, T2, T3>(targetAction, param, param2, param3);
            taskAction?.Invoke(task);
            AddTaskToTaskGroup(taskGroup, task, TaskExecutionMode.Sync);
            return this;
        }

        public ITargetInternal Do<T1, T2, T3, T4>(Action<ITaskContextInternal, T1, T2, T3, T4> targetAction, T1 param, T2 param2, T3 param3, T4 param4, Action<DoTask5<T1, T2, T3, T4>> taskAction = null, TaskGroup taskGroup = null)
        {
            var task = new DoTask5<T1, T2, T3, T4>(targetAction, param, param2, param3, param4);
            taskAction?.Invoke(task);
            AddTaskToTaskGroup(taskGroup, task, TaskExecutionMode.Sync);
            return this;
        }

        public ITargetInternal Do<T1, T2, T3, T4, T5>(Action<ITaskContextInternal, T1, T2, T3, T4, T5> targetAction, T1 param, T2 param2, T3 param3, T4 param4, T5 param5, Action<DoTask6<T1, T2, T3, T4, T5>> taskAction = null, TaskGroup taskGroup = null)
        {
            var task = new DoTask6<T1, T2, T3, T4, T5>(targetAction, param, param2, param3, param4, param5);
            taskAction?.Invoke(task);
            AddTaskToTaskGroup(taskGroup, task, TaskExecutionMode.Sync);
            return this;
        }

        /// <summary>
        ///     Sets the target as the default target for the runner.
        /// </summary>
        /// <returns>This same instance of <see cref="ITargetInternal" />.</returns>
        public ITargetInternal SetAsDefault()
        {
            _targetTree.SetDefaultTarget(this);
            return this;
        }

        /// <summary>
        ///     Set's the description of the target.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns>this target.</returns>
        public new ITargetInternal SetDescription(string description)
        {
            Description = description;
            return this;
        }

        /// <summary>
        ///     Sets the target as hidden. Hidden targets will not be
        ///     visible in the list of targets displayed to the user as help.
        /// </summary>
        /// <returns>This same instance of <see cref="ITargetInternal" />.</returns>
        public ITargetInternal SetAsHidden()
        {
            IsHidden = true;
            return this;
        }

        /// <summary>
        ///     Specifies targets on which this target depends on.
        /// </summary>
        /// <param name="targets">The dependency targets.</param>
        /// <returns>This same instance of <see cref="ITargetInternal" />.</returns>
        public ITargetInternal DependsOn(params ITargetInternal[] targets)
        {
            foreach (ITargetInternal target in targets)
            {
                _dependencies.Add(target.TargetName, TaskExecutionMode.Sync);
            }

            return this;
        }

        public ITargetInternal DependsOnAsync(params ITargetInternal[] targets)
        {
            foreach (ITargetInternal target in targets)
            {
                _dependencies.Add(target.TargetName, TaskExecutionMode.Async);
            }

            return this;
        }

        public ITargetInternal DependenceOf(params ITargetInternal[] targets)
        {
            foreach (var target in targets)
            {
                target.DependsOn(TargetName);
            }

            return this;
        }

        public ITargetInternal DependenceOfAsync(params ITargetInternal[] targets)
        {
            foreach (var target in targets)
            {
                target.DependsOnAsync(TargetName);
            }

            return this;
        }

        public ITargetInternal AddTask(TaskGroup taskGroup, params ITask[] tasks)
        {
            foreach (var task in tasks)
            {
                AddTaskToTaskGroup(taskGroup, task, TaskExecutionMode.Sync);
            }

            return this;
        }

        public ITargetInternal AddTaskAsync(TaskGroup taskGroup, params ITask[] tasks)
        {
            foreach (var task in tasks)
            {
                if (task is TaskCore tmp)
                {
                    tmp.SequentialLogging = SequentialLogging;
                }

                AddTaskToTaskGroup(taskGroup, task, TaskExecutionMode.Async);
            }

            return this;
        }

        public ITargetInternal Must(Func<ITaskContext, bool> condition, string failMessage)
        {
            _musts.Add((condition, failMessage));
            return this;
        }

        public ITargetInternal Requires<T>(Expression<Func<T>> parameter)
        {
            _requiredParameters.Add(parameter);
            return this;
        }

        public void TargetHelp(ITaskContextInternal context)
        {
            _targetTree.MarkTargetAsExecuted(this);
            context.LogInfo(" ");
            context.LogInfo($"Target {TargetName} will execute next tasks:");

            for (int i = 0; i < _taskGroups.Count; i++)
            {
                for (int j = 0; j < _taskGroups[i].Tasks.Count; j++)
                {
                    var task = (TaskCore)_taskGroups[i].Tasks[j].task;
                    task.LogTaskHelp(context);
                }
            }
        }

        public void RemoveLastAddedActionsFromTarget(TargetAction targetAction, int actionCount)
        {
            switch (targetAction)
            {
                case TargetAction.Other:
                    return;
                case TargetAction.AddTask:
                {
                    var lastGroup = TasksGroups.Last();
                    for (int i = 0; i < actionCount; i++)
                    {
                        var lastTask = lastGroup.Tasks.Last();

                        lastGroup.Tasks.Remove(lastTask);
                        _targetTree.BuildSummaryExtras.Add((lastTask.task.TaskName, targetAction, TargetName));
                        if (lastGroup.Tasks.Count == 0)
                        {
                            TasksGroups.Remove(lastGroup);
                        }
                    }

                    return;
                }

                case TargetAction.AddDependency:
                {
                    for (int i = 0; i < actionCount; i++)
                    {
                        var lastDependency = _dependencies.Keys.Last();
                        _targetTree.BuildSummaryExtras.Add((lastDependency, targetAction, TargetName));
                        _dependencies.Remove(lastDependency);
                    }

                    return;
                }
            }
        }

        protected override int DoExecute(ITaskContextInternal context)
        {
            if (_targetTree == null)
            {
                throw new ArgumentNullException(nameof(_targetTree), "TargetTree must be set before Execution of target.");
            }

            if (_requiredParameters.Count > 0)
            {
                foreach (var requiredParameter in _requiredParameters)
                {
                    var member = GetMemberExpression(requiredParameter).Member;

                    if (member.GetValue(context.TargetTree.BuildScript) == null)
                    {
                        if (context.BuildSystems().IsLocalBuild && !context.Properties.Get<bool>(PredefinedBuildProperties.IsWebApi))
                        {
                            Console.Write($"{member.Name} requires value: ");
                            string value = Console.ReadLine();
                            var propertyInfo = (PropertyInfo)member;
                            object parsedValue = MethodParameterModifier.ParseValueByType(value, propertyInfo.PropertyType);
                            propertyInfo.SetValue(context.TargetTree.BuildScript, parsedValue);
                        }
                        else
                        {
                            throw new TaskExecutionException($"Target '{TargetName}' requires build script member '{member.Name}' not to be null.", -99);
                        }
                    }
                }
            }

            if (_musts.Count > 0)
            {
                foreach (var must in _musts)
                {
                    var conditionMeet = must.condition.Invoke(Context);

                    if (conditionMeet == false)
                    {
                        var message = string.IsNullOrEmpty(must.failMessage) ? $"Required condition in target '{TargetName}' was not meet. Check target requirement's in must method." : must.failMessage;

                        throw new TaskExecutionException(message, 50);
                    }
                }
            }

            if (_logExecutionInfo)
            {
                string message = TaskExecutionMode == TaskExecutionMode.Sync
                    ? $"Executing target {TargetName}"
                    : $"Executing target '{TargetName}' asynchronous.";

#if !NETSTANDARD1_6
                context.LogInfo(message, Color.DimGray);
#else
                context.LogInfo(message);
#endif
            }

            context.IncreaseDepth();
            _targetTree.EnsureDependenciesExecuted(context, TargetName);
            _targetTree.MarkTargetAsExecuted(this);

            if (_args.TargetsToExecute != null)
            {
                if (!_args.TargetsToExecute.Contains(TargetName))
                {
                    throw new TaskExecutionException($"Target {TargetName} is not on the TargetsToExecute list", 3);
                }
            }

            int taskGroupsCount = _taskGroups.Count;
            List<System.Threading.Tasks.Task> tasks = new List<System.Threading.Tasks.Task>();
            for (int i = 0; i < taskGroupsCount; i++)
            {
                int tasksCount = _taskGroups[i].Tasks.Count;
                if (_taskGroups[i].CleanupOnCancel)
                {
                    CleanUpStore.AddCleanupAction(_taskGroups[i].FinallyAction);
                }

                try
                {
                    for (int j = 0; j < tasksCount; j++)
                    {
                        var task = (TaskCore)_taskGroups[i].Tasks[j].task;

                        if (_taskGroups[i].Tasks[j].taskExecutionMode == TaskExecutionMode.Sync)
                        {
                            task.LogTaskExecutionInfo = _logExecutionInfo;

                            if (SequentialLogging)
                            {
                                task.SequentialLogging = SequentialLogging;
                            }

                            if (task.IsTarget)
                            {
                                context.IncreaseDepth();
                                _targetTree.EnsureDependenciesExecuted(context, _taskGroups[i].Tasks[j].task.TaskName);
                                var target = _taskGroups[i].Tasks[j].task as ITargetInternal;
                                _targetTree.MarkTargetAsExecuted(target);
                            }

                            _taskGroups[i].Tasks[j].task.ExecuteVoid(context);

                            if (task.IsTarget)
                            {
                                context.DecreaseDepth();
                            }
                        }
                        else
                        {
                            if (SequentialLogging)
                            {
                                task.SequentialLogging = SequentialLogging;
                            }

                            if (task.IsTarget)
                            {
                                context.IncreaseDepth();
                                _targetTree.EnsureDependenciesExecuted(context, _taskGroups[i].Tasks[j].task.TaskName);
                                var target = _taskGroups[i].Tasks[j].task as ITargetInternal;
                                _targetTree.MarkTargetAsExecuted(target);
                            }

                            tasks.Add(_taskGroups[i].Tasks[j].task.ExecuteVoidAsync(context));
                            if (j + 1 < tasksCount)
                            {
                                if (_taskGroups[i].Tasks[j + 1].taskExecutionMode != TaskExecutionMode.Sync)
                                    continue;
                                if (tasks.Count <= 0) continue;
                                Task.WaitAll(tasks.ToArray());
                                tasks = new List<Task>();
                            }
                            else if (i + 1 < taskGroupsCount)
                            {
                                if (_taskGroups[i + 1].Tasks[0].taskExecutionMode != TaskExecutionMode.Sync)
                                    continue;
                                if (tasks.Count <= 0) continue;
                                Task.WaitAll(tasks.ToArray());
                                tasks = new List<Task>();
                            }
                            else if (tasksCount > 0)
                            {
                                Task.WaitAll(tasks.ToArray());
                            }

                            if (task.IsTarget)
                            {
                                context.DecreaseDepth();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    _taskGroups[i].OnErrorAction?.Invoke(context, e);
                    throw;
                }
                finally
                {
                    if (!CleanUpStore.StoreAccessed)
                    {
                        if (_taskGroups[i].CleanupOnCancel)
                        {
                            CleanUpStore.RemoveCleanupAction(_taskGroups[i].FinallyAction);
                        }

                        _taskGroups[i].FinallyAction?.Invoke(context);
                    }
                }
            }

            context.DecreaseDepth();
            return 0;
        }

        private void AddTaskToTaskGroup(TaskGroup taskGroup, ITask task, TaskExecutionMode taskExecutionMode)
        {
            CheckThatTaskWasNotExecutedAlready(task);
            if (taskGroup == null)
            {
                taskGroup = new TaskGroup()
                {
                    GroupId = Guid.NewGuid().ToString(),
                };

                taskGroup.Tasks.Add((task, taskExecutionMode));
                TasksGroups.Add(taskGroup);
            }
            else
            {
                var existingGroup = TasksGroups.FirstOrDefault(x => x.GroupId == taskGroup.GroupId);
                if (existingGroup == null)
                {
                    taskGroup.Tasks.Add((task, taskExecutionMode));
                    TasksGroups.Add(taskGroup);
                }
                else
                {
                    taskGroup.Tasks.Add((task, taskExecutionMode));
                }
            }
        }

        private void CheckThatTaskWasNotExecutedAlready(ITask result)
        {
            if (result is TaskCore taskBase)
            {
                if (taskBase.TaskExecuted)
                {
                    throw new ScriptException(
                        $"Calling Execute method on task in AddTask is not valid becasuse FlubuCore calls execute on AddTask implicitly and task would be executed every time build script is runned regardles which target is executed. Remove Execute method on task ${taskBase.TaskName}.");
                }
            }
        }
    }
}