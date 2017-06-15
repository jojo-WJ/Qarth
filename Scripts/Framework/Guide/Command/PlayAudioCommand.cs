﻿//  Desc:        Framework For Game Develop with Unity3d
//  Copyright:   Copyright (C) 2017 SnowCold. All rights reserved.
//  WebSite:     https://github.com/SnowCold/Qarth
//  Blog:        http://blog.csdn.net/snowcoldgame
//  Author:      SnowCold
//  E-mail:      snowcold.ouyang@gmail.com
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qarth
{
	public class PlayAudioCommand : AbstractGuideCommand
	{
		private string m_AudioName;
		private bool m_FinishStep = false;
		private AudioUnit m_AudioUnit;

		public override void SetParam (object[] pv)
		{
			if (pv.Length == 0)
			{
				Log.w ("PlayAudioCommand Init With Invalid Param.");
				return;
			}

			m_AudioName = (string)pv[0];
			if (pv.Length > 1)
			{
				m_FinishStep = Helper.String2Bool((string)pv[1]);
			}
		}

		protected override void OnStart()
		{
			m_AudioUnit = AudioMgr.S.PlaySound(m_AudioName, false, OnAoundPlayFinish);
		}

		private void OnAoundPlayFinish(AudioUnit unit)
		{
			m_AudioUnit = null;
			if (m_FinishStep)
			{
				FinishStep ();
			}
		}

		protected override void OnFinish(bool forceClean)
		{
			if (m_AudioUnit != null)
			{
				m_AudioUnit.Stop ();
				m_AudioUnit = null;
			}
		}

	}
}

