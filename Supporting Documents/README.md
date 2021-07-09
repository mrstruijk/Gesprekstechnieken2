# GPInteraction overview
## Program content and goals
In this program you can interact via scripted conversations with various virtual characters (VCs), in a simulated therapy training session. A coach will provide you with detailed feedback on your progress. 

The goal is to help students practice conversation skills in a realistic virtual setting, to supplement their practice with other students, volunteers and actors.


## Hardware and Software
Created for and tested on the Oculus Quest and Oculus Quest 2. 

Created with Unity 2019.4.19f1. 


## Downloading and using complete program (APK)
If you would like to use the program as is, there’s a [link to the APK file][1]. With this you can experience a fully working version of our program. This might be handy for piloting purposes, or if you’d like to use it “as is” in your own course. With this link, you cannot edit the program. More about this can be found below. 

You can find a [detailed guide][2] of how to install this APK on an Oculus Quest on UploadVR for instance. Otherwise, search for “upload content to oculus quest using sidequest”. 


## General overview of program
The program runs on a relatively predefined loop, which currently repeats six times. It looks something like this: 

- The VC will start the interaction, usually by saying something to you (or in some cases, by studiously ignoring you!). This is called the ‘Situatieschets’ (see below: General Structure of Cards).
- You’re asked to imagine how you would respond, and to say this out loud.
- Then, you will see three possible answers. The options are written on three separate cards you’ll see in front of you. These are called ‘ConversationOptions’ (see below: General Structure of Cards). You’re asked to select the option that most closely matches to the one you just said. 
- The VC will respond to this option (verbally, physically and with facial expressions). 
- You will hear feedback from your coach. 
- You get the option to restart the interaction, or continue to the next loop. These cards are called ‘Flow’ (see below: General Structure of Cards)


### Physical actions, and other movements
Use the controllers for interaction. Selecting the conversation options and moving the loop along is done by grabbing a virtual ‘card’ in front of you, and dropping this into a virtual box on your right. Any cards which are not chosen will automatically flow into the box as well. 

No other locomotion is required. Participants can stay seated. 


### Time required for the experience
Each therapy session takes about 15-20 minutes to complete, with the Tutorial lasting around 10 minutes. In our case, students performed both the tutorial and one of the therapy sessions in the workgroup. In total (including the presentation & explanation, troubleshooting, the actual task, and short wrap-up) this took about 1.5 hours to complete.


### Structure during workgroup and some common hurdles
We started each workgroup with a presentation (+- 20 min), in which we explained how to use the headset and the program. This presentation can be found in the /Supporting Documents folder. You can use and edit the presentation to your heart’s content. 

After this, the headsets were distributed to the students. Few students were familiar with the Oculus Quest or VR in general. Getting participants familiar with operating the headsets (e.g. setting the floor level and become familiar with the controls) took a fair bit of time in each workgroup. In our 6 workgroups so far, we noticed that around 30 minutes was needed for all students to be in the virtual environment. 

Per 20 students, 1 or ideally 2 experienced helpers were needed to answer questions and help getting the program started. In our experience, there was a fair amount of (minor) technical help required. 


# General structure of the Cards
In each Scene, you will find a Prefab Variant of the Cards Prefab. So for instance, in the Teenager scene, you will find the ‘Cards Teen’ gameobject. This holds a series of child gameobject, which each perform a specific function:
- The ‘Cards SituatieSchets’ hold each initial conversation starter by the VC. This will be the first section of the loop described above.
- The ‘Cards Think’ prompt you to think about how you would like to respond, and to say this out loud.
- The ‘Cards ConversationOptions’ hold the three separate conversation options: A, B and C. This means that **all** options A for a particular scene are stacked in that one gameobject. Same for B and C. The int counter (StoryLine) keeps track of which of the loops should be played/displayed.
- The ‘Cards Flow’ allow you to try the last conversation again (= re-do this loop), to start over completely (= restart at loop 0), or to continue to the next conversation (= next loop). 


# A few of the important scripts and other components used
### SpeakCardOptionHolder
This script lives on every ConversationOptions card. It holds the scriptable object (SO) ‘Card Options’, in which we find a list of all the pieces of text on that card, the responses by the VC (in audio, animation and blendshape emotions), and the feedback from the coach. 

### Card Options scriptable object (SO)
These live inside the Project view, and are referenced in the SpeakCardOptionHolder mentioned above. They contain all VC / coach responses, as well as the card text.

### SpeakingSettings
Holds the different components needed for animation, emotion, and audio for each VC.

### Animator
Animations are started using their respective trigger from each CardOptions SO. The triggers are collected using the SpeakingSettings component. Animations are all stopped using the ‘stopSpeaking’ trigger, which is fired when the VC is done talking.

### MoveUsingDOTweenWithTransforms (see below for DOTween explanation)
This allows the cards to ‘physically’ flow back and forth. For instance, once the VC has said what they wanted to say in their SituatieSchets, the ‘Think’ card flows to a position in front of the participant. Once this card has been dropped in the box to the right, the ‘ConverstationOptions’ cards flow to the front. Etc. 

### EventSO and GameEventUnityEventLinker
Based on [a presentation on Scriptable Objects by Ryan Hipple][3], this is a pair of very useful components. One is a Scriptable Object (SO) Event, which (after creation) lives inside the /Assets/ScriptableObjects/Events folder, which can be referenced and triggered from anywhere. The other is a MonoBehaviour script, which takes an SO Event as input and uses it to trigger it’s own UnityEvents. It does this when the SO Event is triggered trough Raise(). 

This ‘dual event’ system allows you to create fairly decoupled Prefabs. The Prefabs (holding the GameEventUnityEventLinkers) link to only other components inside of that Prefab. At the same time, the EventSO event can be linked to and triggered from anywhere in the scene. Because the EventSO lives inside the Project view, you can delete or instantiate new Prefabs without breaking anything: in each Scene they only link to (components inside) themselves.

The major downside is that you risk creating a fairly brittle system in a different way. You create connections within each Prefab using the Inspector of each UnityEvent on the GameEventUnityEventLinker. Therefore, if you accidentally remove or change one of the links on that UnityEvent, you might break a fundamental part of the program. And since these links were not written in code, and therefore don’t throw any errors, it is virtually impossible to find out what you need to restore to fix this link again… 

A suggested solution to this problem is to make sure your Prefab (Variants) are always properly saved and up to date, and that you double check the working of the links in that Prefab prior to Overriding it. 

Also: use version control.

### Audio
All client audio has been recorded for the earlier 360º video version of this project (see below). Those versions were cut into shorter clips, which are triggered from the scriptable objects (SpeakCardOptionHolder.cs), found in the /Assets/ScriptableObjects/Conversations folders. 

Coach audio has been recorded separately for this project, since the 360º Video version did not include spoken coach audio. For some scenes, a female coach is used, in other scenes a male coach is used. 

The .XLSX transcripts of these audio conversations (together with suggested animations and emotes, and responses by the coach) can be found in /Supporting Documents.


# Purchased models and assets (not included in Open Source!):
In our version of the program we’ve used some models and assets that have been purchased separately. These unfortunately couldn’t be included in an open-source version of the program. Therefore we’re including as much information and configuration components as possible, so that you can (re-)create your own version. I’ll also include some information about how well these models performed, because we think you might want to swap some models out for better versions.


### Virtual Character Model: Child (Olivia)
For the [child Olivia][4] we used a lovely model purchased from the creator ‘CharacterStore’ through CGTrader. She has excellent blendshapes and some customisation in hair styles. Her facial expressions (through blendshapes) worked especially well, and we were able to create a real sense of personality using the SALSA random Emotes (see for instance the videoclip Oliva.avi in the /Supporting Documents folder). 


### Virtual Character Model: Teen (Sofie)
The model for [teenager Sofie][5] was also purchased through CGTrader, from the designer Pradipta-D. Wether it was due to us spending less time on customising this model, or the model quality in general, but our experiences with this model were not excellent. Her rig is needlessly complex, and her textures are not stellar. Barely enough blendshapes for lipsync and emotion animations are however available. However, this model is not very expensive. 


### Virtual Character Model: Coach (Jasmine)
The [coach][6] model (used only in the Tutorial scene, in the other scenes you hear a coach via headphones) is from the same maker as the Teen model. Using a different rig and blendshape setup than the teen model, this model was also not perfect, but suited our needs for now. The model worked well enough for SALSA lipsync and displaying a few emotions. 


### Virtual Character Model: Parents (André and Janneke)
The models for the [parents Janneke and André][7] were free, and can be made through ReadyPlayerMe. This is a service which allows a little customisation to the models, which is nice. However, these models have a distinct ‘Fortnite’ look, which is especially evident in some of their more extravagant customisation options…

At the time of writing, ReadyPlayerMe’s intended use-case is for having 1 VC in the Unity scene. It required a bit of a work-around to obtain a second VC: 
1. Download the first model using the [instructions][8] on the ReadyPlayerMe website. 
2. Grab the downloaded files from the standard ReadyPlayerMe folders in the Unity Project view, and place them into a different folder (e.g. /Assets/Characters). 
3. Download a second model from the ReadyPlayerMe website, which can be done by clearing your browser cache (or using a second browser).
4. Repeat step 2 for the second model.
5. Put both VCs in the scene. An oddity of these models is that they have a separate .FBX file containing only the rig, and a separate .GLB file for the model itself. You’ll need both. The prefab you’ll be using in the scene (based on the .GLB) needs to reference the .FBX in the Animator component (which needs to be on the GLB’s Armature child gameobject to work properly). 

A slightly strange feature was that the mother (Janneke) did not have correct y-rotation available on her neck, therefore she couldn’t turn her head at all. We replaced head-rotation by a slight head-tilt in SALSA (see below). The feedback from our participants however was that this made her look rather stern… The father model (André) did not have this issue. 

### Virtual Character Values
All animations and animator controllers, as well as the SALSA values, can be found in the folders inside /Assets/Characters/ . This can be useful in case you want to use the same or similar models to recreate the program. 


### Asset: SALSA
[SALSA][9] allows for lipsync, emotion processing and eye-movement of the VC. All three components of SALSA were used in this project. The Lipsync component allows real time lip synchronisation to happen with any provided audio clip, in any language. The Emote section uses Blendshapes and Transforms to create emotion animations, which can be triggered manually, through code, or randomly. The Eye section creates random blinks, and random or predefined eye movements. These SALSA components combined make a VC much more realistic. 

See for an excellent example the videoclip ‘Oliva.avi’ in the /Supporting Documents folder. Here we’re showing off the random idle emotes and eye-movements when she’s not talking.

### Asset: DOTween
[DOTween][10] makes moving gameobjects such as our physical cards easier and prettier. It allows for cards to flow seamlessly back and forth. A free version can be got from the AssetStore. Since we’re reusing the same gameobjects for the Cards over and over again (e.g. the CardOption B holds **all** the B options, and therefore needs to be reused in every loop), DOTween allows you to always move these cards to the correct position at any time. 

Sometimes we’re using DOTween to snap a card immediately to a new position (for instance to it’s original position on the participants’ left), while other times DOTween flows the card gracefully to where it needs to be. 

### Asset: Odin
We’ve used [Odin][11] extensively in our project. This allows us to create easier to navigate Inspector fields, which came especially handy when using the various scriptable objects holding the data and logic for the conversations and the cards. We cannot recommend this asset enough. All Odin code has been commented out, and has been replaced by standard Unity code. However, we recommend that you purchase Odin, and re-enable the commented-out sections of code, to make the inspector read well again. 

### Are these required?
You need to purchase SALSA, and to get the free version of DOTween. A lot of our code is dependant on both these systems, and to try to recreate it using different methods would require a tremendous amount of work.

Strictly speaking, Odin is not necessary to run the program. However, since it vastly increases the readability of the most complex Inspector screens, I cannot recommend you this asset enough. It is well worth the money. 


# Adapting the program to your needs
### Core
The core of the program is the conversation loop, built on the process of grabbing a card and dropping it somewhere else. That means that the basic structure going from ‘SituatieSchets’ —\> ‘Think card’ —\> three ‘Conversation options’ —\> ‘Restart or Continue’, is fairly hard coded into the system. You can definitely amend these if required, but that would be a lot of work.

### Interaction Content
What is easier to change is the content of the interactions. You can change or increase the length of the conversation by recording new audio clips, and dropping these into the relevant ConversationOptions. Recreating this program in another language is therefore also possible (SALSA is language agnostic!).

Most likely you’re going to need seven new audio clips per additional loop:
- 1 ‘SituatieSchets’ prompt by the VC 
- 3 possible ‘Conversation Options’ by the VC
- 3 possible bits of feedback by the coach). 

You can also opt for ‘stacking’ multiple responses in one ‘SituatieSchets’ or ‘Conversation Option’, which is something that we’ve done for instance in the Parent’s Scene. You can also stack multiple pieces of audio feedback by the coach, if desired.

### Virtual Characters
Replacing the character models is relatively easy. Make sure you give them a new Speaking Settings SO, and provide the SALSA components with the required information. Refer to this [detailed SALSA tutorial][12] for more information.

### Virtual Environment
Changing the virtual environment is easy. Place the entire Cards Prefab (Variant), and especially the CardLocationsObject, near to where your participant will sit/stand (most likely at the origin point: x0,y0,z0). The Cards are triggered to flow into the box on the right hand side because they collide with the Box Collider on the CardChooserBox child gameobject of the CardLocationsObject.

### New Scenes
Creating a completely new scene is also quite easily done. Keep in mind that you create a new ‘Cards’ Prefab Variant based off the original ‘Cards’ Prefab, and not based on one of the other Prefab Variants… unless that is your express goal of course. 

When creating a new scene, you also need to create three new ConversationOptions (A, B and C), and a Speaking Settings SO. 

These and other Scriptable Objects (such as an EventSO) can be easily created by right clicking in the Project View, then go to ‘mrstruijk’, and select the option you need.  



# Funding and first use
This program was created using the under the [Comenius Teaching Fellow grant][13], for use in the 2021 workgroups of the course Gesprekstechnieken of the Education and Child Studies bachelor at the University of Leiden. It was created by Maarten Struijk Wilbrink, with help of Isabella Saccardi, under the supervision of the course creator Dr. Carlijn Bergwerff. It was created as a VR version of [an earlier 360º video project][14], under a [Grassroots grant][15] of the University Leiden. That project was first used in the 2019 Gesprekstechnieken workgroups. 


# Acknowledgements
We’d like to extend our gratitude to our many play-testers over the course of development, who have provided invaluable feedback on our progress. As mentioned before, this VR version is based on earlier work done in the 360º version. The basis of the project, as well as a lot of audio used in this project, was made by Rosanne van den Berg and Dr. Carlijn Bergwerff, with help of the volunteer clients seen in those videos. Our current project wouldn’t have been possible without the help of all of these wonderful people. 


Thank you!











































[1]:	https://surfdrive.surf.nl/files/index.php/s/rX3PzrLuiKRls02
[2]:	https://uploadvr.com/sideloading-quest-how-to/
[3]:	https://www.youtube.com/watch?v=raQ3iHhE_Kk
[4]:	https://www.cgtrader.com/3d-models/character/child/toon-girl-riggged-child
[5]:	https://www.cgtrader.com/3d-models/character/woman/teen-girl-cartoon
[6]:	https://www.cgtrader.com/3d-models/character/woman/jasmin-cartoon-girl
[7]:	https://readyplayer.me
[8]:	https://docs.readyplayer.me/integration-guides/unity
[9]:	https://assetstore.unity.com/packages/tools/animation/salsa-lipsync-suite-148442
[10]:	https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676
[11]:	https://assetstore.unity.com/packages/tools/utilities/odin-inspector-and-serializer-89041
[12]:	https://www.youtube.com/playlist?list=PLcVmXGedVLuYmcdOlOMWwFjEe06toMibh
[13]:	https://www.universiteitleiden.nl/nieuws/2019/03/comeniusbeurs-voor-onderwijsinnovatie-toegekend-aan-carlijn-bergwerff
[14]:	https://www.universiteitleiden.nl/nieuws/2019/08/gebruik-van-virtual-reality-bij-het-toepassen-van-gesprekstechnieken-in-de-pedagogische-praktijk
[15]:	https://www.universiteitleiden.nl/nieuws/2018/10/grassroots-grass-shoots-subsidies-voor-pedagogen