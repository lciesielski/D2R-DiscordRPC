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

## Installation

This time there is none. GitHub's action is configured to build dotnet application as a single self-contained exe file.
This means that dependencies are included, the drawback is that exe file is bigger than usual.

## Usage

Download the latest release from GitHub repository.
For additional convenience, you can put exe file in Diablo II Resurrected folder, but it is not required.

Run exe file, specify game information, and click on D2 icon to specify D2R game executable file.
Alternatively, you don't have to specify game exe file, you can run the game separately.

If you encounter SmartScreen notification about an unknown publisher, you will have to click on "More Information" and "Run anyway"

If you are hesitant about this, I strongly encourage you to upload exe file to [VirusTotal](https://www.virustotal.com/gui/home/upload)

### Roadmap

I would love to switch from manually setting game information to reading memory from the process.
This however has a huge drawback in potentially being flagged by Warden and in the end getting banned.
I also think that implementing a kernel-level solution just to read memory for Discord Rich Presence is a bit too much.
If I do not find any workaround for the above, there are always areas to improve\optimize :)

![Image Failed :()](./Images/D2R-RPC.JPG?raw=true)