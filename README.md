# AudirvanaPlaylistSorter
Sorts playlists in the music player Audirvana by artist and album.

![AudirvanaPlaylistSorter](https://github.com/WhereTheTimeWent/AudirvanaPlaylistSorter/raw/main/AudirvanaPlaylistSorter.png)

Audirvana is an incredible audio player: https://audirvana.com/

# Why would I need this?
Audirvana is able sort playlists, but not on a database level (afaik).
Since I export playlists directly from Audirvana's database ([AudirvanaToolkit](https://github.com/WhereTheTimeWent/AudirvanaToolkit)), I want my playlists sorted by artist and album on a database level.

# What features are there?
After opening the application for the first time, you have to select your Audirvana's database file. If you don't know where it is, look in Audirvana's settings.

After that you get a list of your playlists (if Audirvana isn't opened - otherwise the database is locked and AudirvanaPlaylistSorter closes itself).

If you want to change the database's path, click on the icon next to the path.

Select the playlists you want to sort and then click on the button 'Sort'. If you want to cancel, click on 'Cancel' - it won't cancel immediately, but after the current playlists is finished.

The path to Audirvana's database and window size get saved in the registry: HKCU:\SOFTWARE\AudirvanaPlaylistSorter\
