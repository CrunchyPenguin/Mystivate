using Microsoft.Extensions.DependencyInjection;
using Mystivate.Data;
using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mystivate.Logic
{
    public class ScheduledDailyTasks : IScheduledTask
    {
        //private readonly IQuestAccess _questAccess;

        //public ScheduledDailyTasks(IQuestAccess questAccess)
        //{
        //    _questAccess = questAccess;
        //}

        public string Schedule => "0 0 * * *";

        public bool RunOnStartup => false;

        private readonly IServiceProvider serviceProvider;

        public ScheduledDailyTasks(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var serviceScopeFactory = this.serviceProvider.GetRequiredService<IServiceScopeFactory>();

            using (var scope = serviceScopeFactory.CreateScope())
            {
                var questAccess = scope.ServiceProvider.GetService<IQuestAccess>();
                var taskAccess = scope.ServiceProvider.GetService<ITaskAccess>();
                questAccess.DamageTodayToDamageDone();
                taskAccess.UncheckDailyTasks();
                taskAccess.ResetHabits();
            }
        }
    }
}
