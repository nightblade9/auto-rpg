# Auto RPG

[![Build Status](https://travis-ci.org/nightblade9/auto-rpg.svg?branch=master)](https://travis-ci.org/nightblade9/auto-rpg)

Play here: Heroku link TBD

# Vision

A single-player game in a massive, generated-on-demand world! You manage a shifting party of members as you accept and complete quests, manage equipment, character progression, battle preferences, and more!

Also includes a standalone console you can use to view progress (and maybe in the future, preferences).

# Major Features

- Explore and fight across a vast world full of ominous forests, dangerous caves, icy palaces, and more!
- Build your characters by selecting their equipment, and skills/stats as they level up
- Choose which quests to accept and build rapport with different groups
- Recruit multiple party members of varying backgrounds and goals
- Engage in epic battles against hordes of monsters
- Fight massively powerful boss-beasts in battle after battle as you whittle them down
- Join guilds, share XP/gold/items, and engage in massive battles!
- Monitor progress regularly with a terminal/console application

# Game Workflows

You start with a single character who auto-ventures into the dungeon, fights, levels up and finds loot, dies and returns to town, etc. You return and assign skill points, reassign/buy equipment, etc. and gradually power up.

Eventually, you unlock a place where you can recruit a second party member. Same process here -- both fight together and strengthen over time.

Over time, you will unlock several party members, and manage which ones you want to use at any given time (say, four in party at once out of the 18 you have in your roster). 

Once you join a guild, we run daily "guild runs" against a special dungeon with a powerful boss (who gives awesome/rare loot). All guild members fight toghether *at the same time*, using whatever shared pool of characters they decide to send; all XP, gold, and spoils are shared (cloned) across all participants.

Also, guild members can send gold/XP/loot to each other, or pool it in a "guild pool" for anyone who wants to partake.

Finally, you get basic items (leather jerkin, steel haubark, etc.) Upgrading items is done by equipping gems that give various perks (eg. +3 defense). These gems also have power levels, and/or earn XP and level up (power up) too.

# Development Notes

To run all the ReactJS tests, run `npm test` from `AutoRpg.Web/ClientApp`.