# GimuFrontier
An experimental Brave Frontier written in C# and ASP.NET

**DEPRECATION NOTICE:** See the [C++ Server](https://github.com/decompfrontier/server) for more updates/integration inside Brave Frontier

Coded in around 5 days or what just to get 4k sennie, don't expect perfect quality code or something there's obvious things that can be optimized (ie: the handler creation should use ms's internal DI libs)

There's tons of things missing as well and some hardcoded things as well.

## Requirements
- .NET6 with ASP.NET Core
- Proxy HTTPS server (eg: Apache)
- Any way to connect to the game

## Setting up
- Compile and run gimufrontier
- Your asset server MUST contain MST folder (You can get those from the 21900 resource zip), you must also provide a file for the splash screen
- Adjust your configuration of MySQL + Redis + Game URL on "appsettings.json"

## Example configuration (local apache)
You can see my test example inside the "test_selfsigned" directory, it contains basic configuration for the Apache webhost (you will need mod_ssl, mod_proxy, mod_proxy_http, mod_socache, mod_headers enabled) and my DNS server (DNSAgent) configuration as well as gimufrontier settings

## Setting custom MST
Change the data inside mstinfo.json (I don't have a table that maps the names into Brave Frontier random names)

## Connecting to the game
You can either run a DNS server (I did this approach with Override DNS on my rooted phone) or you can patch the game internal ip (api-sl.bfww.gumi.sg) to make it connect to your server.

You will also need to replace the CA file inside Brave Frontier to your own (keep in mind that the space is limited so don't go fancy with names). You could run your own self signed certificates (like I did) or use one if you host this inside a normal domain. Search for "BEGIN CERTIFICATE" with an hex editor and apply changed.

You can edit both this two things inside libgame.so for the game.
For unacking it and repacking it I used apktool (2.6.1).

## Other
I left some network data (basic game startup and info) and some tools that might help cryptation/decryptation of Brave Frontier network data
