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
		Durable,
		Escape,
		Initiator,
		Jungler,
		LaneSupport,
		Nuker,
		Pusher,
		Support,
	}

	class Hero
	{
		public readonly string Name;
		public readonly bool IsRanged;
		public readonly bool HasLegs;
		public readonly HeroAttribute Attribute;
		public readonly HeroRole[] Roles;

		public Hero(string name, bool isRanged, bool hasLegs, HeroAttribute attribute, params HeroRole[] roles)
		{
			Name = name;
			IsRanged = isRanged;
			HasLegs = hasLegs;
			Attribute = attribute;
			Roles = roles;
		}

		public static Hero Get(string name)
		{
			name = name.Replace("&#x27;", "'");
			name = name.Replace("Magnataur", "Magnus");
			foreach(Hero hero in Heroes.DotA2Heroes)
			{
				if(hero.Name == name)
					return hero;
			}
			throw new Exception("Unable to find hero");
		}
	}
}
