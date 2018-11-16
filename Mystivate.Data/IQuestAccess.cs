using Mystivate.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mystivate.Data
{
    public interface IQuestAccess
    {
        Quest GetCurrentQuest(int characterId);

    }
}
