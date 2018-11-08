# Auto RPG

[![Build Status](https://travis-ci.org/nightblade9/auto-rpg.svg?branch=master)](https://travis-ci.org/nightblade9/auto-rpg)

Play here: Heroku link TBD

# Vision

A single-player game in a massive, generated-on-demand world! You manage a shifting party of members as you accept and complete quests, manage equipment, character progression, battle preferences, and more!

Also includes a standalone console you can use to view progress (and maybe in the future, preferences).

# Major Features

- Choose which quests to accept and build rapport with different groups
- Build your characters by selecting their equipment, and skills/stats as they level up
- Recruit multiple party members of varying backgrounds and goals
- Engage in epic battles against hordes of monsters
- Fight massively powerful boss-beasts in battle after battle as you whittle them down
- Monitor status regularly with an oldschool ASCII console app

# Game Workflows

You start with a single character who auto-ventures into the dungeon, fights, levels up and finds loot, dies and returns to town, etc. You return and assign skill points, reassign/buy equipment, etc. and gradually power up.

Eventually, you unlock a place where you can recruit a second party member. Same process here -- both fight together and strengthen over time.

Over time, you will unlock several party members, and manage which ones you want to use at any given time (say, four in party at once out of the 18 you have in your roster). 

As more users join and play, *every party on the same floor fights at the same time.* So the more people join, the more we advance (toghether) because we fight together. All XP, loot, etc. is shared/cloned to everyone who participates, even if fleetingly.

# Development Notes

To run all the ReactJS tests, run `npm test` from `AutoRpg.Web/ClientApp`.
