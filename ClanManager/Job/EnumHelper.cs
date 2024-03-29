﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClanManager.Job
{
    public class EnumHelper
    {
    }

    public enum TriggerTypeEnum
    {
        None = 0,
        Cron = 1,
        Simple = 2,
    }

    public enum RequestTypeEnum
    {
        None = 0,
        Get = 1,
        Post = 2,
        Put = 4,
        Delete = 8
    }

    public enum MailMessageEnum
    {
        None = 0,
        Err = 1,
        All = 2
    }
}