# Diablo 2 Resurrected Discord Rich Presence

## Build Status

[![D2R-DiscordRPC](https://github.com/lciesielski/D2R-DiscordRPC/actions/workflows/dotnetcoredesktop.yml/badge.svg)](https://github.com/lciesielski/D2R-DiscordRPC/actions/workflows/dotnetcoredesktop.yml)

## Purpose

Diablo being my favorite franchise and Diablo II being my favorite game of all time, I was more than excited to play the remaster.
Even while Warcraft III Reforged failure was echoing in my mind, I was confident that VV will be up for the task.
With currently having 100h played time and counting, I can safely say that in my opinion, this is the remaster I've been waiting for.

With that being said, I have noticed that the game is not utilizing Discord Rich Presence.
It strokes me as a great opportunity to get back into C# (as every day I work mostly with Apex, which is like handicapped Java).

In the end, the purpose of this project is to get back on the horse with C# and to showoff what a great game I'm playing to my friends on Discord.

## Prerequisites 

For now, you will have to set up your own [discord application](https://discord.com/developers/applications) and add assets to the rich presence setting.
Assets can be found in this repository in [**Images**](./Images/) folder.
Please note that if you want to use different names you will have to adjust them in `classToIcon` dictionary as well.
Below is configuration I'm currently running.

![Image Failed :(](./Images/Discord_Application_Assets.JPG?raw=true)

This is needed to provide discord generated application ID that is needed to start the client.

## Usage

Download the latest release from GitHub repository.
Alternatively you can clone this repository and build the application yourself.

For additional convenience, you can put exe file in Diablo II Resurrected folder, but it is not required.

Run exe file, specify game information, and click on D2 icon to specify D2R game executable file.
Alternatively, you do not have to specify game exe file, you can run the game separately.

If you encounter SmartScreen notification about an unknown publisher, you will have to click on "More Information" and "Run anyway"

If you are hesitant allowing program to run, I strongly encourage you to upload exe file to [VirusTotal](https://www.virustotal.com/gui/home/upload)

### Roadmap

I would love to switch from manually setting game information to reading memory from the process.
This however has a huge drawback in potentially being flagged by Warden and in the end getting banned.
I also think that implementing a kernel-level solution just to read memory for Discord Rich Presence is a bit too much.
If I do not find any workaround for the above, there are always areas to improve\optimize :)

![Image Failed :(](./Images/D2R_RPC.JPG?raw=true)


### Credits

* Blizzard & Vicarious Visions - assets (mostly from promotional materials from [YouTube channel](https://www.youtube.com/c/Diablo))
* Crimroxs - for [extracting](https://www.steamgriddb.com/game/5278139/icons) D2R Icons

### Copyrights 

Diablo II and Diablo II: Resurrected are copyrighted by Blizzard Entertainment, Inc. All rights reserved. 
Diablo II, Diablo II: Resurrected and Blizzard Entertainment are trademarks or registered trademarks of Blizzard Entertainment, Inc. in the U.S. and/or other countries.
All trademarks referenced here are the properties of their respective owners.

For the sake of convenience some text files and image files that the discord application requires are provided in this repository. 
These files are part of the Diablo II game series and are copyrighted by Blizzard Entertainment. 
They are provided only to save you the trouble of extracting them from the Diablo II game files and\or other sources.

This project and its maintainer(s) are not associated with or endorsed by Blizzard Entertainment, Inc.