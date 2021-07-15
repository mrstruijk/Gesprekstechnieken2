# GPInteraction overview
## Program content and goals
In this program you can interact via scripted conversations with various virtual characters (VCs), in a simulated therapy training session. During the interactions, a coach will provide detailed feedback on your progress. Currently, this program is in Dutch (however, see below for options to change this). 

The goal of this program is to help students practice conversation skills in a realistic virtual setting, to supplement their conversation skills practice with other students, volunteers and actors.


## Hardware and Software
Created for and tested on the Oculus Quest and Oculus Quest 2. 

Created with Unity 2019.4.19f1. 


## Downloading and using complete program (APK)
If you would like to use (but not edit) the full program, there’s a [link to the APK file][1]. With this you can experience a fully working version of our program. This might be handy for piloting purposes, or if you’d like to use it “as is” in your own course. With this link, you cannot edit the program. More about this can be found below. 

You can find a [detailed guide on how to install the APK on the Quest][2].

## General overview of program
The program runs on a predefined loop, which (in the current version) repeats six times in each Scene. It looks something like this: 

- The VC will start the interaction, usually by saying something to you (or in some cases, by studiously ignoring you!). This is called the ‘Situatieschets’ (see below: General Structure of Cards).
- You’re asked to imagine how you would respond, and to say this out loud.
- Then, you will see three possible answers. The options are written on three separate cards you’ll see in front of you. These are called ‘ConversationOptions’ (see below: General Structure of Cards). You’re asked to select the option that most closely matches to the one you just said. Some options are naturally ‘better’ than others. 
- The VC will respond verbally, physically and with facial expressions to the option you just selected.
- You will hear feedback from your coach. 
- You get the option to restart the interaction, or continue to the next loop. These cards are called ‘Flow’ (see below: General Structure of Cards)


### Physical actions, and other movements
Use the controllers for interaction. Selecting the conversation options and moving the loop along is done by grabbing a virtual ‘card’ in front of you using the squeeze button (middle/ring finger), and dropping the card into a virtual box on your right hand side. Any cards which are not chosen will automatically flow into the box as well. 

No other locomotion is required. Participants can stay seated. 


### Structure during workgroup and some common hurdles
We started each workgroup with a presentation (+- 20 min), in which we explained how to use the headset and the program. This presentation can be found in the /Supporting Documents folder. You can use and/or edit the presentation to your heart’s content. 

After this, the headsets were distributed to the students. In our case, very few students were familiar with the Oculus Quest or VR in general. Getting participants familiar with operating the headsets (e.g. setting the floor level and become familiar with the controls) took a fair bit of time in each workgroup. In our 6 workgroups so far, we noticed that around 20-30 minutes was needed (from moment of distribution) for all students to have started the Tutorial / session.

Per 20 students, 1 or ideally 2 experienced helpers were needed to answer questions and help getting the program started. In our experience, there was a fair amount of (minor) technical help required. 


### Time required for the experience
A Tutorial can be completed to familiarize the participants with the structure of the session, and some technical aspects. This takes about 10 minutes. 

Each therapy session takes about 15-20 minutes to complete. In our case, students performed both the tutorial and one of the therapy sessions in the workgroup. In total (including the presentation & explanation, troubleshooting, the actual task, and short wrap-up) the VR workgroup took about 1.5 hours to complete.



# General structure of the Cards
In the Hierarchy of each Scene, you will find a Prefab Variant of the Cards Prefab. So for instance, in the Teenager scene, you will find the ‘Cards Teen’ gameobject. This holds a series of child gameobject, which each perform a specific function:
- The ‘Cards SituatieSchets’ hold each initial conversation starter by the VC. This will be the first section of the loop described above.
- The ‘Cards Think’ prompt you to think about how you would like to respond, and to say this out loud.
- The ‘Cards ConversationOptions’ hold the three separate conversation options: A, B and C. This means that all options A for a particular scene are listed one after the other in that one gameobject. Same for B and C. The counter (StoryLine) keeps track of which of the loops should be played/displayed.
- The ‘Cards Flow’ allow you to try the last conversation again (= re-do this loop), to start over completely (= restart at loop 0), or to continue to the next conversation (= continue to SituatieSchets of the next loop). 


# A few of the important scripts and other components used
### SpeakCardOptionHolder Scriptable Object (SO)
This script lives on every ConversationOptions card. It holds the scriptable object (SO) ‘Card Options’, in which we find a list of all the pieces of text on that card, the responses by the VC (in audio, animation and blendshape emotions), and the feedback from the coach. 

### Card Options SO
These live inside the Project view, and are referenced in the SpeakCardOptionHolder mentioned above. They contain all VC / coach responses, as well as the card text.

### SpeakingSettings
Holds the different components needed for animation, emotion, and audio for each VC.

### Animator
Animations are started using their respective trigger from each CardOptions SO. Animations are all stopped using the ‘stopSpeaking’ trigger, which is fired when the VC is done talking. 

The triggers are automatically collected using the SpeakingSettings component. (Therefore, if you want to change the program and add new animations, you can find the new triggers automatically in the SpeakingSettings component)

### MoveUsingDOTweenWithTransforms (see below for DOTween explanation)
This allows the cards to ‘physically’ flow back and forth. For instance, once the VC has said what they wanted to say in their SituatieSchets, the ‘Think’ card flows to a position in front of the participant. Once this card has been dropped in the box to the right, the ‘ConverstationOptions’ cards flow to the front. Etc. 

### EventSO and GameEventUnityEventLinker
Based on [a presentation on Scriptable Objects by Ryan Hipple][3], this is a pair of very useful components. One is a Scriptable Object (SO) Event, which (after creation) lives inside the /Assets/ScriptableObjects/Events folder, which can be referenced and triggered from anywhere. The other component is a MonoBehaviour script, which takes one of these SO Events as input and uses it to trigger it’s own UnityEvents. It does this when the SO Event is triggered trough `Raise()`. 

This ‘dual event’ system allows you to create fairly decoupled Prefabs. 
Create your Prefabs (holding the GameEventUnityEventLinkers) so that they only link to other components inside of that Prefab. At the same time, the EventSO event can be linked to and triggered from anywhere in the Scene. Because the EventSO lives inside the Project view, you can delete or instantiate new Prefabs in the Scene without breaking anything: in each Scene they only link to (components inside) themselves.

The major downside is that you risk creating a fairly brittle system in a different way. You create connections within each Prefab using the Inspector. Therefore, if you accidentally remove or change one of the links on that UnityEvent, you might break a fundamental part of the program. Since these links were not written in code, and therefore don’t throw any errors, it is virtually impossible to find out what you need to restore to fix this link again… 

A suggested solution to this problem is to make sure your Prefab (Variants) are always properly saved and up to date, and that you double check the working of the links in that Prefab prior to Overriding it. 

Also: use version control.

### Audio
All client audio has been recorded for use in the earlier 360º video version of this project (see below). The audio clips are triggered from the scriptable objects (SpeakCardOptionHolder), found in the /Assets/ScriptableObjects/Conversations folders. 

The coach audio has been recorded specifically for this project, since the 360º video version did not include spoken coach audio. For some scenes, a female coach is used, in other scenes a male coach is used. 

The .XLSX transcripts of these audio conversations (including responses by the coach and some suggested animations and emotes) can be found in /Supporting Documents.


# Purchased models and assets (not included in Open Source!):
In our version of the program we’ve used some models and assets that have been purchased separately. These unfortunately couldn’t be included in an open-source version of the program (see below for more info). Therefore we’re including as much information and configuration components as possible, so that you can (re-)create your own version. I’ll also include some information about how well these models performed, because we think you might want to swap some models out for better versions.


### Virtual Character Model: Child (Olivia)
For the [child Olivia][4] we used a lovely model purchased from the creator ‘CharacterStore’ through CGTrader. The model has excellent blendshapes and some customisation in hair styles. Her facial expressions (through blendshapes) worked especially well, and we were able to create a real sense of personality using the SALSA random Emotes (see for an excellent example Oliva.avi in the /Supporting Documents folder). 


### Virtual Character Model: Teen (Sofie)
The model for [teenager Sofie][5] was also purchased through CGTrader, from the designer Pradipta-D. Wether it was due to us spending less time on customising this model, or the model quality in general, but our experiences with this model were not excellent. Her rig is needlessly complex, and her textures are not stellar. Few blendshapes are available, but we managed to make SALSA lipsync and some emotes work fine. On the plus side, this model is not very expensive. 


### Virtual Character Model: Coach (Jasmine)
The [coach][6] model (used only in the Tutorial scene, since in the other scenes you hear a coach via headphones) is from the same maker as the Teen model. Using a different rig and blendshape setup than the teen model, this model was also not perfect, but suited our needs for now. The model worked well enough for SALSA lipsync and displayed a few emotions. 


### Virtual Character Model: Parents (André and Janneke)
The models for the [parents Janneke and André][7] were free, and can be obtained through ReadyPlayerMe. This is a service which allows a little customisation to the models, which is nice. However, these models have a distinct ‘Fortnite’ look, which is especially evident in some of their more …uhm… extravagant customisation options.

At the time of writing, ReadyPlayerMe’s intended use-case is for having 1 VC in the Unity scene. It required a bit of a work-around to obtain a second VC: 
1. Download the first model using the [instructions][8] on the ReadyPlayerMe website. 
2. Grab the downloaded files from the standard ReadyPlayerMe folders in the Unity Project view, and place them into a different folder (e.g. /Assets/Characters). 
3. Download a second model from the ReadyPlayerMe website, which can be done by clearing your browser cache (or using a second browser).
4. Repeat step 2 for the second model.
5. Put both VCs in the scene. An oddity of these models is that they have a separate .FBX file containing only the rig, and a separate .GLB file for the model itself. You’ll need both. The prefab you’ll be using in the scene (based on the .GLB) needs to reference the .FBX in the Animator component (which needs to be on the GLB’s Armature child gameobject to work properly). 

A slightly strange feature was that the mother (Janneke) did not have correct y-rotation available on her neck, therefore she couldn’t turn her head at all. We replaced head-rotation by a slight head-tilt as one of her SALSA random emotes. The feedback from our participants however was that this made her look rather stern… The father model (André) did not have this issue. 

### Virtual Character Values (included in the Public Project)
All animations and animator controllers, as well as the SALSA values, can be found in the folders inside /Assets/Characters/ . This can be useful in case you want to use the same or similar models to recreate the program. 


### Asset: SALSA
[SALSA][9] is a stellar asset, which allows for lipsync, emotion processing and eye-movement of the VC. All three components of SALSA were used in this project. The Lipsync component allows real time lip synchronisation to happen with any provided audio clip, in any language. The Emote section uses Blendshapes and Transforms to create emotion animations, which can be triggered manually, through code, or randomly. The Eye section creates random blinks, and random or predefined eye movements. These SALSA components combined make a VC much more realistic. 

See for an excellent example the videoclip ‘Oliva.avi’ in the /Supporting Documents folder. Here we’re showing off her random idle emotes and eye-movements when she’s not talking.

### Asset: DOTween
[DOTween][10] makes moving gameobjects such as our Cards easy and smooth. It allows for Cards to flow seamlessly back and forth. A free version can be got from the AssetStore, however the paid version was used in this project. 

Since we’re reusing the same gameobjects for the Cards over and over again (e.g. the CardOption B holds all the B options, and therefore needs to be reused in every loop), DOTween allows you to always move these cards to the correct position at any time. 

Sometimes we’re using DOTween to snap a card immediately to a new position (for instance to it’s original position on the participants’ left), while other times DOTween flows the card gracefully to where it needs to be. 

### Asset: Odin
We’ve used [Odin][11] extensively in our project. This allows us to create easier to navigate Inspector fields, which came especially handy when using the various scriptable objects holding data and logic for the conversations on each Card. We cannot recommend this asset enough. 

In the Public version of the program, all Odin code has been commented out, and has been replaced by standard Unity code. However, we recommend that you purchase Odin, and re-enable the commented-out sections of code, to make the inspector read well again. 

### Other assets
A few other assets were bought and used in limited ways. See below for a full list.

### Are these paid assets required to edit the program?
No. However, some are highly recommended. 

You should really purchase SALSA, and to get one of the versions of DOTween. A lot of our code is dependent on both these systems, and to try to recreate it using different methods would require a tremendous amount of work.

Odin is strictly speaking not necessary to run the program. However, since it vastly increases the readability of the most complex Inspector screens, I cannot recommend you this asset enough. It is well worth the cost. 


# Adapting the program to your needs
### Obtaining the program
The project was created in [Unity 2019.4.19][12]. Download that version for best results.

You can [download our Public Unity Project][13] following the link. This contains most files you will need to start building your own version of this project. Due to our use of third party assets, we have some limitations in providing you with the full project unfortunately. However, one way that we can still achieve this, is if you can provide us with payment receipts for the assets listed below. We can then provide you access to the Private GitHub submodule containing all remaining files needed to continue building the project from where we left off. 
[Model: child Olivia][14]
[Model: teenager Sofie][15]
[Model: coach][16]
[SALSA][17]
[DOTween Pro][18]
[Odin][19]
[Beautify 2][20]
[FinalIK][21]

However, below is an explanation of how the program runs, and what you can do using the Public Unity Project listed above. It also has some suggestions for where paid assets can come in handy. 

### Core / Cards (included in Public Project)
The core of the program is the conversation loop, built on the process of grabbing a card and dropping it somewhere else. That means that the basic structure going from ‘SituatieSchets’ —\> ‘Think card’ —\> three ‘Conversation options’ —\> ‘Restart or Continue’, is fairly hard coded into the system. You can definitely amend these if required, but that would be a lot of work.
The ‘Cards XXX’ Prefab Variants can be found in the Hierarchy. 
The Cards are triggered to flow into the box on the right hand side because they collide with the Box Collider on the CardChooserBox child gameobject of the CardLocationsObject. It uses DOTween to move / rotate into position. 

### Interaction Content  (included in Public Project)
The content of the interactions is relatively easy to change. You can change or increase the length of the conversation by recording new audio clips, and dropping these into the relevant ConversationOptions. Recreating the sessions in another language is therefore possible (also; SALSA is language agnostic!).

Most likely you’re going to need seven new audio clips per additional loop:
- 1 ‘SituatieSchets’ prompt by the VC 
- 3 possible ‘Conversation Options’ by the VC
- 3 possible bits of feedback by the coach). 

You can also opt for ‘stacking’ multiple responses in one ‘SituatieSchets’ or ‘Conversation Option’, which is something that we’ve done for instance in the Parent’s Scene. You can also stack multiple pieces of audio feedback by the coach, if desired.

### Virtual Characters (not included in Public Project)
Replacing the character models is relatively easy. Make sure you give them a new Speaking Settings SO, and provide the SALSA components with the required information. Refer to this [detailed SALSA tutorial][22] for more information on how to do this.

### Virtual Environment (1 environment is included in Public Project)
Changing the virtual environment is easy. Just swap out the ‘Environment XXX’ Prefab from the Hierarchy. 

Make sure you move the entire Cards Prefab (Variant), and especially the CardLocationsObject, near to where your participant will sit/stand (most likely at the origin point: x0,y0,z0) in your new environment. 


### New Scenes (3 scenes and 1 tutorial are included in Public Project)
Creating a completely new Scene is also quite easily done. Keep in mind that you create a new ‘Cards’ Prefab Variant based off the original ‘Cards’ Prefab, and not based on one of the other ‘Cards Prefab Variants’… unless that is your express goal of course. 

When creating a new Scene, you also need to create three new ConversationOptions (A, B and C), fill them with conversation text & audio. Make sure that a Speaking Settings SO is attached to your model. 

### Creating new Scriptable Objects (SO)
Scriptable Objects (such as an EventSO) can be easily created by right clicking in the Project View, then go to ‘mrstruijk’, and select the SO you need.  



# Funding and first use
This program was created under the [Comenius Teaching Fellow grant][23], for use in the 2021 workgroups of the course Gesprekstechnieken 2 of the Education and Child Studies bachelor at the University of Leiden. It was created by Maarten R. Struijk Wilbrink, with help of Isabella Saccardi, under the supervision of the course creator Dr. Carlijn Bergwerff. It was created as a VR version of [an earlier 360º video project][24], under a [Grassroots grant of the Universiteit Leiden][25]. That project was first used in the 2019 Gesprekstechnieken workgroups. It was used concurrently in the 2021 workgroups, alongside the role-play and VR exercises. 


# Acknowledgements
As mentioned before, this VR version is based on earlier work done in the 360º version. The basis of the project, as well as a lot of audio used in this project, was made by Rosanne van den Berg and Dr. Carlijn Bergwerff, with help of the volunteer clients seen in those videos. 

We’d like to extend our gratitude to our many play-testers over the course of development, who have provided invaluable feedback on our progress. 

Our current project wouldn’t have been possible without the help of all of these wonderful people. 


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
[12]:	https://unity3d.com/get-unity/download/archive
[13]:	https://github.com/mrstruijk/Gesprekstechnieken2 "here"
[14]:	https://www.cgtrader.com/3d-models/character/child/toon-girl-riggged-child
[15]:	https://www.cgtrader.com/3d-models/character/woman/teen-girl-cartoon
[16]:	https://www.cgtrader.com/3d-models/character/woman/jasmin-cartoon-girl
[17]:	https://assetstore.unity.com/packages/tools/animation/salsa-lipsync-suite-148442
[18]:	https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676
[19]:	https://assetstore.unity.com/packages/tools/utilities/odin-inspector-and-serializer-89041
[20]:	https://assetstore.unity.com/packages/vfx/shaders/fullscreen-camera-effects/beautify-2-163949
[21]:	https://assetstore.unity.com/packages/tools/animation/final-ik-14290
[22]:	https://www.youtube.com/playlist?list=PLcVmXGedVLuYmcdOlOMWwFjEe06toMibh
[23]:	https://www.universiteitleiden.nl/nieuws/2019/03/comeniusbeurs-voor-onderwijsinnovatie-toegekend-aan-carlijn-bergwerff
[24]:	https://www.universiteitleiden.nl/nieuws/2019/08/gebruik-van-virtual-reality-bij-het-toepassen-van-gesprekstechnieken-in-de-pedagogische-praktijk
[25]:	https://www.universiteitleiden.nl/nieuws/2018/10/grassroots-grass-shoots-subsidies-voor-pedagogen