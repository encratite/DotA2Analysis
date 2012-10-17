using System;
using System.Collections.Generic;

namespace DotA2Analysis
{
	enum HeroAttribute
	{
		Strength,
		Agility,
		Intelligence,
	}

	enum HeroRole
	{
		Carry,
		Disabler,
		Escape,
		Ganker,
		Initiator,
		Nuker,
		Jungler,
		LaneSupport,
		Pusher,
		Roamer,
		SemiCarry,
		Support,
		Tank,
	}

	class Hero
	{
		public readonly string Name;
		public readonly HeroAttribute Attribute;
		public readonly HeroRole[] Roles;

		public Hero(string name, HeroAttribute attribute, params HeroRole[] roles)
		{
			Name = name;
			Attribute = attribute;
			Roles = roles;
		}

		public static Hero Get(string name)
		{
			name = name.Replace("&#x27;", "'");
			foreach(Hero hero in Heroes.DotA2Heroes)
			{
				if(hero.Name == name)
					return hero;
			}
			throw new Exception("Unable to find hero");
		}
	}
}
