# Avalon-Mod
Avalon Mod is an Among Us modification for Windows, which adds a new Crewmate class to the game.
<img src ="Pics/SheriffMod.png" width="1000"></img>

<h3>What roles are there?</h3>
Oberon is an Imposter that is not known to other Impostors.
<h3>Additional Features</h3>
<ul>
<li> Visibility of Oberon can be set in the lobby game options menu</li>
<li> Playable on public Among Us Servers</li>
<li> Custom server regions to join private servers</li>
</ul>

<h2 id="installation"> Installation </h2>
<ul>
<li>Download the Mod for your specific game version. You are not able to launch the game if the versions do not match.</li>
<li>Make a copy of your game’s root directory (Steam/steamapps/common/Among Us) and rename it to whatever you want (Steam/steamapps/common/Among Us Avalon Mod) </li>
<li>Extract the content of Among Us Avalon Mod.zip into the copied folder you created</li>
<li>Open your modded folder and open the Game via Among Us.exe</li>
</ul>
<p>Verifying installation success<p>
<ul>
  <li>Launch the Game via Among Us.exe.
  <li>In the top-left corner, below Among Us version, you should see <em>loaded Avalon Mod vx.y by lynnmakes </em>
</ul>
<p>If you don't see this message please take a look at our 
  <a href="#troubleshooting">troubleshooting section</a>.
</p>
 
<h2>Releases and Compatibility</h2>
 
 <table style="width:100%">
  <tr>
    <th>Among Us Version</th>
    <th>Mod Version</th>
    <th>Link</th>
  </tr>
   <tr>
    <td>v2020.12.9s</td>
    <td>v1.1</td>
    <td><a href="https://github.com/Woodi-dev/Among-Us-Avalon-Mod/releases/download/v1.1/Among.Us.Avalon.Mod.1.1.zip">Download</></td>
  </tr>
  <tr>
    <td>v2020.12.9s</td>
    <td>v1.01</td>
    <td><a href="https://github.com/Woodi-dev/Avalon-Mod/releases/download/v2020.12.9s/Among.Us.Avalon.Mod.1.01.zip">Download</></td>
  </tr>

</table>
<details>
  <summary>Changelog</summary>
   <h3>v1.1</h3>
   <ul>
    <li>Added Oberon Imposter role to the game lobby</li>
   </ul>
</details>
<h2>Q&A</h2>
 
<p><b>Can you play Proximity Chat (Crewlink) with it?</b></br>
Yes Crewlink does support Among Us Modifications.</p>
<p><b>Can you get banned for playing on public Servers?</b></br>
At the current state of the game there is no perma ban system for the game. The mod is designed in a way, that it does not send prohibited server requests.
You are also able to join your own custom server to be safe <a href="https://github.com/Impostor/Impostor">(Impostor)</a></p>
<p><b>How can i join a custom server?</b></br>
Go to your game directory and open BepInEx/config/org.bepinex.plugins.AvalonMod.txt. There you can set the hostname or IP of the server. Then set the server region to CUSTOM.</p>
<p><b>Do my friends need to install the mod to play it together?</b></br>
Yes. Every player in the game lobby has to install it.</p>
<h2>Donate</h2>

<a href="https://www.paypal.com/donate?hosted_button_id=TWGK7A9VBVPRU"><img src ="https://www.paypalobjects.com/en_US/DK/i/btn/btn_donateCC_LG.gif" alt="Donate with PayPal button" ></img></a>


I would appreciate any donations. This will help me to develop more mods.

For exclusive modding requests contact me: <a href="mailto:h6k6l4@gmail.com">h6k6l4@gmail.com</a>

<h2 id="troubleshooting">Troubleshooting</h2>

<p><b>I can't see <em>loaded</em> message on my game screen</b></br>
<ol>
  <li>Make sure you have followed all the <a href="#installation">installation steps</a>, especially launching the game via the Among Us.exe file</li>
  <li>You might be missing some cpp libs (software libraries used by the mod); please install 
    <a href="https://aka.ms/vs/16/release/vc_redist.x86.exe">visual studio c++</a>
  </li>
</ol>
</p>

<p><b>I can't find my issue.</b></br>
You can <a href="https://github.com/Woodi-dev/Among-Us-Avalon-Mod/issues/new">raise an issue within GitHub</a> documenting your issue. You will need to be logged into GitHub to do this.
</p>
