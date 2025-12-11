<h1>PT Piranha</h1>
PT Piranha is a Winform application that acts as a Multiworld Tracker for archipelago games.<br/>
<img src="Resources/Multiworld Tracker.png" alt="Multiworld Tracker in action" height="500" width="500" align="top"/>
<h2>Archipelago</h2>
https://archipelago.gg/ is a tool for generating multiworld randomizers.<br/>
<h2>Purpose</h2>
PT Pirhana was created to assist in Centipelago challenges which require completing a multiworld consisting of 100 copies of the same world.<br/>
The way PT Piranha assists is by allowing the user to duplicate YAMLs quickly, and by allowing them to track progress over all of their worlds at once in one big display.
<h2>Future Plans</h2>
Bug fixes, lots of them.<br/>
Current issues include:<br/>
Joining a room causes clients to complain about a bad request.<br/>
When a world is completed its tracker stops tracking.<br/>
When all worlds are done, all trackers stop tracking (Item received messages don't come in).<br/>
Item received messages are not handled async (Upon receiving a bunch of items, the screen is redrawn for each one).<br/>
Scout messages are not handled async (Upon joining, all locations are scouted causing massive load spike).<br/>
Forcing file extension upon saving/loading Multiworld Tracker.<br/>
Have pixels fill the Multiworld Tracker when row/column is empty.<br/>
Probably a whole bunch of stuff I haven't thought of.<br/>
<br/>
Adding Gradient support to Multiworld Tracker editor.(Technically extra keys can be added in the XML manually)<br/>
Allowing users to edit Multiworld Trackers after creation.<br/>
Adding more display options for the Multiworld Tracker viewer (Seperated by game, jumbled, count to size correlated, voronoi).<br/>
Image support for clear color.<br/>
Additional Gradient Styles (clamp to next).
<h2>Naming</h2>
PT stands for Pizza Tower since that was the first use case. Specifically named after the Piraneapple enemy.
