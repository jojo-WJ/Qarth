﻿//  Desc:        Framework For Game Develop with Unity3d
//  Copyright:   Copyright (C) 2017 SnowCold. All rights reserved.
//  WebSite:     https://github.com/SnowCold/Qarth
//  Blog:        http://blog.csdn.net/snowcoldgame
//  Author:      SnowCold
//  E-mail:      snowcold.ouyang@gmail.com
using System;
using System.Collections.Generic;

namespace Qarth
{
    public class TimerHelper
    {
        protected List<TimeItem>    m_TimeItemList;
        protected bool              m_IsUseAble = true;

        public void Add(TimeItem item)
        {
            if (!m_IsUseAble)
            {
                Log.e("TimeHelper Not Use Able...");
                return;
            }

            if (m_TimeItemList == null)
            {
                m_TimeItemList = new List<TimeItem>(2);
            }
            m_TimeItemList.Add(item);
        }

        public void Clear()
        {
            if (m_TimeItemList != null)
            {
                for (int i = m_TimeItemList.Count - 1; i >= 0; --i)
                {
                    m_TimeItemList[i].Cancel();
                }
                
                m_TimeItemList.Clear();
            }
        }
    }
}
