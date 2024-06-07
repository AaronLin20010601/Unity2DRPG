# Unity2DRPG
A simple 2D RPG make with unity 2D URP  
------------------------------------------------  
Player controls :  
Using keyboard W,A,S,D to move  
Using space to dash and mouse left click to attack  
Press F to show or hide the inventory  
  
Player states :  
health -> the health of player and the maximum is 4  
coins -> the amount of player's coins  
stamina -> player is able to dash with stamina,every time cost a stamina when use dash and the maximum is 3  
  
Weapons :  
There are three weapons available for the player to use -> sword,bow,staff  
sword -> slash the target in front of player  
bow -> shoot arrows to hit target  
staff -> shoot magic laser in a line to attack target  
  
Monsters :  
slimes -> normal monster just move around the map with three different types -> blue,green,purple  
blue -> slime with the lowest health  
green -> slime with medium health and spread poison around itself  
purple -> slime with high amount of health  
grape shooter -> monster with high amount of health that shoot grape to attack  
ghost -> moster with medium health but have extremely strong attack ability that shoot lots of ghost fire  
  
Landscape :  
There are foreground,water,cosmetic and top elements on the map  
foreground -> hard land that don't allow any target to get through  
water -> player and enemy can't cross it but attack projectiles can  
cosmetic -> road that give player direction to the portal of next area  
top -> dark leaves cover on the top of the map,only visible when walk into it  
  
Map destructible items :  
There are bushes,barrels and crates on the map,when they get destroyed,they will have chance to drop coins,heart or stamina  
  
Map :  
There are 25 different areas,and each area have 1 to 3 portals connect to other areas  
  
Drops :  
When map destructible items get destroyed or monsters get killed,there is a change for them to drop the following stuff  
coins -> gain the amount of player coin  
heart -> heal the player's health for one point  
stamina -> recover the stamina for one time  
  
Notification :  
Using TextMeshPro and Cinemachine  
  
reference tutorial:<https://www.youtube.com/watch?v=9zzUq6T-rtA&list=PL6bqhqO0Ba776ksb3F9P_xmUMT9WvmfFT&index=1>
