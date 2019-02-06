Game project made by Unity
Visual novel
Room #4

He woke up......finding himself lying in a room with number 4, and he found some mysterious pills beside him....
What happened to him? Where is him? and why is he here?
The truth is being revealed as he digs deeper and deeper, as well as the greater danger.
Can he get out of there and find his identity successfully? or just remain like others....
This is all this about, try to survive and reach the end

Description:
A visual novel game featuring choice making game play and multiple ending.
Goal: survive to the end and escape.
GamePlay: choice making

Programming:
- All programmed in C#
- Game manager that manages the game flow, and trigger the event when certain choice is made.
- Event trigger system that will redirect the line pointer to point at different dialogue when the player makes different choice. This create the dynamic responsive effect, to make the character more vivid.
- Dialogue manager that parse the text file and interprete into different kind of parts including the talker's name, the content, and the choices.
- Typewritter effect created to display the text. Instead of displaying the whole sentence at once, we create the animated effect that will display the word in series. The effect is achieved by using coroutine and sleep feature to suspend the thread temporarily.
- Using MVC pattern to update the UI information
