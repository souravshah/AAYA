using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WURFL;
using WURFL.Aspnet.Extensions.Config;

namespace Govhack2016
{
    public class WurflConfig
    {
        public static void Initialize()
        {
            WURFLManagerBuilder.Build(new ApplicationConfigurer());
        }
    }
}