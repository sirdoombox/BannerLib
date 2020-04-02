# BannerLib
An attempt at making some common functionality standard, including some in-line XMLDOcs to make development a bit easier and cleaning up some of the hideous constructor gore that a lot of the API seems to be made of. 
It's still early days so I'm just adding things as I go.

## BannerLib.Input
The InputSystem namespace was my first target, the HotKeyManager is not particularly friendly to work with and is extremely prone to collisions between mods, so I've made a wrapper around it that tries to prevent hotkey registration collisions from ever occurring, the plan is also to include the polling internally and provide an event based API to work with instead.